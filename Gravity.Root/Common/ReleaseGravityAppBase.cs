using System;
using System.IO;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Gravity.Root.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using Scalable.Shared.Common;
using Scalable.Shared.Enums;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

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

                var coGroup = getCoGroupFromAppConfig();
                if (coGroup != null)
                    checkCoGroupOfAppConfigExists(coGroup);
                else
                {
                    if (loginNotPerformed(true))
                        return false;

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
            if (string.IsNullOrWhiteSpace(databaseName))
                return null;

            var result = CompanyGroup.NewFrom(AppConfig.CoGroupId, databaseName);
            result.Entity.Name = databaseName;
            return result;
        }

        private void checkCoGroupOfAppConfigExists(CompanyGroup coGroup)
        {
            if (AppConfig.AppGenus == Genus.RunInMemory)
                return;

            GravitySession.Initialize();
            if (AppConfig.AppGenus != Genus.Embedded)
                if (!GravitySession.StoreManager.Store.IsServerOnline())
                    throw new ValidationException("Server not online!");

            GravitySession.StoreManager.CheckCoGroupDatabaseExists(coGroup);
            GravitySession.Dispose();
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
            //TODO:...
        }

        //protected virtual void insertData()
        //{
        //    if (AppConfig.CreateTestUsers)
        //        new TestUsersRepository().Insert();
        //}
    }
}
