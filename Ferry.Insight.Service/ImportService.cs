using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Ferry.Insight.Service
{
    public partial class ImportService : ServiceBase
    {
        private ImportProcessor _processor = null;

        public ImportService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _processor = new ImportProcessor();
                _processor.Setup();
            }
            catch (Exception ex)
            {
                writeEntry(ex.ToString());
            }
        }

        protected override void OnShutdown()
        {
            OnStop();
        }

        protected override void OnStop()
        {
            try
            {
                if (_processor != null)
                    _processor.Stop();

                _processor = null;
            }
            catch (Exception ex)
            {
                writeEntry(ex.ToString());
            }
        }

        private void writeEntry(string message)
        {
            EventLog.WriteEntry("Ferry.Insight.Process Service", message);
        }
    }
}
