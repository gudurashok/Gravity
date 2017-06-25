using Ferry.Logic.Insight;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ferry.Insight.Service
{
    public class ImportProcessor
    {
        private const int millisecondsTimeout = 30000;
        private Thread _thread = null;

        public void Setup()
        {
            _thread = new Thread(new ThreadStart(pollProcess));
            _thread.Start();
        }

        public void Stop()
        {
            if (_thread != null)
                _thread.Abort();

            _thread = null;
        }

        private void pollProcess()
        {
            try
            {
                while (true)
                {
                    processDataImport();
                    Thread.Sleep(millisecondsTimeout);
                }
            }
            catch (ThreadAbortException)
            {
                EventLog.WriteEntry("Ferry.Insight.Process Service", "Stopped successfully");
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Ferry.Insight.Process Service", ex.ToString());
            }
        }

        private void processDataImport()
        {
            try
            {
                var companyPerdiods = getInsightCompanyPeriods();
                foreach (var companyPeriod in companyPerdiods)
                {
                    var importer = new InsightDataImporter(null, companyPeriod);
                    importer.Execute();
                    Thread.Sleep(millisecondsTimeout);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Ferry.Insight.Process Service", ex.ToString());
            }
        }

        private IList<CompanyPeriod> getInsightCompanyPeriods()
        {
            var repo = CompanyPeriods.NewLoadOnlyInsightDataSourceCompanies();
            return repo.GetAllCompanyPeriods();
        }
    }
}
