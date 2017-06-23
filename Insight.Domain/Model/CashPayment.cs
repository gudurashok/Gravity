using Insight.Domain.Entities;
using Insight.Domain.Repositories;

namespace Insight.Domain.Model
{
    public class CashPayment : TransactionHeader
    {
        public CashPayment(CashPaymentEntity entity)
        {
            Entity = entity;
        }

        public static CashPayment New()
        {
            return new CashPayment(new CashPaymentEntity());
        }

        protected override void SetDocumentNr()
        {
            if (!IsNew())
                return;
            
            var repo = new InsightRepository();
            Entity.DocumentNr = repo.GetNewCashPaymentDocNr();
        }
    }
}
