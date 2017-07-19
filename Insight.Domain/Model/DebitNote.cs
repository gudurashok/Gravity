using Insight.Domain.Entities;
using Insight.Domain.Repositories;
using System.Collections.Generic;

namespace Insight.Domain.Model
{
    public class DebitNote : TransactionHeader
    {
        public IList<DebitNoteLine> Lines { get; set; }

        public DebitNote(DebitNoteEntity entity)
        {
            Entity = entity;
            Lines = new List<DebitNoteLine>();
        }

        public void SetIdentityValue(string id)
        {
            Entity.Id = id;

            foreach (var line in Lines)
                line.NoteId = id;
        }

        public static DebitNote New()
        {
            return new DebitNote(new DebitNoteEntity());
        }

        protected override void SetDocumentNr()
        {
            if (!IsNew())
                return;

            var repo = new InsightRepository();
            var docNr = repo.GetNewDebitNoteDocNr(Entity.DaybookId, CompanyPeriod.Entity.Id);
            Entity.DocumentNr = docNr.Trim().PadLeft(10);
        }
    }
}
