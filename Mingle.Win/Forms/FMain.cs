using Gravity.Root.Events;
using Mingle.Domain.Model;
using Mingle.Domain.Repositories;
using Mingle.UC.Forms;
using Gravity.Root.Forms;
using Mingle.UC.Picklists;
using Scalable.Win.Common;

namespace Mingle.Win.Forms
{
    public partial class FMain : FMainBase
    {
        #region Constructor

        private FMain()
        {
            InitializeComponent();
        }

        public FMain(ScalableApplicationBase application)
            : this()
        {
            Application = application;
        }

        #endregion

        #region Loading

        protected override void InitializeForm()
        {
            base.InitializeForm();

            var repo = new PartyRepository();
            MenuItems = repo.GetAllAppMenuItems();
            SetMenuStripItems();

            Application.HideSplash2();

            ShowDefaultForm("Parties");            
        }

        protected override void SetFormTitle()
        {
            base.SetFormTitle();
            lblAdditionalInfo.Text = SysConfig.CoGroupParty.ToStringLocation();
        }

        #endregion

        #region CoGroup Selected for Add and Editing

        protected override void OnCoGroupSelected(CoGroupSelectedEventArgs e)
        {
            var coGroupForm = new FCompanyGroup(e.CompanyGroup);
            coGroupForm.ShowDialog();
        }

        #endregion

        #region Refresh

        protected override void OnCoGroupOpened()
        {
            PicklistFactory.ClearPicklistCache();
            base.OnCoGroupOpened();
        }

        #endregion
    }
}
