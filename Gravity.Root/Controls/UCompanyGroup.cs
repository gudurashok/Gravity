using System;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using Gravity.Root.Repositories;
using Scalable.Win.FormControls;
using Gravity.Root.Events;

namespace Gravity.Root.Controls
{
    public partial class UCompanyGroup : UFormBase
    {
        #region Declarations

        public event EventHandler<CoGroupSavedEventArgs> CoGroupSaved;
        private CompanyGroup _coGroup;
        //private string _attachingDatabaseName;

        #endregion

        #region Constructor

        public UCompanyGroup()
        {
            InitializeComponent();
        }

        public void Initialize(CompanyGroup coGroup)
        {
            _coGroup = coGroup;
            //_attachingDatabaseName = getAttachingDatabaseDefaultName();
            setDataBindings(_coGroup.Entity);
        }

        //private string getAttachingDatabaseDefaultName()
        //{
        //    if (AppConfig.AppGenus == Genus.Embedded)
        //        return _coGroup.GetDatabaseName();

        //    return "";
        //}

        #endregion

        #region Attach Database

        private void btnAttachDb_Click(object sender, EventArgs e)
        {
            //EventHandlerExecutor.Execute(processAttachDatabase, sender, e);
        }

        //private void processAttachDatabase(object sender, EventArgs e)
        //{
        //    _attachingDatabaseName = getAttachingDatabaseName();
        //    if (string.IsNullOrWhiteSpace(_attachingDatabaseName))
        //        return;

        //    fillFormWithAttachedDbInfo(CoGroupRepository.GetCoGroupFromAttachingDb(_attachingDatabaseName));
        //}

        //private string getAttachingDatabaseName()
        //{
        //    if (AppConfig.AppGenus == Genus.Embedded)
        //        return getAttachingDbPath();

        //    //    //TODO: show list of databases from server in a Dropdownlist?? or allow selecting a database folder to be attached???
        //    //    using (var repo = new CoGroupRepository())
        //    //    {
        //    //         repo.GetAllDatabaseNames();
        //    //    }

        //    return "";
        //}

        //private string getAttachingDbPath()
        //{
        //    var fpd = new FolderBrowserDialog();
        //    fpd.Description = Resources.SelectCompanyGroupDatabase;
        //    fpd.SelectedPath = _attachingDatabaseName;

        //    if (fpd.ShowDialog(this) == DialogResult.OK)
        //        return fpd.SelectedPath;

        //    return "";
        //}

        #endregion

        #region Save

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSaveCoGroup);
        }

        private void processSaveCoGroup()
        {
            saveCompanyGroup();
            OnCoGroupSaved(new CoGroupSavedEventArgs(_coGroup));
        }

        private void saveCompanyGroup()
        {
            var repo = new CoGroupRepository();
            repo.SaveGroup(_coGroup);
        }

        protected virtual void OnCoGroupSaved(CoGroupSavedEventArgs e)
        {
            if (CoGroupSaved != null)
                CoGroupSaved(this, e);
        }

        #endregion

        #region Common

        //private void fillFormWithAttachedDbInfo(CompanyGroup coGroup)
        //{
        //    txtCoGroupName.Text = coGroup.Entity.Name;
        //    txtAttachedDb.Text = coGroup.Entity.DatabaseName;
        //}

        #endregion
    }
}
