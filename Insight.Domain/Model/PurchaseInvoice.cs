using System.Collections.Generic;
using System.Linq;
using Insight.Domain.Entities;
using Insight.Domain.Repositories;

namespace Insight.Domain.Model
{
    public class PurchaseInvoice : TransactionHeader
    {
        public SaleOrder Order { get; set; }
        public SaleTaxColumn SaleTaxColumn { get; set; }
        public IList<PurchaseInvoiceLine> Lines { get; set; }
        public IList<PurchaseInvoiceTerm> Terms { get; set; }

        public PurchaseInvoice(PurchaseInvoiceEntity entity)
        {
            Entity = entity;
            Lines = new List<PurchaseInvoiceLine>();
            Terms = new List<PurchaseInvoiceTerm>();
        }

        public void SetIdentityValue(string id)
        {
            Entity.Id = id;

            foreach (var line in Lines)
                line.Entity.InvoiceId = id;

            foreach (var term in Terms)
                term.Entity.InvoiceId = id;
        }

        //public string GetNewDocumentNr()
        //{
        //    var repo = new InsightRepository();
        //    var docNr = repo.GetNewPurchaseInvoiceDocNr(Entity.DaybookId, CompanyPeriod.Entity.Id);
        //    return docNr.Trim().PadLeft(10);
        //}

        public override void Save()
        {
            ((PurchaseInvoiceEntity)Entity).LineEntities = Lines.Select(l => l.Entity as PurchaseInvoiceLineEntity).ToList();
            ((PurchaseInvoiceEntity)Entity).TermEntities = Terms.Select(t => t.Entity as PurchaseInvoiceTermEntity).ToList();

            base.Save();
        }

        public static PurchaseInvoice New()
        {
            return new PurchaseInvoice(new PurchaseInvoiceEntity());
        }

        protected override void SetDocumentNr()
        {
            if (!IsNew())
                return;

            var repo = new InsightRepository();
            var docNr = repo.GetNewPurchaseInvoiceDocNr(Entity.DaybookId, CompanyPeriod.Entity.Id);
            Entity.DocumentNr = docNr.Trim().PadLeft(10);
        }
    }
}
