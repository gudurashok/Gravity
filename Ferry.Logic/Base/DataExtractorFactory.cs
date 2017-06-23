using System.ComponentModel.DataAnnotations;
using Ferry.Logic.EASY;
using Ferry.Logic.MCS;
using Ferry.Logic.Properties;
using Ferry.Logic.TCS;
using Foresight.Logic.DataAccess;
using Insight.Domain.Enums;

namespace Ferry.Logic.Base
{
    internal static class DataExtractorFactory
    {
        internal static DataExtractorBase GetInstance(SourceDataProvider provider, Database sourceDatabase, DataContext targetDbContext)
        {
            switch (provider)
            {
                case SourceDataProvider.Easy:
                    return new EasyDataExtractor(sourceDatabase, targetDbContext);
                case SourceDataProvider.Mcs:
                    return new McsDataExtractor(sourceDatabase, targetDbContext);
                case SourceDataProvider.Tcs:
                    return new TcsDataExtractor(sourceDatabase, targetDbContext);
                default:
                    throw new ValidationException(string.Format(Resources.SourceDatabaseProviderNotSupported, provider));
            }
        }
    }
}
