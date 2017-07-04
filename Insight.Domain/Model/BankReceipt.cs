using Insight.Domain.Entities;
using Insight.Domain.Repositories;

namespace Insight.Domain.Model
{
    public class BankReceipt : TransactionHeader
    {
        public BankReceipt(BankReceiptEntity entity)
        {
            Entity = entity;
        }

        public static BankReceipt New()
        {
            return new BankReceipt(new BankReceiptEntity());
        }

        protected override void SetDocumentNr()
        {
            if (!IsNew())
                return;

            var repo = new InsightRepository();
            var docNr = repo.GetNewBankReceiptDocNr(Entity.DaybookId, CompanyPeriod.Entity.Id);
            Entity.DocumentNr = docNr.Trim().PadLeft(10);
        }
    }
}
