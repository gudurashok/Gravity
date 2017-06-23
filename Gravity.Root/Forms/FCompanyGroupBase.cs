using System.Windows.Forms;
using Gravity.Root.Common;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using Gravity.Root.Properties;
using Scalable.Win.Forms;
using Gravity.Root.Repositories;
using System.Reflection;
using Gravity.Root.Events;

namespace Gravity.Root.Forms
{
    public partial class FCompanyGroupBase : FFormBase
    {
        #region Declarations

        private readonly CompanyGroup _coGroup;

        #endregion

        #region Constructor

        public FCompanyGroupBase()
        {
            InitializeComponent();
        }

        public FCompanyGroupBase(CompanyGroup coGroup)
            : this()
        {
            _coGroup = coGroup;
            uCompanyGroup.Initialize(_coGroup);
        }

        #endregion

        #region Save

        private void uCompanyGroup_CoGroupSaved(object sender, CoGroupSavedEventArgs e)
        {
            AppConfig.CoGroupDatabase = _coGroup.DatabaseName;
            AppConfig.CoGroupId = _coGroup.Entity.Id;

            createIndexes();
            MessageBoxUtil.ShowMessage(Resources.CoGroupSavedSuccessfully);
            DialogResult = DialogResult.OK;
        }

        private void createIndexes()
        {
            GravitySession.StoreManager.OpenCoGroupDatabase(_coGroup);
            GravitySession.StoreManager.CreateIndexesFrom(GetAssembliesToScanForIndexingTasks());
        }

        protected virtual Assembly[] GetAssembliesToScanForIndexingTasks()
        {
            return new Assembly[] { };
        }

        #endregion
    }
}
