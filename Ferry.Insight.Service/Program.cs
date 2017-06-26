using System;
using System.ServiceProcess;

namespace Ferry.Insight.Service
{
    static class Program
    {
        static void Main()
        {
            var app = new FerryInsightServiceApp();
            app.Initialize();
#if DEBUG
            var s = new ImportProcessorLocal();
            s.Execute();
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ImportService()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
