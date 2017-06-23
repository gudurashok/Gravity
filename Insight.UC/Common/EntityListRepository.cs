using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gravity.Root.Common;
using Insight.UC.Controls;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Scalable.Win.FormControls;

namespace Insight.UC.Common
{
    public class EntityListRepository : IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            return getEntities().Cast<dynamic>().ToList();
        }

        private IEnumerable<EntityItem> getEntities()
        {
            var entities = new List<EntityItem>();
            entities.Add(new EntityItem { Name = "Company", Caption = "Companies", Editor = getEntityEditor(new UCompanies()) });
            entities.Add(new EntityItem { Name = "FiscalPeriod", Caption = "Fiscal Periods", Editor = getEntityEditor(new UFiscalDatePeriods()) });
            entities.Add(new EntityItem { Name = "CompanyPeriod", Caption = "Company Periods", Editor = getEntityEditor(new UCompanyPeriods()) });
            entities.Add(new EntityItem { Name = "ChartOfAccount", Caption = "ChartOfAccounts", Editor = getEntityEditor(new UChartOfAccounts()) });
            entities.Add(new EntityItem { Name = "Account", Caption = "Accounts", Editor = getEntityEditor(new UAccounts()) });
            entities.Add(new EntityItem { Name = "Daybook", Caption = "Daybooks", Editor = getEntityEditor(new UDaybooks()) });
            entities.Add(new EntityItem { Name = "BillTerms", Caption = "Bill Terms", Editor = getEntityEditor(new UBillTerms()) });
            entities.Add(new EntityItem { Name = "Items", Caption = "Items", Editor = getEntityEditor(new UItems()) });
            return entities;
        }

        private UPicklist getEntityEditor(UPicklist editor)
        {
            editor.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            editor.BorderStyle = BorderStyle.FixedSingle;
            editor.Initialize();
            editor.MakeList();
            return editor;
        }
    }
}
