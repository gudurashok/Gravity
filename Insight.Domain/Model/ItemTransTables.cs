using System.Collections.Generic;

namespace Insight.Domain.Model
{
    public class ItemTransTables
    {
        #region Public Declartions

        public string TransName { get; private set; }
        public string HeaderTableName { get; private set; }
        public string DetailTableName { get; private set; }

        #endregion

        #region Public Methods

        public static IEnumerable<ItemTransTables> GetAll()
        {
            var result = new List<ItemTransTables>();
            result.Add(new ItemTransTables
            {
                TransName = "Sale",
                HeaderTableName = "SaleInvoiceHeader",
                DetailTableName = "SaleInvoiceLine"
            });

            result.Add(new ItemTransTables
            {
                TransName = "Purchase",
                HeaderTableName = "PurchaseInvoiceHeader",
                DetailTableName = "PurchaseInvoiceLine"
            });
            return result;
        }

        #endregion
    }
}
