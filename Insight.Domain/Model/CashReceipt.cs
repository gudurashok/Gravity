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
            var docNr = repo.GetNewCashReceiptDocNr(Entity.DaybookId, CompanyPeriod.Entity.Id);
            Entity.DocumentNr = docNr.Trim().PadLeft(10);
        }
    }
}
