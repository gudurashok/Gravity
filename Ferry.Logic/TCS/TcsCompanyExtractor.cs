using Ferry.Logic.MCS;
using Ferry.Logic.Sql;

namespace Ferry.Logic.TCS
{
    public class TcsCompanyExtractor: McsCompanyExtractor
    {
        #region Constructor

        public TcsCompanyExtractor(string sourceDataPath)
            : base(sourceDataPath)
        {
        }

        #endregion

        #region Internal Methods

        protected override string GetCompanyFileName()
        {
            return TcsSqlQueries.CoFileName;
        }

        #endregion
    }
}
