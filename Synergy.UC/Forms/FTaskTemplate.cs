using System;
using System.Windows.Forms;
using Scalable.Win.Forms;
using Synergy.Domain.Model;

namespace Synergy.UC.Forms
{
    public partial class FTaskTemplate : FFormBase
    {
        private readonly TaskTemplate _template;

        public FTaskTemplate()
        {
            InitializeComponent();
        }

        public FTaskTemplate(TaskTemplate template)
            : this()
        {
            _template = template;
            initialize();
        }

        private void initialize()
        {
            setFormTitle();
            uTaskTemplate.TemplateSaved += uTaskTemplate_TemplateSaved;
            uTaskTemplate.Cancelled += uTaskTemplate_Cancelled;
            uTaskTemplate.Initialize();
            uTaskTemplate.DataSource = _template;
        }

        void uTaskTemplate_Cancelled(object sender, EventArgs e)
        {
            Close();
        }

        void uTaskTemplate_TemplateSaved(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void setFormTitle()
        {
            Text = @"Task template";
            lblTitle.Text = Text;
        }
    }
}
