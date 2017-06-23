using System.Collections.Generic;
using System.Linq;
using Insight.Domain.Entities;
using Insight.Domain.Repositories;

namespace Insight.Domain.Model
{
    public class SaleInvoice : TransactionHeader
    {
        public Vehicle Vehicle { get; set; }
        public SaleOrder Order { get; set; }
        public SaleTaxColumn SaleTaxColumn { get; set; }
        public IList<SaleInvoiceLine> Lines { get; set; }
        public IList<SaleInvoiceTerm> Terms { get; set; }


        public SaleInvoiceHeaderEx HeaderEx { get; set; } //For Foresight only

        public SaleInvoice(SaleInvoiceEntity entity)
        {
            Entity = entity;
            HeaderEx = new SaleInvoiceHeaderEx(new SaleInvoiceHeaderExEntity()); //For Foresight only
            Lines = new List<SaleInvoiceLine>();
            Terms = new List<SaleInvoiceTerm>();
        }

        //This method is for Foresight only
        public void SetIdentityValue(string id)
        {
            Entity.Id = id;

            if (HeaderEx != null)
                HeaderEx.Entity.InvoiceId = id;

            foreach (var line in Lines)
                line.Entity.InvoiceId = id;

            foreach (var term in Terms)
                term.Entity.InvoiceId = id;
        }

        public override void Save()
        {
            ((SaleInvoiceEntity)Entity).LineEntities = Lines.Select(l => l.Entity as SaleInvoiceLineEntity).ToList();
            ((SaleInvoiceEntity)Entity).TermEntities = Terms.Select(t => t.Entity as SaleInvoiceTermEntity).ToList();

            base.Save();
        }

        public static SaleInvoice New()
        {
            return new SaleInvoice(new SaleInvoiceEntity());
        }

        public IList<BillTerm> GetBillTerms()
        {
            var repo = new InsightRepository();
            return repo.GetSaleInvoiceBillTerms(Terms);
        }

        public void SetBillTerms(IEnumerable<BillTerm> billTerms)
        {
            foreach (var billTerm in billTerms)
            {
                var invoiceTerm = SaleInvoiceTerm.New();
                invoiceTerm.Entity.TermId = billTerm.Entity.Id;
                invoiceTerm.Entity.Code = billTerm.Entity.Code;
                invoiceTerm.Entity.Description = billTerm.Entity.Description;
                invoiceTerm.Entity.Percentage = billTerm.Entity.Percentage;
                Terms.Add(invoiceTerm);
            }
        }

        protected override void SetDocumentNr()
        {
            if (!IsNew())
                return;
            
            var repo = new InsightRepository();
            Entity.DocumentNr = repo.GetNewSaleInvoiceDocNr();
        }
    }
}
