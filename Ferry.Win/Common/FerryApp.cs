﻿using System;
using Ferry.Win.Forms;
using Gravity.Root.Common;
using Gravity.Root.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Scalable.Shared.Common;
using System.Windows.Forms;
using Foresight.Logic.DataAccess;
using Gravity.Root.Model;
using Gravity.Root.Repositories;
using System.Collections.Generic;

namespace Ferry.Win.Common
{
    public class FerryApp : ReleaseGravityAppBase
    {
        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            if (!base.OnStartup(eventArgs))
                return false;

            FStatusMessage statusMessageForm = null;
            try
            {
                var coGroupDbExists = isForesightCompanyGroupExists();
                if (coGroupDbExists)
                    return true;

                if (!shouldCreateForesightCompanyGroup())
                    return false;

                statusMessageForm = new FStatusMessage();
                statusMessageForm.SetStatusMessage("Please wait while the group is being created...");
                statusMessageForm.Show();
                statusMessageForm.Refresh();
                createForesightCompanyGroup();
                return true;
            }
            catch (Exception ex)
            {
                statusMessageForm?.Hide();
                RootUtil.LogError("FerryApp", ex);
                MessageBoxUtil.ShowError(ex);
                return false;
            }
            finally
            {
                statusMessageForm?.Close();
            }
        }

        private bool shouldCreateForesightCompanyGroup()
        {
            var message = $"Company group \n'{GravitySession.CompanyGroup.Entity.Name}' not found.\n" +
                          $"Check it's physical file: {GravitySession.CompanyGroup.ForesightDatabaseName} exists.\n\n" +
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
            GravitySession.CompanyGroup.Entity.ForesightDatabaseName = companyGroup.Entity.ForesightDatabaseName;
            GravitySession.CompanyGroup.Entity.ForesightGroupId = companyGroup.Entity.ForesightGroupId;
            GravitySession.CompanyGroup.ForesightDatabaseName = companyGroup.ForesightDatabaseName;
            repo.Save(GravitySession.CompanyGroup.Entity);
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
            MainForm = new FMain(this);
        }

        protected override void saveMainWindowStateInUserConfig()
        {
            if (SkipSaveUserConfig) return;

            var settings = new Dictionary<string, object>();
            var mainForm = ApplicationContext.MainForm;
            settings.Add(UserConfig.ferryMainWindowStateKey, mainForm.WindowState);
            settings.Add(UserConfig.ferryMainWindowStartPositionKey, MainForm.StartPosition);
            settings.Add(UserConfig.ferryMainWindowLocationKey, mainForm.Location);
            settings.Add(UserConfig.ferryMainWindowSizeKey, mainForm.Size);
            UserConfig.SaveSettings(GravitySession.User.Entity.Id, settings);
        }

        protected override void setUserConfig()
        {
            var winState = UserConfig.FerryMainWindowState;
            MainForm.WindowState = winState == FormWindowState.Minimized
                                            ? FormWindowState.Normal
                                            : winState;

            MainForm.StartPosition = UserConfig.FerryMainWindowLocation.IsEmpty
                                    ? UserConfig.FerryMainWindowStartPosition
                                    : FormStartPosition.Manual;
            var size = UserConfig.FerryMainWindowSize;
            MainForm.Size = size.IsEmpty ? MainForm.Size : size;

            var location = UserConfig.FerryMainWindowLocation;
            if (!Screen.PrimaryScreen.WorkingArea.Contains(location.X, location.Y))
                MainForm.StartPosition = FormStartPosition.CenterScreen;
            else
                MainForm.Location = location.IsEmpty ? MainForm.Location : location;
        }
    }
}
