using System;
using System.Windows.Forms;
using Insight.Win.Common;

namespace Insight.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var app = ApplicationFactory.Instance();
            app.MinimumSplashScreenDisplayTime = 1000;
            app.Run(Environment.GetCommandLineArgs());
        }
    }
}
