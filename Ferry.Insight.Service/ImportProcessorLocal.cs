using Ferry.Logic.Insight;
using Gravity.Root.Common;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ferry.Insight.Service
{
    public class ImportProcessorLocal
    {
        public void Execute()
        {
            try
            {
                var companyPerdiods = getInsightCompanyPeriods();
                foreach (var companyPeriod in companyPerdiods
                                    .Where(cp => cp.Entity.ForesighId != 0))
                {
                    var importer = new InsightDataImporter(GravitySession.CompanyGroup, companyPeriod);
                    importer.Execute();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private IList<CompanyPeriod> getInsightCompanyPeriods()
        {
            var repo = CompanyPeriods.NewLoadOnlyInsightDataSourceCompanies();
            return repo.GetAllCompanyPeriods();
        }
    }
}
