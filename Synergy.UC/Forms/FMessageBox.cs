using System;
using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Forms;

namespace Synergy.UC.Forms
{
    public partial class FMessageBox : FFormBase
    {
        public FMessageBox()
        {
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            setFormTitle();
            uMessageBox.Initialize();
            uMessageBox.Close += uMessageBox_Close;
        }

        void uMessageBox_Close(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void setFormTitle()
        {
            Text = @"Your task messages";
            lblTitle.Text = @"Task messages";
        }

        protected override void OnActivated(EventArgs e)
        {
            EventHandlerExecutor.Execute(RefreshList);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(RefreshList);
        }

        public void RefreshList()
        {
            uMessageBox.FillList(true);
        }
    }
}
