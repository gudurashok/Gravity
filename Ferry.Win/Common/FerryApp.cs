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
            var message = $"Company group \n'{GravitySession.CompanyGroup.Entity.Name}'\n" +
                          $"doesn't exist.\n\nClick Yes to create now.";
            return MessageBoxUtil.GetConfirmationYesNo(message) == DialogResult.Yes;
        }

        private void createForesightCompanyGroup()
        {
            var db = CoGroupDatabaseFactory.GetInstance();

            if (!db.IsDatabaseExists(AppConfig.AppDbNameSuffix))
                throw new Exception($"Gravity Foresight master datbase '{AppConfig.AppDbNameSuffix}' not found.");

            var companyGroup = CompanyGroup.New();
            companyGroup.Entity.Name = GravitySession.CompanyGroup.Entity.Name;
            companyGroup.Entity.ForesightDatabaseName = companyGroup.DatabaseName;
            companyGroup.Entity.ForesightGroupId = db.SaveCompanyGroup(companyGroup);
            var repo = new CoGroupRepository();
            companyGroup.Entity.Id = GravitySession.CompanyGroup.Entity.Id;
            repo.Save(companyGroup.Entity);
        }

        private bool isForesightCompanyGroupExists()
        {
            var db = ForesightDatabaseFactory.GetInstance();
            return (db.IsCompanyGroupNameExist(GravitySession.CompanyGroup));
        }

        protected override FMainBase getMainForm()
        {
            return new FMain(this);
        }
    }
}
