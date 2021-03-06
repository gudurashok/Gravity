﻿using System;
using System.Data;
using Foresight.Logic.Common;
using Foresight.Logic.Properties;
using Foresight.Logic.Sql;

namespace Foresight.Logic.DataAccess
{
    public class Database
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public void ChangeDatabase(string databaseName)
        {
            _connection.ChangeDatabase(databaseName);
        }

        public Database(IDbConnection connection)
        {
            _connection = connection;
            _connection.Open();
        }

        public IDbCommand CreateCommand()
        {
            return CreateCommand(null);
        }

        public IDbCommand CreateCommand(string commandText)
        {
            var command = _connection.CreateCommand();
            command.Transaction = _transaction;
            command.CommandText = commandText;
            return command;
        }

        public void BeginTransaction()
        {
            if (_transaction != null)
                throw new Exception(Resources.CannotStartNewTransaction);

            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            finally
            {
                _transaction = null;
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _transaction = null;
            }
        }

        public void AddParameterWithValue(IDbCommand cmd, string name, object value)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = name;
            param.Value = ForesightUtil.ConvertToDbValue(value);
            cmd.Parameters.Add(param);
        }

        public IDataReader ExecuteReader(string commandText)
        {
            var cmd = CreateCommand(commandText);
            return cmd.ExecuteReader();
        }

        public IDataReader ExecuteReader(string commandText, string paramName, object paramValue)
        {
            var cmd = CreateCommand(commandText);
            AddParameterWithValue(cmd, paramName, paramValue);
            return cmd.ExecuteReader();
        }

        public object ExecuteScalar(string commandText)
        {
            var cmd = CreateCommand(commandText);
            return cmd.ExecuteScalar();
        }

        public object ExecuteScalar(string commandText, string paramName, object paramValue)
        {
            var cmd = CreateCommand(commandText);
            AddParameterWithValue(cmd, paramName, paramValue);
            return cmd.ExecuteScalar();
        }

        public void ExecuteNonQuery(string commandText)
        {
            var cmd = CreateCommand(commandText);
            cmd.ExecuteNonQuery();
        }

        public void ExecuteNonQuery(string commandText, string paramName, object paramValue)
        {
            var cmd = CreateCommand(commandText);
            AddParameterWithValue(cmd, paramName, paramValue);
            cmd.ExecuteNonQuery();
        }

        public void Close()
        {
            Rollback();

            if (_connection.State == ConnectionState.Open)
                _connection.Close();

            _connection = null;
        }

        public bool IsDatabaseExists(string databaseName)
        {
            var cmd = CreateCommand(SqlQueries.SelectCountFromSysDatabases);
            AddParameterWithValue(cmd, "@name", databaseName);
            var value = Convert.ToInt32(cmd.ExecuteScalar());
            return value == 1;
        }

        public string GetGeneratedIdentityValue()
        {
            var cmd = CreateCommand(SqlQueries.ReadGeneratedIdentityValue);
            var value = cmd.ExecuteScalar();
            return ForesightUtil.ConvertDbNullToString(value);
        }
    }
}
