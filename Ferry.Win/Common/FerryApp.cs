using System;
using Ferry.Win.Forms;
using Gravity.Root.Common;
using Gravity.Root.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Scalable.Shared.Common;
using System.Windows.Forms;
using Foresight.Logic.DataAccess;
using Gravity.Root.Model;
using Gravity.Root.Repositories;

namespace Ferry.Win.Common
{
    public class FerryApp : ReleaseGravityAppBase
    {
        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            if (!base.OnStartup(eventArgs))
                return false;

            var statusMessageForm = new FStatusMessage();
            try
            {
                var coGroupDbExists = isForesightCompanyGroupExists();
                if (coGroupDbExists)
                    return true;

                if (!shouldCreateForesightCompanyGroup())
                    return false;

                statusMessageForm.SetStatusMessage("Please wait while the group is being created...");
                statusMessageForm.Show();
                statusMessageForm.Refresh();
                createForesightCompanyGroup();
                return true;
            }
            catch (Exception ex)
            {
                statusMessageForm.Hide();
                MessageBoxUtil.ShowMessage(ex.Message);
                return false;
            }
            finally
            {
                statusMessageForm.Close();
            }
        }

        private bool shouldCreateForesightCompanyGroup()
        {
            var message = $"Company group \n'{GravitySession.CompanyGroup.Entity.Name} not found.'\n" +
                          $"Check it's physical file {GravitySession.CompanyGroup.ForesightDatabaseName} exists.\n\n" +
                          $"If you are sure that its first time, then click Yes to create a new group now.";
            return MessageBoxUtil.GetConfirmationYesNo(message) == DialogResult.Yes;
        }

        private void createForesightCompanyGroup()
        {
            var companyGroup = CompanyGroup.New();
            companyGroup.Entity.Name = GravitySession.CompanyGroup.Entity.Name;
            companyGroup.Entity.ForesightDatabaseName = companyGroup.ForesightDatabaseName;
            var db = CoGroupDatabaseFactory.GetInstance();
            companyGroup.Entity.ForesightGroupId = db.SaveCompanyGroup(companyGroup);
            var repo = new CoGroupRepository();
            companyGroup.Entity.Id = GravitySession.CompanyGroup.Entity.Id;
            repo.Save(companyGroup.Entity);
        }

        private bool isForesightCompanyGroupExists()
        {
            var db = ForesightDatabaseFactory.GetInstance();

            if (db.IsCompanyGroupNameExist(GravitySession.CompanyGroup))
                return (db.IsCompanyGroupExist(GravitySession.CompanyGroup));

            return false;
        }

        protected override FMainBase getMainForm()
        {
            return new FMain(this);
        }
    }
}
