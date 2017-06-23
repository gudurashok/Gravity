using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Ferry.Logic.Model;
using Ferry.Logic.Properties;
using Ferry.Logic.Sql;
using Insight.Domain.Enums;

namespace Ferry.Logic.Base
{
    public class CompanyImporter
    {
        #region Declarations

        private readonly string _folderPath;
        private readonly CompanyExtractorBase _extractor;
        private IList<SourceCompanyPeriod> _sourceData;
        private readonly bool _isRootFolder;
        public SourceDataProvider Provider { get; private set; }

        #endregion

        #region Constructor

        public CompanyImporter(string folderPath, bool isRootFolder)
        {
            _folderPath = folderPath;
            _isRootFolder = isRootFolder;
            Provider = getProviderType();
            _extractor = CompanyExtractorFactory.GetInstance(Provider, _folderPath);
        }

        private SourceDataProvider getProviderType()
        {
            if (_isRootFolder)
                return getProviderTypeOfRootFolder();

            return getProviderTypeOfCoPeriod();
        }

        #endregion

        #region Identify Source Provider of Root Folder

        private SourceDataProvider getProviderTypeOfRootFolder()
        {
            if (areProviderFilesExistsOfRootFolder(getProviderCompanyFileNames(SourceDataProvider.Easy)))
                return SourceDataProvider.Easy;

            if (areProviderFilesExistsOfRootFolder(getProviderCompanyFileNames(SourceDataProvider.Mcs)))
                return SourceDataProvider.Mcs;

            if (areProviderFilesExistsOfRootFolder(getProviderCompanyFileNames(SourceDataProvider.Tcs)))
                return SourceDataProvider.Tcs;

            throw new ValidationException(Resources.ImportProviderFilesNotFound);
        }

        private bool areProviderFilesExistsOfRootFolder(IEnumerable<string> files)
        {
            return files.All(file => File.Exists(_folderPath + @"\" + file));
        }

        private IEnumerable<string> getProviderCompanyFileNames(SourceDataProvider provider)
        {
            switch (provider)
            {
                case SourceDataProvider.Easy:
                    return new[] { EasySqlQueries.EasyCoGroupFileName, EasySqlQueries.EasyCompanyFileName };
                case SourceDataProvider.Mcs:
                    return new[] { McsSqlQueries.CompanyFileName, McsSqlQueries.GlGroupFileName };
                case SourceDataProvider.Tcs:
                    return new[] { TcsSqlQueries.CoFileName, TcsSqlQueries.GlGroupFileName };
                default:
                    throw new NotSupportedException();
            }
        }

        #endregion

        #region Identify Source Provider of Root Folder

        private SourceDataProvider getProviderTypeOfCoPeriod()
        {
            if (areProviderFilesExistsOfCoPereiod(getProviderCoPeriodDataFileNames(SourceDataProvider.Easy)))
                return SourceDataProvider.Easy;

            if (areProviderFilesExistsOfCoPereiod(getProviderCoPeriodDataFileNames(SourceDataProvider.Mcs)) &&
                isGlGroupFileExists(_folderPath))
                return SourceDataProvider.Mcs;

            if (areProviderFilesExistsOfCoPereiod(getProviderCoPeriodDataFileNames(SourceDataProvider.Tcs)) &&
                isGlGroupFileExists(_folderPath))
                return SourceDataProvider.Tcs;

            throw new ValidationException(Resources.ImportProviderFilesNotFound);
        }

        private bool areProviderFilesExistsOfCoPereiod(IEnumerable<string> files)
        {
            return !(from file in files
                     let di = new DirectoryInfo(_folderPath)
                     where di.GetFiles(file).Length == 0
                     select file).Any();
        }

        private IEnumerable<string> getProviderCoPeriodDataFileNames(SourceDataProvider provider)
        {
            switch (provider)
            {
                case SourceDataProvider.Easy:
                    return new[] { EasySqlQueries.AccountMasterFileName, EasySqlQueries.TransactionFileName };
                case SourceDataProvider.Mcs:
                    return new[] { McsSqlQueries.AccountMasterFileName, McsSqlQueries.TransactionFileName };
                case SourceDataProvider.Tcs:
                    return new[] { TcsSqlQueries.AccountMasterFileName, TcsSqlQueries.TransactionFileName };
                default:
                    throw new NotSupportedException();
            }
        }

        private bool isGlGroupFileExists(string folderPath)
        {
            var di = new DirectoryInfo(folderPath);
            return di.Parent != null && di.Parent.GetFiles(getGlGroupFileName()).Length > 0;
        }

        private string getGlGroupFileName()
        {
            if (Provider == SourceDataProvider.Mcs)
                return McsSqlQueries.GlGroupFileName;

            return TcsSqlQueries.GlGroupFileName;
        }

        #endregion

        #region Populate Company Groups

        public IList<SourceCompanyGroup> GetAllCompanyGroups()
        {
            _sourceData = _extractor.GetSourceData();
            return getAllCoGroups();
        }

        private IList<SourceCompanyGroup> getAllCoGroups()
        {
            var result = new List<SourceCompanyGroup>();

            foreach (var groupCode in getDistinctGroupCodes())
            {
                var coGroup = new SourceCompanyGroup();
                coGroup.Code = groupCode;
                coGroup.Name = getCoGroupName(groupCode);
                result.Add(coGroup);
            }

            return result.OrderBy(c => c.Name).ToList();
        }

        private IEnumerable<string> getDistinctGroupCodes()
        {
            return _sourceData.Select(c => c.GroupCode).Distinct();
        }

        private string getCoGroupName(string groupCode)
        {
            if (string.IsNullOrEmpty(groupCode))
                return "(UNGROUPED)";

            return getGroupNameIfExist(groupCode);
        }

        private string getGroupNameIfExist(string groupCode)
        {
            const int groupCodeLength = 3;

            var result = _sourceData
                .Where(c => groupCode.Length == groupCodeLength
                            && groupCode == c.CompanyCode.Substring(0, groupCodeLength))
                .OrderByDescending(c => c.CompanyCode)
                .Select(c => c.CompanyName).FirstOrDefault();

            return result ?? groupCode;
        }

        #endregion

        #region Populate Company Periods of Selected Group

        public IList<SourceCompanyPeriod> GetCompanyPeriodsFor(SourceCompanyGroup group)
        {
            return _sourceData.Where(cp => cp.GroupCode == group.Code).ToList();
        }

        #endregion

        #region Populate Company Period of Selected Company Folder

        public SourceCompanyPeriod GetCompanyPeriod()
        {
            return _extractor.GetCompanyPeriod();
        }

        #endregion
    }
}
