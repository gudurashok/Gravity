using Insight.Domain.Entities;
using Insight.Domain.Repositories;

namespace Insight.Domain.Model
{
    public class JournalVoucher : TransactionHeader
    {
        public Account CreditAccount { get; set; }
        public Account DebitAccount { get; set; }

        public JournalVoucher(JournalVoucherEntity entity)
        {
            Entity = entity;
        }

        public static JournalVoucher New()
        {
            return new JournalVoucher(new JournalVoucherEntity());
        }

        protected override void SetDocumentNr()
        {
            if (!IsNew())
                return;

            var repo = new InsightRepository();
            Entity.DocumentNr = repo.GetNewJVDocNr();
        }
    }
}
