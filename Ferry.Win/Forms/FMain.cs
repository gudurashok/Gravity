using Gravity.Root.Forms;
using Mingle.Domain.Model;
using Scalable.Win.Common;

namespace Ferry.Win.Forms
{
    public partial class FMain : FMainBase
    {
        private FMain()
        {
            InitializeComponent();
        }

        public FMain(ScalableApplicationBase application)
            : this()
        {
            Application = application;
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();
            uCompanyPeriods.Initialize();
            Application.HideSplash2();
        }

        protected override void SetFormTitle()
        {
            base.SetFormTitle();
            lblAdditionalInfo.Text = SysConfig.CoGroupParty.ToStringLocation();
        }

        protected override void OnRefreshList()
        {
            uCompanyPeriods.RefreshList();
        }
    }
}
