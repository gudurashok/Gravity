using System.Windows.Forms;
using Scalable.Win.Events;
using Scalable.Win.Forms;
using Synergy.Domain.Model;

namespace Synergy.UC.Forms
{
    public partial class FTaskTemplates : FFormBase
    {
        public TaskTemplate Template;

        public FTaskTemplates()
        {
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            setFormTitle();
            uTaskTemplates.Initialize();
            uTaskTemplates.ItemSelected += uTaskTemplates_ItemSelected;
        }

        private void setFormTitle()
        {
            Text = @"Select Template";
            lblTitle.Text = @"Select template for new task";
        }

        void uTaskTemplates_ItemSelected(object sender, PicklistItemEventArgs e)
        {
            Template = e.PicklistItem as TaskTemplate;
            DialogResult = DialogResult.OK;
        }
    }
}
