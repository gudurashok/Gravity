using Ferry.Logic.Insight;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;

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
                ServiceConfig.WriteLog("Stopped successfully");
            }
            catch (Exception ex)
            {
                ServiceConfig.WriteLog(ex.ToString());
            }
        }

        private void processDataImport()
        {
            try
            {
                var companyPerdiods = getInsightCompanyPeriods();
                foreach (var companyPeriod in companyPerdiods)
                {
                    companyPeriod.Entity.IsImported = true;
                    var importer = new InsightDataImporter(null, companyPeriod);
                    importer.Execute();
                    Thread.Sleep(millisecondsTimeout);
                }
            }
            catch (Exception ex)
            {
                ServiceConfig.WriteLog(ex.ToString());
            }
        }

        private IList<CompanyPeriod> getInsightCompanyPeriods()
        {
            var repo = CompanyPeriods.NewLoadOnlyInsightDataSourceCompanies();
            return repo.GetAllCompanyPeriods();
        }
    }
}
