using System;
using System.IO;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Gravity.Root.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using Scalable.Shared.Common;
using Scalable.Shared.Enums;
using System.Windows.Forms;

namespace Gravity.Root.Common
{
    public abstract class ReleaseGravityAppBase : GravityAppBase
    {
        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            try
            {
                if (!base.OnStartup(eventArgs))
                    return false;

                var createNewCoGroup = true;
                var coGroup = getCoGroupFromAppConfig();
                if (coGroup != null)
                {
                    if (!isCoGroupOfAppConfigExist(coGroup))
                    {
                        if (!shouldCreateNewCoGroup(coGroup.DatabaseName))
                            return false;
                    }
                    else
                        createNewCoGroup = false;
                }

                if (createNewCoGroup && loginNotPerformed(true))
                    return false;

                if (createNewCoGroup)
                {
                    coGroup = createCoGroup();
                    if (coGroup == null)
                        return false;
                }

                GravitySession.ReInitialize();
                openCompanyGroup(coGroup);

                if (loginNotPerformed())
                {
                    GravitySession.Dispose();
                    return false;
                }

                //insertData();
                createIndexes();
                //ShowSplash();
                ApplicationContext.ThreadExit += applicationContext_ThreadExit;
                //MainForm = getMainForm();
                setMainForm();
                setUserConfig();
                GravitySession.Application = this;
                return true;
            }
            catch (Exception ex)
            {
                GravitySession.Dispose();
                HideSplash();
                HideSplash2();
                ExceptionProcessor.Process(ex);
            }
            finally
            {
                HideSplash();
                HideSplash2();
            }

            return false;
        }

        private CompanyGroup getCoGroupFromAppConfig()
        {
            var databaseName = AppConfig.CoGroupDatabase;
            return string.IsNullOrWhiteSpace(databaseName)
                ? null
                : CompanyGroup.NewFrom(AppConfig.CoGroupId, databaseName);
        }

        private bool isCoGroupOfAppConfigExist(CompanyGroup coGroup)
        {
            if (AppConfig.AppGenus == Genus.RunInMemory)
                return false;

            if (AppConfig.AppGenus == Genus.Embedded)
                return Directory.Exists(coGroup.DatabaseName);

            bool exists = true;

            GravitySession.Initialize();

            if (AppConfig.AppGenus != Genus.RavenHQ)
            {
                exists = GravitySession.StoreManager.Store
                    .IsDatabaseExists(coGroup.DatabaseName);
            }

            GravitySession.Dispose();
            return exists;
        }

        private bool shouldCreateNewCoGroup(string databaseName)
        {
            HideSplashScreen();
            return (MessageBoxUtil.GetConfirmationYesNo(
                    string.Format(Resources.CoGroupDatabaseDoesNotExistCreateNew, databaseName)) ==
                    DialogResult.Yes);
        }

        private CompanyGroup createCoGroup()
        {
            GravitySession.Initialize();
            var coGroup = CompanyGroup.New();
            var companyGroupForm = getCompanyGroupForm(coGroup);
            companyGroupForm.ShowInTaskbar = true;
            if (companyGroupForm.ShowDialog() == DialogResult.OK)
                return coGroup;

            GravitySession.Dispose();
            return null;
        }

        protected virtual FCompanyGroupBase getCompanyGroupForm(CompanyGroup coGroup)
        {
            return new FCompanyGroupBase(coGroup);
        }

        protected virtual void openCompanyGroup(CompanyGroup coGroup)
        {
            GravitySession.OpenCompanyGroup(coGroup);
        }

        protected virtual void createIndexes()
        {

        }

        //protected virtual void insertData()
        //{
        //    if (AppConfig.CreateTestUsers)
        //        new TestUsersRepository().Insert();
        //}
    }
}
