using System.ComponentModel.DataAnnotations;
using Ferry.Logic.EASY;
using Ferry.Logic.MCS;
using Ferry.Logic.Properties;
using Ferry.Logic.TCS;
using Insight.Domain.Enums;

namespace Ferry.Logic.Base
{
    public static class CompanyExtractorFactory
    {
        public static CompanyExtractorBase GetInstance(SourceDataProvider provider, 
                                                                string sourceDataPath)
        {
            switch (provider)
            {
                case SourceDataProvider.Easy:
                    return new EasyCompanyExtractor(sourceDataPath);
                case SourceDataProvider.Mcs:
                    return new McsCompanyExtractor(sourceDataPath);
                case SourceDataProvider.Tcs:
                    return new TcsCompanyExtractor(sourceDataPath);
                default:
                    throw new ValidationException(string.Format(Resources.SourceDatabaseProviderNotSupported, provider));
            }
        }
    }
}
