using System;
using Gravity.Root.Model;
using Gravity.Root.Repositories;
using Microsoft.VisualBasic.ApplicationServices;
using Scalable.Shared.Common;

namespace Gravity.Root.Common
{
    public abstract class TestCoGroupGravityAppBase : GravityAppBase
    {
        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            try
            {
                if (!base.OnStartup(eventArgs))
                    return false;

                HideSplash();
                GravitySession.Initialize();
                var coGroup = new CoGroupRepository().GetTestCoGroup();

                openCompanyGroup(coGroup);
                if (loginNotPerformed())
                {
                    GravitySession.Dispose();
                    return false;
                }

                insertData();
                ApplicationContext.ThreadExit += applicationContext_ThreadExit;
                MainForm = getMainForm();
                setUserConfig();
                GravitySession.Application = this;
                return true;
            }
            catch (Exception ex)
            {
                GravitySession.Dispose();
                ExceptionProcessor.Process(ex);
            }
            finally
            {
                HideSplash();
                HideSplash2();
            }

            return false;
        }

        protected virtual void openCompanyGroup(CompanyGroup coGroup)
        {
            GravitySession.OpenCompanyGroup(coGroup, true);
        }

        protected virtual void insertData()
        {
            if (AppConfig.CreateTestUsers)
                new TestUsersRepository().Insert();
        }
    }
}
