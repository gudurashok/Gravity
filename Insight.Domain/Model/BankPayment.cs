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
            Entity.DocumentNr = repo.GetNewBankPaymentDocNr();
        }
    }
}
