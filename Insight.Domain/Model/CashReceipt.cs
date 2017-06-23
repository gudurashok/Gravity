using Insight.Domain.Entities;
using Insight.Domain.Repositories;

namespace Insight.Domain.Model
{
    public class CashReceipt : TransactionHeader
    {
        public CashReceipt(CashReceiptEntity entity)
        {
            Entity = entity;
        }

        public static CashReceipt New()
        {
            return new CashReceipt(new CashReceiptEntity());
        }

        protected override void SetDocumentNr()
        {
            if (!IsNew())
                return;

            var repo = new InsightRepository();
            Entity.DocumentNr = repo.GetNewCashReceiptDocNr();
        }
    }
}
