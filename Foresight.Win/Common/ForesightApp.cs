using Foresight.Logic.DataAccess;
using Foresight.Win.Forms;
using Gravity.Root.Common;
using Gravity.Root.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Scalable.Shared.Common;
using System;

namespace Foresight.Win.Common
{
    public class ForesightApp : ReleaseGravityAppBase
    {
        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            if (!base.OnStartup(eventArgs))
                return false;

            try
            {
                var coGroupDbExists = isForesightCompanyGroupExists();
                if (coGroupDbExists)
                    return true;

                var message = $"Company group \n'{GravitySession.CompanyGroup.Entity.Name}' not found.\n" +
                              $"Check it's physical file: {GravitySession.CompanyGroup.ForesightDatabaseName} exists.";
                MessageBoxUtil.ShowMessage(message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBoxUtil.ShowError(ex);
            }

            return false;
        }

        private bool isForesightCompanyGroupExists()
        {
            var db = ForesightDatabaseFactory.GetInstance();
            if (db.IsCompanyGroupNameExist(GravitySession.CompanyGroup.Entity.Name))
                return (db.IsCompanyGroupExist(GravitySession.CompanyGroup.Entity.ForesightDatabaseName));

            return false;
        }

        protected override void setMainForm()
        {
            MainForm = new FMain();
        }
    }
}
