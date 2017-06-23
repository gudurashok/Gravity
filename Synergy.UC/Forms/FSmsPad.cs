using System;
using System.Windows.Forms;
using Scalable.Win.Forms;
using Synergy.Domain.Model;

namespace Synergy.UC.Forms
{
    public partial class FSmsPad : FFormBase
    {
        public FSmsPad()
        {
            InitializeComponent();
            setFormTitle();
        }

        public FSmsPad(Task selectedTask)
            : this()
        {
            uSmsPad.SelectedTask = selectedTask;
        }

        private void setFormTitle()
        {
            Text = @"SMS pad";
            lblTitle.Text = @"Send SMS to desired number(s)";
        }

        private void uSmsPad_CloseForm(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
