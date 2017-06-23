using System.Collections.Generic;
using System.Diagnostics;

namespace Scalable.Shared.Common
{
    public static class WinProcessUtil
    {
        public static int CurrentProcessId
        {
            get { return Process.GetCurrentProcess().Id; }
        }

        public static IEnumerable<Process> GetExecutingProcesses()
        {
            return Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
        }
    }
}
