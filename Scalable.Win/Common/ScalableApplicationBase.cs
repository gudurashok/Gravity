using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic.ApplicationServices;
using Scalable.Shared.Common;
using Scalable.Shared.Enums;
using Scalable.Win.Properties;
using Scalable.Win.Forms;

namespace Scalable.Win.Common
{
    public abstract class ScalableApplicationBase : WindowsFormsApplicationBase
    {
        protected ScalableApplicationBase()
        {
            IsSingleInstance = AppConfig.AppGenus == Genus.Embedded;
        }

#if !DEBUG
        private Form _splash;

        protected override void OnCreateSplashScreen()
        {
            SplashScreen = GetSplashScreen();
        }
#endif
        protected virtual Form GetSplashScreen()
        {
            return new FSplash();
        }

        protected void ShowSplash()
        {
#if !DEBUG
            Cursor.Current = Cursors.WaitCursor;
            _splash = GetSplashScreen();
            _splash.Show();
            _splash.Refresh();
#endif
        }

        public void HideSplash()
        {
#if !DEBUG
            HideSplashScreen();
#endif
        }

        public void HideSplash2()
        {
#if !DEBUG
            if (_splash == null)
                return;

            _splash.Close();
#endif
        }

        protected override bool OnInitialize(ReadOnlyCollection<string> commandLineArgs)
        {
            return isAppConfigFileExists() && base.OnInitialize(commandLineArgs);
        }

        private bool isAppConfigFileExists()
        {
            var configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            if (File.Exists(configFile))
                return true;

            MessageBox.Show(string.Format(Resources.AppConfigFileNotExists, configFile));
            return false;
        }

        //TODO: show a message and prompt for another instance to run. can just be quit if Scalable won't allow more than one instance
        // There can be a param in App.config to allow multiple instances.
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            base.OnStartupNextInstance(eventArgs);
            eventArgs.BringToForeground = IsSingleInstance;
        }
    }
}
