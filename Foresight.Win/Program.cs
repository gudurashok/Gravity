using System;
using System.Windows.Forms;
using Foresight.Win.Common;

namespace Foresight.Win
{
    static class Program
    {
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
