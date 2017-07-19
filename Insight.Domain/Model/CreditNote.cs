using Insight.Domain.Entities;
using Insight.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Insight.Domain.Model
{
    public class CreditNote : TransactionHeader
    {
        public IList<CreditNoteLine> Lines { get; set; }

        public CreditNote(CreditNoteEntity entity)
        {
            Entity = entity;
            Lines = new List<CreditNoteLine>();
        }

        public void SetIdentityValue(string id)
        {
            Entity.Id = id;

            foreach (var line in Lines)
                line.NoteId = id;
        }

        public static CreditNote New()
        {
            return new CreditNote(new CreditNoteEntity());
        }

        protected override void SetDocumentNr()
        {
            if (!IsNew())
                return;

            var repo = new InsightRepository();
            var docNr = repo.GetNewCreditNoteDocNr(Entity.DaybookId, CompanyPeriod.Entity.Id);
            Entity.DocumentNr = docNr.Trim().PadLeft(10);
        }
    }
}
