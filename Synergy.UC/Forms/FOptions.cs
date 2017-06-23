using Gravity.Root.Common;
using Scalable.Win.Forms;
using Scalable.Shared.Common;

namespace Synergy.UC.Forms
{
    public partial class FOptions : FFormBase
    {
        public FOptions()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            EventHandlerExecutor.Execute(initilizeForm);
        }

        private void initilizeForm()
        {
            uOptions.Initialize();
            setFormTitle();
        }

        private void setFormTitle()
        {
            Text = string.Format("{0} Options", GravityApplication.GetProductName());
            lblTitle.Text = @"Please setup the following things as required";
        }
    }
}
