using System.ComponentModel.DataAnnotations;
using System.IO;
using Foresight.Logic.Connection;

namespace Ferry.Logic.Connection
{
    internal class OleDbConnectionInfo : IDbConnectionInfo
    {
        private readonly string _path;

        #region Public Members

        public OleDbConnectionInfo(string path)
        {
            _path = path;
        }

        public string GetConnectionString()
        {
            checkPathExits();

            return "Provider=Microsoft.Jet.OLEDB.4.0" +
                   ";Data Source=" + _path +
                   ";Extended Properties=dBASE IV" +
                   ";User ID=Admin;Password=";
        }

        #endregion

        #region Internal Members

        private void checkPathExits()
        {
            if (!Directory.Exists(_path))
                throw new ValidationException(string.Format("Data folder {0} doesn't exist.", _path));
        }

        #endregion
    }
}
