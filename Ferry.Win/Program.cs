using System;
using System.Windows.Forms;
using Ferry.Win.Common;

namespace Ferry.Win
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
            app.Run(Environment.GetCommandLineArgs());
        }
    }
}
