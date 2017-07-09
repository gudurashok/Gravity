using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data;
using Foresight.Logic.Common;
using Foresight.Logic.Ledger;
using Foresight.Logic.Properties;
using Foresight.Logic.Report;
using Foresight.Logic.Sql;
using Gravity.Root.Model;
using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Scalable.Shared.Model;

namespace Foresight.Logic.DataAccess
{
    public class DataContext : IDisposable
    {
        #region Declarations

        private readonly Database _db;

        #endregion

        #region Constructors

        public DataContext()
            : this(ForesightSession.CompanyGroup)
        {
        }

        public DataContext(CompanyGroup companyGroup)
        {
            _db = DatabaseFactory.GetForesightDatabase(companyGroup);
            ForesightSession.CompanyGroup = companyGroup;

            //ForesightSession.CompanyGroup = 
            //    GetCompanyGroupById(GetCompanyGroupIdByName(companyGroup.Entity.ForesightDatabaseName));
        }

        #endregion

        #region Company Group

        public int GetCompanyGroupIdByName(string name)
        {
            var value = _db.ExecuteScalar(SqlQueries.SelectCompanyGroupIdByName, "@name", name);

            if (value == null)
                return 0;

            return (int)value;
        }

        public CompanyGroup GetCompanyGroupById(int id)
        {
            var reader = _db.ExecuteReader(SqlQueries.SelectCompanyGroupById, "@Id", id);
            CompanyGroup group = null;
            if (reader.Read())
                group = readCompanyGroup(reader);

            reader.Close();
            return group;
        }

        private CompanyGroup readCompanyGroup(IDataReader reader)
        {
            var group = CompanyGroup.New();
            group.Entity.Id = reader["Id"].ToString();
            group.Entity.Name = reader["Name"].ToString();
            return group;
        }

        #endregion

        #region Company

        public Company GetCompanyByCode(string code)
        {
            return getCompanyBySql(string.Format(SqlQueries.SelectCompanyByCode, code));
        }

        public Company GetCompanyById(int id)
        {
            return getCompanyBySql(string.Format(SqlQueries.SelectCompanyById, id));
        }

        private Company getCompanyBySql(string sql)
        {
            using (var reader = _db.ExecuteReader(sql))
            {
                Company company = null;
                if (reader.Read())
                    company = new Company(new CompanyEntity
                    {
                        Id = reader["Id"].ToString(),
                        Code = reader["Code"].ToString(),
                        Name = reader["Name"].ToString(),
                    });

                return company;
            };
        }

