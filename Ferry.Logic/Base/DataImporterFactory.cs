using System.ComponentModel.DataAnnotations;
using Ferry.Logic.EASY;
using Ferry.Logic.MCS;
using Ferry.Logic.Properties;
using Ferry.Logic.TCS;
using Insight.Domain.Enums;
using Insight.Domain.Model;

namespace Ferry.Logic.Base
{
    public static class DataImporterFactory
    {
        public static DataImportContext GetDataImporter(CompanyPeriod companyPeriod)
        {
            switch (companyPeriod.Entity.SourceDataProvider)
            {
                case SourceDataProvider.Easy:
                    return new EasyDataImportContext(companyPeriod);
                case SourceDataProvider.Mcs:
                    return new McsDataImportContext(companyPeriod);
                case SourceDataProvider.Tcs:
                    return new TcsDataImportContext(companyPeriod);
                default:
                    throw new ValidationException(string.Format(Resources.ImporterNotSupported, companyPeriod.Entity.SourceDataProvider));
            }
        }
    }
}
