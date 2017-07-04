using Insight.Domain.Entities;
using Insight.Domain.Repositories;

namespace Insight.Domain.Model
{
    public class BankPayment : TransactionHeader
    {
        public BankPayment(BankPaymentEntity entity)
        {
            Entity = entity;
        }

        public static BankPayment New()
        {
            return new BankPayment(new BankPaymentEntity());
        }

        protected override void SetDocumentNr()
        {
            if (!IsNew())
                return;

            var repo = new InsightRepository();
            var docNr = repo.GetNewBankPaymentDocNr(Entity.DaybookId, CompanyPeriod.Entity.Id);
            Entity.DocumentNr = docNr.Trim().PadLeft(10);
        }
    }
}