        public int InsertCompany(CompanyEntity company, int companyGroupId)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertCompany);
            _db.AddParameterWithValue(cmd, "@Code", company.Code);
            _db.AddParameterWithValue(cmd, "@Name", company.Name);
            _db.AddParameterWithValue(cmd, "@GroupId", companyGroupId);
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(_db.GetGeneratedIdentityValue());
        }

        public void DeleteCompany(Company company)
        {
            if (isCompanyInUse(company))
                throw new ValidationException(Resources.ThisCompanyIsInUseCannotDelete);

            _db.ExecuteNonQuery(SqlQueries.DeleteCompany, "@Id", company.Entity.Id);
        }

        private bool isCompanyInUse(Company company)
        {
            return Convert.ToInt32(_db.ExecuteScalar(SqlQueries.SelectCompanyCountFromCompanyPeriod, "@CompanyId", company.Entity.Id)) > 0;
        }

        #endregion

        #region Company Period

        public CompanyPeriod GetCompanyPeriodByCompanyAndPeriodId(string companyId, string periodId)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectCompanyPeriodByCompanyAndPeriodId);
            _db.AddParameterWithValue(cmd, "@CompanyId", companyId);
            _db.AddParameterWithValue(cmd, "@PeriodId", periodId);
            var value = cmd.ExecuteScalar();

            if (value == DBNull.Value)
                return null;

            return GetCompanyPeriodById(Convert.ToInt32(value));
        }

        public void ClearUnfinishedImports(string whereClause)
        {
            var cmd = _db.CreateCommand(SqlQueries.ClearUnfinishedCompanyPeriodImports + whereClause);
            cmd.ExecuteNonQuery();
        }

        public void UpdateIsCompanyPeriodImporting(CompanyPeriod cp, bool value, int processId)
        {
            var cmd = _db.CreateCommand(SqlQueries.UpdateCompanyPeriodIsImporting);
            addCompanyPeriodParams(cmd, cp);
            _db.AddParameterWithValue(cmd, "@isImporting", value);
            _db.AddParameterWithValue(cmd, "@processId", processId);
            cmd.ExecuteNonQuery();
        }

        public void CheckIsCompanyPeriodImported(CompanyPeriod cp)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectCompanyIsImported);
            addCompanyPeriodParams(cmd, cp);
            cp.Entity.IsImported = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public bool IsCompanyPeriodImporting(CompanyPeriod cp)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectCompanyIsImporting);
            addCompanyPeriodParams(cmd, cp);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public int SaveCompanyPeriod(CompanyPeriod cp)
        {
            if (isCompanyPeriodExist(cp))
                throw new ValidationException(Resources.PeriodAlreadyExists);

            return insertCompanyPeriod(cp);
        }

        private int insertCompanyPeriod(CompanyPeriod cp)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertCompanyPeriod);
            addCompanyPeriodParams(cmd, cp);
            _db.AddParameterWithValue(cmd, "@DataPath", cp.Entity.SourceDataPath);
            _db.AddParameterWithValue(cmd, "@SourceDataProvider", cp.Entity.SourceDataProvider);
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(_db.GetGeneratedIdentityValue());
        }

        public void SaveCompanyPeriod(CompanyPeriod oldCp, CompanyPeriod newCp)
        {
            if (isCompanyPeriodExist(newCp))
                throw new ValidationException(Resources.PeriodAlreadyExists);

            try
            {
                _db.BeginTransaction();

                //if (newCp.Company.IsNew())
                //    InsertCompany(newCp, companyGroupId);

                updateCompanyPeriod(oldCp, newCp);
                setCompanyPeriodColumnValue(oldCp, newCp);
                _db.Commit();
            }
            catch
            {
                _db.Rollback();
                throw;
            }
        }

        private void updateCompanyPeriod(CompanyPeriod oldCp, CompanyPeriod newCp)
        {
            var cmd = _db.CreateCommand(SqlQueries.UpdateCompanyPeriod);
            _db.AddParameterWithValue(cmd, "@NewCompanyId", newCp.Company.Entity.Id);
            _db.AddParameterWithValue(cmd, "@NewPeriodId", newCp.Period.Entity.Id);
            _db.AddParameterWithValue(cmd, "@CompanyId", oldCp.Company.Entity.Id);
            _db.AddParameterWithValue(cmd, "@PeriodId", oldCp.Period.Entity.Id);
            cmd.ExecuteNonQuery();
        }

        private bool isCompanyPeriodExist(CompanyPeriod cp)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectCountOfCompanyPeriod);
            addCompanyPeriodParams(cmd, cp);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private void addCompanyPeriodParams(IDbCommand cmd, CompanyPeriod cp)
        {
            _db.AddParameterWithValue(cmd, "@CompanyId", cp.Foresight.CompanyId);
            _db.AddParameterWithValue(cmd, "@PeriodId", cp.Foresight.PeriodId);
        }

        public int GetCompanyPeriodIdByNameAndFinPeriod(string name, FiscalDatePeriod period)
        {
            var cmd = _db.CreateCommand();
            cmd.CommandText = string.Format(SqlQueries.SelectCompanyPeriodIDByNameAndFinPeriod);
            _db.AddParameterWithValue(cmd, "@companyName", name);
            _db.AddParameterWithValue(cmd, "@FinancialFrom", period.Entity.Financial.From);
            _db.AddParameterWithValue(cmd, "@FinancialTo", period.Entity.Financial.To);
            var value = cmd.ExecuteScalar();
            return value == DBNull.Value ? 0 : Convert.ToInt32(value);
        }

        public CompanyPeriod GetCompanyPeriodById(int id)
        {
            var reader = _db.ExecuteReader(string.Format(SqlQueries.SelectCompanyPeriodsBy,
                                                                    " WHERE cp.Id = @Id"), "@Id", id);
            CompanyPeriod cp = null;

            if (reader.Read())
                cp = readCompanyPeriod(reader);

            reader.Close();
            return cp;
        }

        public IList<CompanyPeriod> GetCompanyPeriods()
        {
            return GetCompanyPeriods(false);
        }

        public IList<CompanyPeriod> GetCompanyPeriods(bool importedOnly)
        {
            var result = new List<CompanyPeriod>();
            var reader = _db.ExecuteReader(string.Format(SqlQueries.SelectCompanyPeriodsBy,
                                                    getSelectCompanyPeriodByFilter(importedOnly)));

            while (reader.Read())
                result.Add(readCompanyPeriod(reader));

            reader.Close();
            return result;
        }

        private string getSelectCompanyPeriodByFilter(bool importedOnly)
        {
            return importedOnly ? " WHERE cp.IsImported = 1" : "";
        }

        private CompanyPeriod readCompanyPeriod(IDataReader reader)
        {
            var period = CompanyPeriod.New();
            period.Company = GetCompanyById(Convert.ToInt16(reader["CompanyId"]));
            period.Entity.Id = reader["Id"].ToString();
            period.Period = new FiscalDatePeriod(new FiscalDatePeriodEntity());
            period.Period.Entity.Id = reader["periodId"].ToString();
            period.Period.Entity.Name = reader["Name"].ToString();
            period.Period.Entity.Financial = new DatePeriod
            {
                From = Convert.ToDateTime(reader["FinancialFrom"]),
                To = Convert.ToDateTime(reader["FinancialTo"])
            };
            period.Entity.SourceDataPath = reader["DataPath"].ToString();
            period.Entity.SourceDataProvider = (SourceDataProvider)Convert.ToInt16(reader["SourceDataProvider"]);
            period.Entity.IsImported = reader["IsImported"] != DBNull.Value && Convert.ToBoolean(reader["IsImported"]);
            return period;
        }

        public void DeleteCompanyPeriod(CompanyPeriod cp)
        {
            try
            {
                _db.BeginTransaction();
                var cmd = _db.CreateCommand();

                if (cp.Entity.IsImported)
                {
                    var did = new DeleteImportedData(_db, cmd, cp);
                    did.Delete();
                }

                deleteCompanyPeriod(cmd, cp.Entity.ForesighId);
                _db.Commit();
            }
            catch
            {
                if (_db != null)
                    _db.Rollback();

                throw;
            }
        }

        private void deleteCompanyPeriod(IDbCommand cmd, int id)
        {
            cmd.CommandText = SqlQueries.DeleteCompanyPeriod;
            _db.AddParameterWithValue(cmd, "@Id", id);
            cmd.ExecuteNonQuery();
        }

        private void setCompanyPeriodColumnValue(CompanyPeriod oldCp, CompanyPeriod newCp)
        {
            var rdr = getTransTableList();
            var cmd = createChangeCompanyPeriodColumnCommand();

            while (rdr.Read())
            {
                cmd.CommandText = string.Format(SqlQueries.ChangeTransTablesCompanyPeriod, rdr["TableName"]);
                ((IDbDataParameter)cmd.Parameters["@NewCompanyId"]).Value = newCp.Company.Entity.Id;
                ((IDbDataParameter)cmd.Parameters["@NewPeriodId"]).Value = newCp.Period.Entity.Id;
                ((IDbDataParameter)cmd.Parameters["@CompanyId"]).Value = oldCp.Company.Entity.Id;
                ((IDbDataParameter)cmd.Parameters["@PeriodId"]).Value = oldCp.Period.Entity.Id;
                cmd.ExecuteNonQuery();
            }

            rdr.Close();
        }

        private IDbCommand createChangeCompanyPeriodColumnCommand()
        {
            var cmd = _db.CreateCommand();
            _db.AddParameterWithValue(cmd, "@NewCompanyId", null);
            _db.AddParameterWithValue(cmd, "@NewPeriodId", null);
            _db.AddParameterWithValue(cmd, "@CompanyId", null);
            _db.AddParameterWithValue(cmd, "@PeriodId", null);
            return cmd;
        }

        private IDataReader getTransTableList()
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectTransTables);
            return cmd.ExecuteReader();
        }

        public void SetCompanyPeriodColumnValue(CompanyPeriod companyPeriod)
        {
            using (var rdr = getTransTableList())
            {
                var cmd = createUpdateCompanyPeriodColumnCommand();
                while (rdr.Read())
                {
                    cmd.CommandText = string.Format(SqlQueries.UpdateTransTablesCompanyPeriod, rdr["TableName"]);
                    ((IDbDataParameter)cmd.Parameters["@CompanyPeriodId"]).Value = companyPeriod.Foresight.Id;
                    ((IDbDataParameter)cmd.Parameters["@CompanyId"]).Value = companyPeriod.Foresight.CompanyId;
                    ((IDbDataParameter)cmd.Parameters["@PeriodId"]).Value = companyPeriod.Foresight.PeriodId;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private IDbCommand createUpdateCompanyPeriodColumnCommand()
        {
            var cmd = _db.CreateCommand();
            _db.AddParameterWithValue(cmd, "@CompanyPeriodId", null);
            _db.AddParameterWithValue(cmd, "@CompanyId", null);
            _db.AddParameterWithValue(cmd, "@PeriodId", null);
            return cmd;
        }

        public void DeleteCompanyPeriodLedgerData(CompanyPeriod companyPeriod)
        {
            var cmd = _db.CreateCommand(string.Format(SqlQueries.DeleteTransTablePeriodData, "AccountLedger"));

            _db.AddParameterWithValue(cmd, "@CompanyId", companyPeriod.Foresight.CompanyId);
            _db.AddParameterWithValue(cmd, "@PeriodId", companyPeriod.Foresight.PeriodId);
            cmd.ExecuteNonQuery();

            cmd.CommandText = string.Format(SqlQueries.DeleteTransTablePeriodData, "ItemLedger");
            cmd.ExecuteNonQuery();
        }

        public ForesightCompanyPeriod GetForesightCompanyPeriod(int id)
        {
            var cmd = _db.CreateCommand();
            cmd.CommandText = SqlQueries.SelectCompanyPeriodById;
            _db.AddParameterWithValue(cmd, "@Id", id);
            using (var rdr = cmd.ExecuteReader())
            {
                if (!rdr.Read())
                    throw new Exception($"Foresight company period id {id} not found.");

                return new ForesightCompanyPeriod
                {
                    Id = id,
                    CompanyId = Convert.ToInt32(rdr["CompanyId"]),
                    PeriodId = Convert.ToInt32(rdr["PeriodId"])
                };
            };
        }

        public void DeleteCompanyPeriodData(CompanyPeriod companyPeriod, bool forceDelete = false)
        {
            if (!forceDelete && !companyPeriod.Entity.IsImported)
                return;

            var cmd = _db.CreateCommand();
            var importedData = new DeleteImportedData(_db, cmd, companyPeriod);
            importedData.Delete();
        }

        public void SetCompanyPeriodIsImported(CompanyPeriod companyPeriod, bool isImported)
        {
            var cmd = _db.CreateCommand();
            cmd.CommandText = SqlQueries.UpdateCompanyPeriodSetIsImportedFlagValue;
            _db.AddParameterWithValue(cmd, "@companyId", companyPeriod.Foresight.CompanyId);
            _db.AddParameterWithValue(cmd, "@periodId", companyPeriod.Foresight.PeriodId);
            _db.AddParameterWithValue(cmd, "@isImported", isImported);
            cmd.ExecuteNonQuery();
        }

        #endregion

        #region DatePeriod

        public int AddDatePeriod(FiscalDatePeriod period)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertDatePeriod);
            _db.AddParameterWithValue(cmd, "@PeriodName", period.Entity.Financial.ToYearString());
            _db.AddParameterWithValue(cmd, "@FinFrom", period.Entity.Financial.From);
            _db.AddParameterWithValue(cmd, "@FinTo", period.Entity.Financial.To);
            _db.AddParameterWithValue(cmd, "@AssesmentFrom", period.Entity.Assessment.From);
            _db.AddParameterWithValue(cmd, "@AssesmentTo", period.Entity.Assessment.To);
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(_db.GetGeneratedIdentityValue());
        }

        public FiscalDatePeriod GetDatePeriodById(int id)
        {
            return readDatePeriod(_db.ExecuteReader(SqlQueries.SelectDatePeriodById, "@Id", id));
        }

        public FiscalDatePeriod GetDatePeriodByFinPeriod(FiscalDatePeriod period)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectDatePeriodByFinPeriod);
            _db.AddParameterWithValue(cmd, "@FinFrom", period.Entity.Financial.From);
            _db.AddParameterWithValue(cmd, "@FinTo", period.Entity.Financial.To);
            return readDatePeriod(cmd.ExecuteReader());
        }

        private FiscalDatePeriod readDatePeriod(IDataReader reader)
        {
            FiscalDatePeriod result = null;
            if (reader.Read())
                result = fillDatePeriod(reader);

            reader.Close();
            return result;
        }

        private FiscalDatePeriod fillDatePeriod(IDataReader reader)
        {
            var dp = new FiscalDatePeriod(new FiscalDatePeriodEntity());
            dp.Entity.Id = reader["Id"].ToString();
            dp.Entity.Name = reader["Name"].ToString();
            dp.Entity.Financial = new DatePeriod
            {
                From = Convert.ToDateTime(reader["FinancialFrom"]),
                To = Convert.ToDateTime(reader["FinancialTo"])
            };
            return dp;
        }

        #endregion

        #region Account Opening Balance

        public void SaveAccountOpeningBalance(AccountOpeningBalance aob)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertAccountOpeningBalance);
            setAccountOpeningBalanceParams(cmd, aob);
            cmd.ExecuteNonQuery();
        }

        private void setAccountOpeningBalanceParams(IDbCommand cmd, AccountOpeningBalance aob)
        {
            _db.AddParameterWithValue(cmd, "@accountId", aob.Entity.AccountId);
            _db.AddParameterWithValue(cmd, "@date", aob.Entity.Date);
            _db.AddParameterWithValue(cmd, "@amount", aob.Entity.Amount);
        }

        #endregion

        #region Sale Invoice

        public void SaveSaleInvoice(SaleInvoice invoice)
        {
            var id = saveSaleInvoice(invoice);
            invoice.SetIdentityValue(id);
            if (invoice.HeaderEx != null)
                saveSaleInvoiceHeaderEx(invoice.HeaderEx);

            foreach (var line in invoice.Lines)
                saveSaleInvoiceLine(line);

            foreach (var term in invoice.Terms)
                saveSaleInvoiceTerm(term);
        }

        private string saveSaleInvoice(SaleInvoice header)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertSaleInvoiceHeader);
            setSaleInvoiceHeaderParams(cmd, header.Entity as SaleInvoiceEntity);
            cmd.ExecuteNonQuery();
            return _db.GetGeneratedIdentityValue();
        }

        private void setSaleInvoiceHeaderParams(IDbCommand cmd, SaleInvoiceEntity header)
        {
            setTransParams(cmd, header);
            _db.AddParameterWithValue(cmd, "@brokerageAmount", header.BrokerageAmount);
            _db.AddParameterWithValue(cmd, "@through", ForesightUtil.ConvertToDbValue(header.Through));
            _db.AddParameterWithValue(cmd, "@vehicleId", header.VehicleId);
            _db.AddParameterWithValue(cmd, "@transport", ForesightUtil.ConvertToDbValue(header.Transport));
            _db.AddParameterWithValue(cmd, "@referenceDocNr", ForesightUtil.ConvertToDbValue(header.ReferenceDocNr));
            _db.AddParameterWithValue(cmd, "@orderId", header.OrderId);
            _db.AddParameterWithValue(cmd, "@discountPct", header.DiscountPct);
            _db.AddParameterWithValue(cmd, "@saleTaxColumnId", header.SaleTaxColumnId);
        }

        private void saveSaleInvoiceHeaderEx(SaleInvoiceHeaderEx headerEx)
        {
            if (headerEx == null)
                return;

            var cmd = _db.CreateCommand(SqlQueries.InsertSaleInvoiceHeaderEx);
            setSaleInvoiceExParams(cmd, headerEx);
            cmd.ExecuteNonQuery();
        }

        private void setSaleInvoiceExParams(IDbCommand cmd, SaleInvoiceHeaderEx headerEx)
        {
            _db.AddParameterWithValue(cmd, "@invoiceId", headerEx.Entity.InvoiceId);
            _db.AddParameterWithValue(cmd, "@shipToName", ForesightUtil.ConvertToDbValue(headerEx.Entity.ShipToName));
            _db.AddParameterWithValue(cmd, "@shipToAddressLine1", ForesightUtil.ConvertToDbValue(headerEx.Entity.ShipToAddressLine1));
            _db.AddParameterWithValue(cmd, "@shipToAddressLine2", ForesightUtil.ConvertToDbValue(headerEx.Entity.ShipToAddressLine2));
            _db.AddParameterWithValue(cmd, "@shipToCity", ForesightUtil.ConvertToDbValue(headerEx.Entity.ShipToCity));
        }

        private void saveSaleInvoiceLine(SaleInvoiceLine line)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertSaleInvoiceLine);
            setSaleInvoiceLineParams(cmd, line);
            cmd.ExecuteNonQuery();
        }

        private void setSaleInvoiceLineParams(IDbCommand cmd, SaleInvoiceLine line)
        {
            _db.AddParameterWithValue(cmd, "@InvoiceId", line.Entity.InvoiceId);
            _db.AddParameterWithValue(cmd, "@LineNr", line.Entity.LineNr);
            _db.AddParameterWithValue(cmd, "@ItemId", line.Item.Entity.Id);
            _db.AddParameterWithValue(cmd, "@ItemDescription", ForesightUtil.ConvertToDbValue(line.Entity.ItemDescription));
            _db.AddParameterWithValue(cmd, "@Quantity1", line.Entity.Quantity1);
            _db.AddParameterWithValue(cmd, "@Packing", line.Entity.Packing);
            _db.AddParameterWithValue(cmd, "@Quantity2", line.Entity.Quantity2);
            _db.AddParameterWithValue(cmd, "@Quantity3", line.Entity.Quantity3);
            _db.AddParameterWithValue(cmd, "@Price", ((SaleInvoiceLineEntity)line.Entity).Price);
            _db.AddParameterWithValue(cmd, "@DiscountPct", line.Entity.DiscountPct);
            _db.AddParameterWithValue(cmd, "@Amount", line.Entity.Amount);
        }

        private void saveSaleInvoiceTerm(SaleInvoiceTerm term)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertSaleInvoiceTerm);
            setSaleInvoiceTermParams(cmd, term);
            cmd.ExecuteNonQuery();
        }

        private void setSaleInvoiceTermParams(IDbCommand cmd, SaleInvoiceTerm term)
        {
            _db.AddParameterWithValue(cmd, "@InvoiceId", term.Entity.InvoiceId);
            _db.AddParameterWithValue(cmd, "@TermId", term.Entity.TermId);
            _db.AddParameterWithValue(cmd, "@Description", term.Entity.Description);
            _db.AddParameterWithValue(cmd, "@Percentage", term.Entity.Percentage);
            _db.AddParameterWithValue(cmd, "@Amount", term.Entity.Amount);
            _db.AddParameterWithValue(cmd, "@AccountId", term.Account.Entity.Id);
        }

        #endregion

        #region Purchase Invoice

        public void SavePurchaseInvoice(PurchaseInvoice invoice)
        {
            var id = savePurchaseHeader(invoice);
            invoice.SetIdentityValue(id);

            foreach (var line in invoice.Lines)
                savePurchaseInvoiceLine(line);

            foreach (var term in invoice.Terms)
                savePurchaseInvoiceTerm(term);
        }

        private string savePurchaseHeader(PurchaseInvoice header)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertPurchaseInvoiceHeader);
            setPurchaseInvoiceHeaderParams(cmd, header.Entity as PurchaseInvoiceEntity);
            cmd.ExecuteNonQuery();
            return _db.GetGeneratedIdentityValue();
        }

        private void setPurchaseInvoiceHeaderParams(IDbCommand cmd, PurchaseInvoiceEntity header)
        {
            setTransParams(cmd, header);
            _db.AddParameterWithValue(cmd, "@brokerageAmount", header.BrokerageAmount);
            _db.AddParameterWithValue(cmd, "@through", ForesightUtil.ConvertToDbValue(header.Through));
            _db.AddParameterWithValue(cmd, "@transport", ForesightUtil.ConvertToDbValue(header.Transport));
            _db.AddParameterWithValue(cmd, "@referenceDocNr", header.ReferenceDocNr);
            _db.AddParameterWithValue(cmd, "@orderId", header.OrderId);
            _db.AddParameterWithValue(cmd, "@discountPct", header.DiscountPct);
            _db.AddParameterWithValue(cmd, "@saleTaxColumnId", header.SaleTaxColumnId);
        }

        private void savePurchaseInvoiceLine(PurchaseInvoiceLine line)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertPurchaseInvoiceLine);
            setPurchaseInvoiceLineParams(cmd, line);
            cmd.ExecuteNonQuery();
        }

        private void setPurchaseInvoiceLineParams(IDbCommand cmd, PurchaseInvoiceLine line)
        {
            _db.AddParameterWithValue(cmd, "@InvoiceId", line.Entity.InvoiceId);
            _db.AddParameterWithValue(cmd, "@LineNr", line.Entity.LineNr);
            _db.AddParameterWithValue(cmd, "@ItemId", line.Item.Entity.Id);
            _db.AddParameterWithValue(cmd, "@ItemDescription", ForesightUtil.ConvertToDbValue(line.Entity.ItemDescription));
            _db.AddParameterWithValue(cmd, "@Quantity1", line.Entity.Quantity1);
            _db.AddParameterWithValue(cmd, "@Packing", line.Entity.Packing);
            _db.AddParameterWithValue(cmd, "@Quantity2", line.Entity.Quantity2);
            _db.AddParameterWithValue(cmd, "@Quantity3", line.Entity.Quantity3);
            _db.AddParameterWithValue(cmd, "@Cost", ((PurchaseInvoiceLineEntity)line.Entity).Cost);
            _db.AddParameterWithValue(cmd, "@DiscountPct", line.Entity.DiscountPct);
            _db.AddParameterWithValue(cmd, "@Amount", line.Entity.Amount);
        }

        private void savePurchaseInvoiceTerm(PurchaseInvoiceTerm term)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertPurchaseInvoiceTerm);
            setPurchaseInvoiceTermParams(cmd, term);
            cmd.ExecuteNonQuery();
        }

        private void setPurchaseInvoiceTermParams(IDbCommand cmd, PurchaseInvoiceTerm term)
        {
            _db.AddParameterWithValue(cmd, "@InvoiceId", term.Entity.InvoiceId);
            _db.AddParameterWithValue(cmd, "@TermId", term.Entity.TermId);
            _db.AddParameterWithValue(cmd, "@Description", term.Entity.Description);
            _db.AddParameterWithValue(cmd, "@Percentage", term.Entity.Percentage);
            _db.AddParameterWithValue(cmd, "@Amount", term.Entity.Amount);
            _db.AddParameterWithValue(cmd, "@AccountId", term.Account.Entity.Id);
        }

        #endregion

        #region Cash

        public void SaveCashPayment(CashPayment cashPayment)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertCashTransaction);
            setCashPaymentParams(cmd, cashPayment);
            cmd.ExecuteNonQuery();
        }

        private void setCashPaymentParams(IDbCommand cmd, CashPayment cashPayment)
        {
            setTransParams(cmd, cashPayment.Entity);
            _db.AddParameterWithValue(cmd, "@txnType", 1);
        }

        public void SaveCashReceipt(CashReceipt cashReceipt)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertCashTransaction);
            setCashReceiptParams(cmd, cashReceipt);
            cmd.ExecuteNonQuery();
        }

        private void setCashReceiptParams(IDbCommand cmd, CashReceipt cashReceipt)
        {
            setTransParams(cmd, cashReceipt.Entity);
            _db.AddParameterWithValue(cmd, "@txnType", 0);
        }

        #endregion

        #region Bank

        public void SaveBankPayment(BankPayment bankPayment)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertBankPayment);
            setBankPaymentParams(cmd, bankPayment);
            cmd.ExecuteNonQuery();
        }

        private void setBankPaymentParams(IDbCommand cmd, BankPayment bankPayment)
        {
            setTransParams(cmd, bankPayment.Entity);
            _db.AddParameterWithValue(cmd, "@chequeNr", ForesightUtil.ConvertToDbValue(((BankPaymentEntity)bankPayment.Entity).ChequeNr));
            _db.AddParameterWithValue(cmd, "@isRealised", ((BankPaymentEntity)bankPayment.Entity).IsRealised);
        }

        public void SaveBankReceipt(BankReceipt bankReceipt)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertBankReceipt);
            setBankReceiptParams(cmd, bankReceipt);
            cmd.ExecuteNonQuery();
        }

        private void setBankReceiptParams(IDbCommand cmd, BankReceipt bankReceipt)
        {
            setTransParams(cmd, bankReceipt.Entity);
            _db.AddParameterWithValue(cmd, "@chequeNr", ForesightUtil.ConvertToDbValue(((BankReceiptEntity)bankReceipt.Entity).ChequeNr));
            _db.AddParameterWithValue(cmd, "@bankBranchName", ForesightUtil.ConvertToDbValue(((BankReceiptEntity)bankReceipt.Entity).BankBranchName));
            _db.AddParameterWithValue(cmd, "@isRealised", ((BankReceiptEntity)bankReceipt.Entity).IsRealised);
        }

        #endregion

        #region Credit Note

        public void SaveCreditNote(CreditNote note)
        {
            var id = saveCreditNoteHeader(note.Header);
            note.SetIdentityValue(id);

            foreach (var line in note.Lines)
                saveCreditNoteLine(line);
        }

        private string saveCreditNoteHeader(CreditNoteHeader header)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertCreditNoteHeader);
            setTransParams(cmd, header);
            cmd.ExecuteNonQuery();
            return _db.GetGeneratedIdentityValue();
        }

        private void saveCreditNoteLine(CreditNoteLine line)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertCreditNoteLine);
            setCreditNoteLineParams(cmd, line);
            cmd.ExecuteNonQuery();
        }

        private void setCreditNoteLineParams(IDbCommand cmd, CreditNoteLine line)
        {
            _db.AddParameterWithValue(cmd, "@NoteId", line.NoteId);
            _db.AddParameterWithValue(cmd, "@LineNr", line.LineNr);
            _db.AddParameterWithValue(cmd, "@ItemId", line.Item.Entity.Id);
            _db.AddParameterWithValue(cmd, "@ItemDescription", ForesightUtil.ConvertToDbValue(line.ItemDescription));
            _db.AddParameterWithValue(cmd, "@Quantity1", line.Quantity1);
            _db.AddParameterWithValue(cmd, "@Packing", line.Packing);
            _db.AddParameterWithValue(cmd, "@Quantity2", line.Quantity2);
            _db.AddParameterWithValue(cmd, "@Quantity3", line.Quantity3);
            _db.AddParameterWithValue(cmd, "@Cost", line.Cost);
            _db.AddParameterWithValue(cmd, "@DiscountPct", line.DiscountPct);
            _db.AddParameterWithValue(cmd, "@Amount", line.Amount);
        }

        #endregion

        #region Debit Note

        public void SaveDebitNote(DebitNote note)
        {
            var id = saveDebitNoteHeader(note.Header);
            note.SetIdentityValue(id);

            foreach (var line in note.Lines)
                saveDebitNoteLine(line);
        }

        private string saveDebitNoteHeader(DebitNoteHeader header)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertDebitNoteHeader);
            setTransParams(cmd, header);
            cmd.ExecuteNonQuery();
            return _db.GetGeneratedIdentityValue();
        }

        private void saveDebitNoteLine(DebitNoteLine line)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertDebitNoteLine);
            setDebitNoteLineParams(cmd, line);
            cmd.ExecuteNonQuery();
        }

        private void setDebitNoteLineParams(IDbCommand cmd, DebitNoteLine line)
        {
            _db.AddParameterWithValue(cmd, "@NoteId", line.NoteId);
            _db.AddParameterWithValue(cmd, "@LineNr", line.LineNr);
            _db.AddParameterWithValue(cmd, "@ItemId", line.Item.Entity.Id);
            _db.AddParameterWithValue(cmd, "@ItemDescription", ForesightUtil.ConvertToDbValue(line.ItemDescription));
            _db.AddParameterWithValue(cmd, "@Quantity1", line.Quantity1);
            _db.AddParameterWithValue(cmd, "@Packing", line.Packing);
            _db.AddParameterWithValue(cmd, "@Quantity2", line.Quantity2);
            _db.AddParameterWithValue(cmd, "@Quantity3", line.Quantity3);
            _db.AddParameterWithValue(cmd, "@Price", line.Price);
            _db.AddParameterWithValue(cmd, "@DiscountPct", line.DiscountPct);
            _db.AddParameterWithValue(cmd, "@Amount", line.Amount);
        }

        #endregion

        #region Transaction Common

        private void setTransParams(IDbCommand cmd, TransactionHeaderEntity t)
        {
            cmd.Parameters.Clear();
            _db.AddParameterWithValue(cmd, "@daybookId", t.DaybookId);
            _db.AddParameterWithValue(cmd, "@documentNr", t.DocumentNr);
            _db.AddParameterWithValue(cmd, "@date", t.Date);
            _db.AddParameterWithValue(cmd, "@accountId", t.AccountId);
            _db.AddParameterWithValue(cmd, "@brokerId", t.BrokerId);
            _db.AddParameterWithValue(cmd, "@amount", t.Amount);
            _db.AddParameterWithValue(cmd, "@isAdjusted", t.IsAdjusted);
            _db.AddParameterWithValue(cmd, "@notes", ForesightUtil.ConvertToDbValue(t.Notes));
        }

        #endregion

        #region Journal Voucher

        public void SaveJournalVoucher(JournalVoucher jv)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertJournalVoucher);
            setJournalVoucherParams(cmd, jv);
            cmd.ExecuteNonQuery();
        }

        private void setJournalVoucherParams(IDbCommand cmd, JournalVoucher jv)
        {
            setTransParams(cmd, jv.Entity);
            _db.AddParameterWithValue(cmd, "@txnType", (jv.Entity as JournalVoucherEntity).TxnType);
        }

        #endregion

        #region Item Lot

        public ItemLot GetItemLotByLotNrLineNr(string lotNr, int lineNr)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectLotByLotNrAndLineNr);
            _db.AddParameterWithValue(cmd, "@lotNr", lotNr);
            _db.AddParameterWithValue(cmd, "@lineNr", lineNr);
            var rdr = cmd.ExecuteReader();
            var result = readItemLotInfo(rdr);
            rdr.Close();
            return result;
        }

        private ItemLot readItemLotInfo(IDataReader rdr)
        {
            if (!rdr.Read())
                return null;

            var lot = new ItemLot();
            lot.Id = rdr["Id"].ToString();
            lot.LotNr = rdr["LotNr"].ToString();
            lot.Date = Convert.ToDateTime(rdr["Date"]);
            lot.Account = GetAccountById(rdr["AccountId"].ToString());
            lot.LineNr = Convert.ToInt32(rdr["LineNr"]);
            lot.Item = GetItemById(Convert.ToInt32(rdr["ItemId"]));
            lot.Quantity1 = Convert.ToDouble(rdr["Quantity1"]);
            lot.Packing = Convert.ToDouble(rdr["Packing"]);
            lot.Quantity2 = Convert.ToDouble(rdr["Quantity2"]);
            lot.Quantity3 = Convert.ToDouble(rdr["Quantity3"]);
            lot.IsClosed = rdr["IsClosed"] != DBNull.Value && Convert.ToBoolean(rdr["IsClosed"]);
            return lot;
        }

        public void SaveItemLot(ItemLot lot)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertItemLot);
            setItemLotParams(cmd, lot);
            cmd.ExecuteNonQuery();
        }

        private void setItemLotParams(IDbCommand cmd, ItemLot lot)
        {
            _db.AddParameterWithValue(cmd, "@daybookId", 0);
            _db.AddParameterWithValue(cmd, "@LotNr", lot.LotNr);
            _db.AddParameterWithValue(cmd, "@Date", lot.Date);
            _db.AddParameterWithValue(cmd, "@AccountId", lot.Account.Entity.Id);
            _db.AddParameterWithValue(cmd, "@LineNr", lot.LineNr);
            _db.AddParameterWithValue(cmd, "@ItemId", lot.Item.Entity.Id);
            _db.AddParameterWithValue(cmd, "@Quantity1", lot.Quantity1);
            _db.AddParameterWithValue(cmd, "@Packing", lot.Packing);
            _db.AddParameterWithValue(cmd, "@Quantity2", lot.Quantity2);
            _db.AddParameterWithValue(cmd, "@Quantity3", lot.Quantity3);
        }

        #endregion

        #region Inventory Issue

        public InventoryIssue GetInventoryIssueByDocNr(string documentNr)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectInventoryIssueByDocNr);
            _db.AddParameterWithValue(cmd, "@documentNr", documentNr);
            var rdr = cmd.ExecuteReader();
            var result = readInventoryIssue(rdr);
            rdr.Close();
            return result;
        }

        private InventoryIssue readInventoryIssue(IDataReader rdr)
        {
            if (!rdr.Read())
                return null;

            var issue = new InventoryIssue();
            issue.Id = rdr["Id"].ToString();
            issue.DocumentNr = rdr["DocumentNr"].ToString();
            issue.Date = Convert.ToDateTime(rdr["Date"]);
            issue.LotId = ForesightUtil.ConvertDbNullToString(rdr["LotId"]);
            issue.Account = GetAccountById(rdr["AccountId"].ToString());
            issue.Quantity1 = Convert.ToDouble(rdr["Quantity1"]);
            issue.Quantity2 = Convert.ToDouble(rdr["Quantity2"]);
            issue.Quantity3 = Convert.ToDouble(rdr["Quantity3"]);
            return issue;
        }

        public void SaveInventoryIssue(InventoryIssue issue)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertInventoryIssue);
            setInventoryIssueParams(cmd, issue);
            cmd.ExecuteNonQuery();
        }

        private void setInventoryIssueParams(IDbCommand cmd, InventoryIssue issue)
        {
            _db.AddParameterWithValue(cmd, "@daybookId", issue.Daybook.Entity.Id);
            _db.AddParameterWithValue(cmd, "@DocumentNr", issue.DocumentNr);
            _db.AddParameterWithValue(cmd, "@Date", issue.Date);
            _db.AddParameterWithValue(cmd, "@LotId", issue.LotId);
            _db.AddParameterWithValue(cmd, "@AccountId", issue.Account.Entity.Id);
            _db.AddParameterWithValue(cmd, "@Quantity1", issue.Quantity1);
            _db.AddParameterWithValue(cmd, "@Quantity2", issue.Quantity2);
            _db.AddParameterWithValue(cmd, "@Quantity3", issue.Quantity3);
        }

        #endregion

        #region Inventory Receive

        public void SaveInventoryReceive(InventoryReceive receive)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertInventoryReceive);
            setInventoryReceiveParams(cmd, receive);
            cmd.ExecuteNonQuery();
        }

        private void setInventoryReceiveParams(IDbCommand cmd, InventoryReceive receive)
        {
            cmd.Parameters.Clear();
            _db.AddParameterWithValue(cmd, "@daybookId", 0);
            _db.AddParameterWithValue(cmd, "@DocumentNr", receive.DocumentNr);
            _db.AddParameterWithValue(cmd, "@Date", receive.Date);
            _db.AddParameterWithValue(cmd, "@IssueId", receive.Issue.Id);
            _db.AddParameterWithValue(cmd, "@LineNr", receive.LineNr);
            _db.AddParameterWithValue(cmd, "@ItemId", receive.Item.Entity.Id);
            _db.AddParameterWithValue(cmd, "@Quantity1", receive.Quantity1);
            _db.AddParameterWithValue(cmd, "@Packing", receive.Packing);
            _db.AddParameterWithValue(cmd, "@Quantity2", receive.Quantity2);
            _db.AddParameterWithValue(cmd, "@Quantity3", receive.Quantity3);
        }

        #endregion

        #region Misc. Material Issue

        public void SaveMiscMaterialIssue(MiscMaterialIssue issue)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertMiscInventoryIssue);
            setMiscMaterialIssueParams(cmd, issue);
            cmd.ExecuteNonQuery();
        }

        private void setMiscMaterialIssueParams(IDbCommand cmd, MiscMaterialIssue issue)
        {
            _db.AddParameterWithValue(cmd, "@daybookId", issue.Daybook.Entity.Id);
            _db.AddParameterWithValue(cmd, "@DocumentNr", issue.DocumentNr);
            _db.AddParameterWithValue(cmd, "@Date", issue.Date);
            _db.AddParameterWithValue(cmd, "@LineNr", issue.LineNr);
            _db.AddParameterWithValue(cmd, "@ItemId", issue.Item.Entity.Id);
            _db.AddParameterWithValue(cmd, "@Quantity1", issue.Quantity1);
            _db.AddParameterWithValue(cmd, "@Quantity2", issue.Quantity2);
            _db.AddParameterWithValue(cmd, "@Quantity3", issue.Quantity3);
        }

        #endregion

        #region Account Ledger

        public IDataReader ReadLedgerData(AccountTransTables tran, int cpId)
        {
            if (tran.TransName == "Opening")
            {
                return _db.ExecuteReader(SqlQueries.SelectMonthlyOpeningBalanceByAccount,
                                        "@companyPeriodId", cpId);
            }

            return _db.ExecuteReader(string.Format(SqlQueries.SelectMonthlySumOfTransByAccount,
                              tran.TableName, getTransDimensionFilter(tran)), "@companyPeriodId", cpId);
        }

        private string getTransDimensionFilter(AccountTransTables trans)
        {
            return string.IsNullOrEmpty(trans.Filter) ? "" : " AND " + trans.Filter;
        }

        public void InsertAccountLedger(AccountMonthlyLedger account)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertAccountLedger);
            _db.AddParameterWithValue(cmd, "@accountId", account.AccountId);
            _db.AddParameterWithValue(cmd, "@chartOfAccountId", account.ChartOfAccountId);
            _db.AddParameterWithValue(cmd, "@month", account.Month);
            _db.AddParameterWithValue(cmd, "@opening", account.Opening);
            _db.AddParameterWithValue(cmd, "@sale", account.Sale);
            _db.AddParameterWithValue(cmd, "@cashPayment", account.CashPayment);
            _db.AddParameterWithValue(cmd, "@bankPayment", account.BankPayment);
            _db.AddParameterWithValue(cmd, "@debitNote", account.DebitNote);
            _db.AddParameterWithValue(cmd, "@debitJV", account.DebitJV);
            _db.AddParameterWithValue(cmd, "@purchase", account.Purchase);
            _db.AddParameterWithValue(cmd, "@cashReceipt", account.CashReceipt);
            _db.AddParameterWithValue(cmd, "@bankReceipt", account.BankReceipt);
            _db.AddParameterWithValue(cmd, "@creditNote", account.CreditNote);
            _db.AddParameterWithValue(cmd, "@creditJV", account.CreditJV);
            _db.AddParameterWithValue(cmd, "@periodId", account.CompanyPeriod.Foresight.PeriodId);
            _db.AddParameterWithValue(cmd, "@companyId", account.CompanyPeriod.Foresight.CompanyId);
            _db.AddParameterWithValue(cmd, "@companyPeriodId", account.CompanyPeriod.Foresight.Id);
            cmd.ExecuteNonQuery();
            account.Id = _db.GetGeneratedIdentityValue();
        }

        #endregion

        #region Account

        public decimal GetAccountOpeningBalance(string id)
        {
            var value = _db.ExecuteScalar(string.Format(
                                            ReportQueries.SelectAccountOpeningBalance, ""),
                                            "@accountId", id);
            return value == DBNull.Value ? 0 : Convert.ToDecimal(value);
        }

        public decimal GetAccountOpeningBalance(string accountId, string periodId)
        {
            var cmd = _db.CreateCommand(string.Format(
                                            ReportQueries.SelectAccountOpeningBalance,
                                            "AND PeriodId = @periodId"));

            _db.AddParameterWithValue(cmd, "@accountId", accountId);
            _db.AddParameterWithValue(cmd, "@periodId", periodId);
            var value = cmd.ExecuteScalar();
            return value == DBNull.Value ? 0 : Convert.ToDecimal(value);
        }

        public IList<KeyValuePair<string, decimal>> GetAccountBalances(bool partyGrouping)
        {
            var result = new List<KeyValuePair<string, decimal>>();
            var rdr = _db.ExecuteReader(string.Format(SqlQueries.SelectAllAccountBalances, getIdentityColumn(partyGrouping)));
            while (rdr.Read())
            {
                result.Add(new KeyValuePair<string, decimal>(
                                rdr["AccountId"].ToString(),
                                Convert.ToDecimal(rdr["Amount"]))
                          );
            }

            rdr.Close();
            return result;
        }

        private string getIdentityColumn(bool partyGrouping)
        {
            return partyGrouping ? "GroupId" : "Id";
        }

        public Account GetAccountById(string id)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectAccountById);
            _db.AddParameterWithValue(cmd, "@id", id);
            return readAccountHelper(cmd.ExecuteReader());
        }

        public Account GetAccountByNameAndAddress(AccountEntity account)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectAccountByNameAndAddress);
            _db.AddParameterWithValue(cmd, "@name", account.Name);
            _db.AddParameterWithValue(cmd, "@addressLine1", account.AddressLine1);
            _db.AddParameterWithValue(cmd, "@addressLine2", account.AddressLine2);
            _db.AddParameterWithValue(cmd, "@city", account.City);
            _db.AddParameterWithValue(cmd, "@state", account.State);
            _db.AddParameterWithValue(cmd, "@pin", account.Pin);
            return readAccountHelper(cmd.ExecuteReader());
        }

        private Account readAccountHelper(IDataReader rdr)
        {
            using (rdr) return readAccount(rdr);
        }

        private Account readAccount(IDataReader rdr)
        {
            if (!rdr.Read())
                return null;

            var account = new Account(new AccountEntity());
            fillAccount(rdr, account);

            if (account.Entity.GroupId != account.Entity.Id)
                account.Group = GetAccountById(account.Entity.GroupId);

            account.ChartOfAccount = GetChartOfAccountById(account.Entity.ChartOfAccountId);
            return account;
        }

        private void fillAccount(IDataReader rdr, Account account)
        {
            account.Entity.Id = rdr["Id"].ToString();
            account.Entity.Name = rdr["name"].ToString();
            account.Entity.GroupId = ForesightUtil.ConvertDbNullToString(rdr["GroupId"]);
            account.Entity.ChartOfAccountId = ForesightUtil.ConvertDbNullToString(rdr["ChartOfAccountId"]);
            account.Entity.AddressLine1 = rdr["addressLine1"].ToString();
            account.Entity.AddressLine2 = rdr["addressLine2"].ToString();
            account.Entity.City = rdr["city"].ToString();
            account.Entity.State = rdr["state"].ToString();
            account.Entity.Pin = rdr["pin"].ToString();
            account.Entity.IsActive = Convert.ToBoolean(rdr["IsActive"]);
        }

        public void SaveAccount(AccountEntity account)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertAccount);
            setAccountParams(cmd, account);
            cmd.ExecuteNonQuery();
            account.Id = _db.GetGeneratedIdentityValue();

            if (string.IsNullOrWhiteSpace(account.GroupId))
                updateAccountGroupId(account.Id);
        }

        private void setAccountParams(IDbCommand cmd, AccountEntity account)
        {
            _db.AddParameterWithValue(cmd, "@groupId", account.GroupId);
            _db.AddParameterWithValue(cmd, "@chartOfAccountId", account.ChartOfAccountId);
            _db.AddParameterWithValue(cmd, "@name", ForesightUtil.ConvertToDbValue(account.Name));
            _db.AddParameterWithValue(cmd, "@addressLine1", ForesightUtil.ConvertToDbValue(account.AddressLine1));
            _db.AddParameterWithValue(cmd, "@addressLine2", ForesightUtil.ConvertToDbValue(account.AddressLine2));
            _db.AddParameterWithValue(cmd, "@city", ForesightUtil.ConvertToDbValue(account.City));
            _db.AddParameterWithValue(cmd, "@state", ForesightUtil.ConvertToDbValue(account.State));
            _db.AddParameterWithValue(cmd, "@pin", ForesightUtil.ConvertToDbValue(account.Pin));
            _db.AddParameterWithValue(cmd, "@contactId", account.PartyId);
            _db.AddParameterWithValue(cmd, "@isActive", account.IsActive);
        }

        private void updateAccountGroupId(string id)
        {
            _db.ExecuteNonQuery(SqlQueries.UpdateAccountGroupId, "@Id", id);
        }

        public IList<Account> GetAccounts(AccountTypes accountTypes, bool partyGrouping)
        {
            var result = new List<Account>();
            var reader = _db.ExecuteReader(getSelectAccountsQuery(accountTypes, partyGrouping));

            while (reader.Read())
                result.Add(readAccountInfo(reader));

            reader.Close();
            return result;
        }

        private string getSelectAccountsQuery(AccountTypes accountTypes, bool partyGrouping)
        {
            var sb = new StringBuilder();
            var coaId = GetChartOfAccountIds(accountTypes);

            if (!string.IsNullOrEmpty(coaId))
                sb.Append(string.Format(" ca.Nr {0} ", coaId));

            if (partyGrouping)
            {
                if (!string.IsNullOrEmpty(sb.ToString()))
                    sb.Append(" AND ");

                sb.Append(" a.Id = a.GroupId ");
            }

            if (!string.IsNullOrEmpty(sb.ToString()))
                sb.Append(" AND ");

            sb.Append(" a.Id NOT IN (SELECT AccountId FROM Daybook) ");

            var result = "";
            if (sb.Length > 0)
                result = " WHERE " + sb;

            return string.Format(SqlQueries.SelectAllAccounts, result);
        }

        public string GetChartOfAccountIds(AccountTypes accountTypes)
        {
            return GetChartOfAccountIds((int)accountTypes);
        }

        public string GetChartOfAccountIds(int coaId)
        {
            var coPeriods = GetCompanyPeriods();
            if (coPeriods.Count == 0 || coaId == 0)
                return " NOT IN ('') ";

            var sb = new StringBuilder(" IN (");
            var ids = GetChartOfAccountIDsFor(coaId);
            foreach (var id in ids)
                sb.Append(String.Format("'{0}',", id));

            return sb.Remove(sb.Length - 1, 1).Append(") ").ToString();
        }

        private Account readAccountInfo(IDataReader rdr)
        {
            var account = new Account(new AccountEntity());
            fillAccount(rdr, account);
            return account;
        }

        #endregion

        #region Chart of Account

        public IList<ChartOfAccount> GetChartOfAccounts()
        {
            var result = new List<ChartOfAccount>();
            using (var rdr = _db.ExecuteReader(SqlQueries.SelectAllChartOfAccounts))
            {
                while (rdr.Read())
                    result.Add(readChartOfAccount(rdr));

                return result;
            }
        }

        public ChartOfAccount GetChartOfAccountById(string id)
        {
            var cmd = _db.CreateCommand();
            cmd.CommandText = SqlQueries.SelectChartOfAccountById;
            cmd.Parameters.Clear();
            _db.AddParameterWithValue(cmd, "@Id", id);
            return readChartOfAccountHelper(cmd.ExecuteReader());
        }

        public ChartOfAccount GetChartOfAccountByNr(string nr)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectChartOfAccountByNr);
            _db.AddParameterWithValue(cmd, "@nr", nr);
            return readChartOfAccountHelper(cmd.ExecuteReader());
        }

        public List<TrialBalance> GetTrialBalances()
        {
            var result = new List<TrialBalance>();
            var rdr = _db.ExecuteReader(
                            string.Format(ReportQueries.SelectAllTrailBalances,
                                AccountTransTables.GetCreditAmountExpr(),
                                AccountTransTables.GetDebitAmountExpr()));
            while (rdr.Read())
                result.Add(readTrialBalanceData(rdr));

            rdr.Close();
            return result;
        }

        private TrialBalance readTrialBalanceData(IDataReader rdr)
        {
            return new TrialBalance
            {
                AccountId = ForesightUtil.ConvertDbNullToString(rdr["AccountId"]),
                ChartOfAccountName = rdr["ChartOfAccountName"].ToString(),
                AccountName = rdr["AccountName"].ToString(),
                Opening = Convert.ToDecimal(ForesightUtil.ConvertDbNull(rdr["Opening"])),
                TransactionCredit = Convert.ToDecimal(ForesightUtil.ConvertDbNull(rdr["CrAmt"])),
                TransactionDebit = Convert.ToDecimal(ForesightUtil.ConvertDbNull(rdr["DbAmt"])),
                Closing = Convert.ToDecimal(ForesightUtil.ConvertDbNull(rdr["Closing"]))
            };
        }

        private ChartOfAccount readChartOfAccountHelper(IDataReader rdr)
        {
            using (rdr)
            {
                if (!rdr.Read())
                    return null;

                return readChartOfAccount(rdr);
            }
        }

        private ChartOfAccount readChartOfAccount(IDataReader rdr)
        {
            var coa = new ChartOfAccount(new ChartOfAccountEntity());
            coa.Entity.Id = rdr["Id"].ToString();
            coa.Entity.Nr = Convert.ToInt32(rdr["Nr"]);
            var parentId = Convert.ToInt32(ForesightUtil.ConvertDbNull(rdr["ParentId"]));
            if (parentId != 0)
                coa.Parent = getChartOfAccountParent(parentId);

            coa.Entity.Name = rdr["Name"].ToString();
            return coa;
        }

        private ChartOfAccount getChartOfAccountParent(int parentId)
        {
            var rdr = _db.ExecuteReader(SqlQueries.SelectChartOfAccountByParentId, "@parentId", parentId);
            return readChartOfAccountHelper(rdr);
        }

        public void SaveChartOfAccount(ChartOfAccount coa)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertChartOfAccount);
            setChartOfAccountParams(cmd, coa);
            cmd.ExecuteNonQuery();
            coa.Entity.Id = _db.GetGeneratedIdentityValue();
        }

        private void setChartOfAccountParams(IDbCommand cmd, ChartOfAccount coa)
        {
            _db.AddParameterWithValue(cmd, "@nr", coa.Entity.Nr);
            _db.AddParameterWithValue(cmd, "@parentId", getChartOfAccountParentId(coa));
            _db.AddParameterWithValue(cmd, "@name", coa.Entity.Name);
        }

        private string getChartOfAccountParentId(ChartOfAccount coa)
        {
            return coa.Parent == null ? "0" : coa.Parent.Entity.Id;
        }

        public IList<int> GetChartOfAccountIDsFor(int parentId)
        {
            var result = new List<int>();
            result.Add(parentId);
            var rdr = _db.ExecuteReader(SqlQueries.SelectChartOfAccountIdsByParentId, "@parentId", parentId);
            while (rdr.Read())
            {
                var id = Convert.ToInt32(rdr["Id"]);
                result.Add(id);
                result.AddRange(GetChartOfAccountIDsFor(id));
            }

            rdr.Close();
            return result.Distinct().ToList();
        }

        #endregion

        #region Daybook

        public IList<Daybook> GetDaybooks()
        {
            var daybooks = new List<Daybook>();
            using (var rdr = _db.ExecuteReader(SqlQueries.SelectAllDaybooks))
            {
                while (rdr.Read())
                    daybooks.Add(readDaybook(rdr));

                return daybooks;
            }
        }

        public Daybook GetDaybookByCode(string code)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectDaybookByCode);
            _db.AddParameterWithValue(cmd, "@code", code);
            return readDaybookHelper(cmd.ExecuteReader());
        }

        private Daybook readDaybookHelper(IDataReader rdr)
        {
            Daybook daybook = null;
            if (rdr.Read())
                daybook = readDaybook(rdr);

            rdr.Close();
            return daybook;
        }

        private Daybook readDaybook(IDataReader rdr)
        {
            var book = new Daybook(new DaybookEntity());
            book.Entity.Id = rdr["Id"].ToString();
            book.Entity.Type = (DaybookType)Convert.ToInt32(rdr["Type"]);
            book.Entity.Code = rdr["Code"].ToString();
            book.Entity.Name = rdr["Name"].ToString();

            if (book.Entity.Type != DaybookType.JournalVoucher)
            {
                book.Account = GetAccountById(rdr["AccountId"].ToString());
                book.Entity.AccountId = book.Account.Entity.Id;
            }

            return book;
        }

        public void SaveDaybook(Daybook book)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertDaybook);
            setDaybookParams(cmd, book);
            cmd.ExecuteNonQuery();
            book.Entity.Id = _db.GetGeneratedIdentityValue();
        }

        private void setDaybookParams(IDbCommand cmd, Daybook book)
        {
            _db.AddParameterWithValue(cmd, "@type", ((int)book.Entity.Type).ToString());
            _db.AddParameterWithValue(cmd, "@code", book.Entity.Code);
            _db.AddParameterWithValue(cmd, "@name", book.Entity.Name);
            _db.AddParameterWithValue(cmd, "@accountId", getDaybookAccountId(book));
        }

        private string getDaybookAccountId(Daybook book)
        {
            return book.Entity.Type == DaybookType.JournalVoucher
                                        ? string.Empty
                                        : book.Account.Entity.Id;
        }

        public int GetDaybookIdOfAccount(string accountId)
        {
            var value = _db.ExecuteScalar(SqlQueries.SelectDaybookIdOfAccount, "@accountId", accountId);
            return value != null ? Convert.ToInt32(value) : 0;
        }

        public Daybook GetDaybookOfAccount(string accountId)
        {
            var reader = _db.ExecuteReader(SqlQueries.SelectDaybookOfAccount, "@accountId", accountId);
            return readDaybookHelper(reader);
        }

        #endregion

        #region Item

        public Item GetItemById(int id)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectItemById);
            _db.AddParameterWithValue(cmd, "@id", id);
            return readItemHelper(cmd.ExecuteReader());
        }

        public Item GetItemByName(string name)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectItemByName);
            _db.AddParameterWithValue(cmd, "@name", name);
            return readItemHelper(cmd.ExecuteReader());
        }

        private Item readItemHelper(IDataReader rdr)
        {
            var result = readItem(rdr);
            rdr.Close();
            return result;
        }

        private Item readItem(IDataReader rdr)
        {
            if (!rdr.Read())
                return null;

            var item = new Item(new ItemEntity());
            item.Entity.Id = rdr["Id"].ToString();
            item.Group = GetItemGroupById(Convert.ToInt32(rdr["GroupId"]));
            item.Entity.Name = rdr["Name"].ToString();
            item.Entity.ShortName = rdr["ShortName"].ToString();
            item.Category = GetItemCategoryById(Convert.ToInt32(ForesightUtil.ConvertDbNull(rdr["CategoryId"])));
            item.Entity.HasBom = Convert.ToBoolean(rdr["HasBom"]);
            item.Entity.IsActive = Convert.ToBoolean(rdr["IsActive"]);
            return item;
        }

        public void SaveItem(Item item)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertItem);
            setItemParams(cmd, item);
            cmd.ExecuteNonQuery();
            item.Entity.Id = _db.GetGeneratedIdentityValue();
        }

        private void setItemParams(IDbCommand cmd, Item item)
        {
            _db.AddParameterWithValue(cmd, "@groupId", Convert.ToInt32(item.Group.Entity.Id));
            _db.AddParameterWithValue(cmd, "@name", item.Entity.Name);
            _db.AddParameterWithValue(cmd, "@shortName", ForesightUtil.ConvertToDbValue(item.Entity.ShortName));
            _db.AddParameterWithValue(cmd, "@categoryId", item.Category.Entity.Id);
            _db.AddParameterWithValue(cmd, "@hasBom", item.Entity.HasBom);
            _db.AddParameterWithValue(cmd, "@isActive", item.Entity.IsActive);
        }

        #endregion

        #region Item Category

        public ItemCategory GetItemCategoryById(int id)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectItemCategoryById);
            _db.AddParameterWithValue(cmd, "@id", id);
            return readItemCategoryHelper(cmd.ExecuteReader());
        }

        public ItemCategory GetItemCategoryByName(string name)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectItemCategoryByName);
            _db.AddParameterWithValue(cmd, "@name", name);
            return readItemCategoryHelper(cmd.ExecuteReader());
        }

        private ItemCategory readItemCategoryHelper(IDataReader rdr)
        {
            var result = readItemCategory(rdr);
            rdr.Close();
            return result;
        }

        private ItemCategory readItemCategory(IDataReader rdr)
        {
            if (!rdr.Read())
                return null;

            var ic = new ItemCategory(new ItemCategoryEntity());
            ic.Entity.Id = rdr["Id"].ToString();
            ic.Entity.Name = rdr["Name"].ToString();
            return ic;
        }

        public void SaveItemCategory(ItemCategory ic)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertItemCategory);
            _db.AddParameterWithValue(cmd, "@name", ic.Entity.Name);
            cmd.ExecuteNonQuery();
            ic.Entity.Id = _db.GetGeneratedIdentityValue();
        }

        #endregion

        #region Item Group

        public ItemGroup GetItemGroupById(int id)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectItemGroupById);
            _db.AddParameterWithValue(cmd, "@id", id);
            return readItemGroupHelper(cmd.ExecuteReader());
        }

        public ItemGroup GetItemGroupByName(string name)
        {
            var cmd = _db.CreateCommand(SqlQueries.SelectItemGroupByName);
            _db.AddParameterWithValue(cmd, "@name", name);
            return readItemGroupHelper(cmd.ExecuteReader());
        }

        private ItemGroup readItemGroupHelper(IDataReader rdr)
        {
            var result = readItemGroup(rdr);
            rdr.Close();
            return result;
        }

        private ItemGroup readItemGroup(IDataReader rdr)
        {
            if (!rdr.Read())
                return null;

            var ig = new ItemGroup(new ItemGroupEntity());
            ig.Entity.Id = rdr["Id"].ToString();
            ig.Entity.Name = rdr["Name"].ToString();
            ig.Entity.ParentId = ForesightUtil.ConvertDbNullToString(rdr["ParentId"]);
            return ig;
        }

        public void SaveItemGroup(ItemGroup ig)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertItemGroup);
            setItemGroupParams(cmd, ig);
            cmd.ExecuteNonQuery();
            ig.Entity.Id = _db.GetGeneratedIdentityValue();
        }

        private void setItemGroupParams(IDbCommand cmd, ItemGroup ig)
        {
            _db.AddParameterWithValue(cmd, "@parentId", ig.Entity.ParentId);
            _db.AddParameterWithValue(cmd, "@name", ig.Entity.Name);
        }

        #endregion

        #region Item Ledger

        public IDataReader ReadItemLedger(ItemTransTables tran, int cpId)
        {
            return _db.ExecuteReader(string.Format(
                SqlQueries.SelectMonthlySumOfTransByItemAndAccount,
                tran.HeaderTableName, tran.DetailTableName), "@companyPeriodId", cpId);
        }

        public void InsertItemLedger(ItemMonthlyLedger item)
        {
            var cmd = _db.CreateCommand(SqlQueries.InsertItemLedger);
            _db.AddParameterWithValue(cmd, "@itemId", item.ItemId);
            _db.AddParameterWithValue(cmd, "@accountId", item.AccountId);
            _db.AddParameterWithValue(cmd, "@chartOfAccountId", item.ChartOfAccountId);
            _db.AddParameterWithValue(cmd, "@month", item.Month);
            _db.AddParameterWithValue(cmd, "@sale", item.Sale);
            _db.AddParameterWithValue(cmd, "@purchase", item.Purchase);
            _db.AddParameterWithValue(cmd, "@periodId", item.CompanyPeriod.Foresight.PeriodId);
            _db.AddParameterWithValue(cmd, "@companyId", item.CompanyPeriod.Foresight.CompanyId);
            _db.AddParameterWithValue(cmd, "@companyPeriodId", item.CompanyPeriod.Foresight.Id);
            cmd.ExecuteNonQuery();
            item.Id = _db.GetGeneratedIdentityValue();
        }

        #endregion

        #region Database Context

        public void BeginTransaction()
        {
            _db.BeginTransaction();
        }

        public void Commit()
        {
            _db.Commit();
        }

        public void Rollback()
        {
            _db.Rollback();
        }

        public void Dispose()
        {
            Close();
        }

        public void Close()
        {
            _db.Close();
        }

        #endregion
    }
}
