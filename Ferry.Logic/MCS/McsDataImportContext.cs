using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Ferry.Logic.Base;
using Ferry.Logic.Common;
using Ferry.Logic.Connection;
using Ferry.Logic.Properties;
using Foresight.Logic.DataAccess;
using Insight.Domain.Model;

namespace Ferry.Logic.MCS
{
    public class McsDataImportContext : DataImportContext
    {
        private IList<string> _sourceFileNames;
        private const string mcsFileExtension = "DBF";
        private const string mcsFileSearchPattern = "*." + mcsFileExtension;
        private const string mcsDataSourceFolderValidationFilePattern = "TRN*.DBF";

        public McsDataImportContext(CompanyPeriod companyPeriod)
            : base(companyPeriod)
        {
        }

        protected override void ValidateSourceData()
        {
            if (Directory.GetFiles(companyPeriod.Entity.SourceDataPath, mcsDataSourceFolderValidationFilePattern).Length == 0)
                throw new ValidationException(string.Format(Resources.InvalidSourceDataPath, companyPeriod.Entity.SourceDataPath));
        }

        protected override string MakeCopyOfSourceData()
        {
            fillSourceFileNames();
            var destinationFolder = new DirectoryInfo(MakeCopyOfSourceDataInternal(mcsFileSearchPattern));
            copyChartOfAccountGroupFile(destinationFolder);
            return destinationFolder.FullName;
        }

        private void fillSourceFileNames()
        {
            _sourceFileNames = new List<string>();
            _sourceFileNames.Add("PRT");
            _sourceFileNames.Add("QLY");
            _sourceFileNames.Add("PRS");
            _sourceFileNames.Add("TRN");
            _sourceFileNames.Add("INM");
        }

        protected override void CopyAllFiles(string searchPattern, DirectoryInfo sourceFolder, string destFolder)
        {
            foreach (var fileName in _sourceFileNames)
            {
                var sourceFileName = fileName + sourceFolder.Name + "." + mcsFileExtension;
                var sourcePath = sourceFolder.FullName + @"\" + sourceFileName;
                var destPath = destFolder + @"\" + fileName + "." + mcsFileExtension;
                var fileInfo = new FileInfo(sourcePath);
                fileInfo.CopyImportSourceFile(destPath);
            }
        }

        private void copyChartOfAccountGroupFile(DirectoryInfo destinationFolder)
        {
            var di = new DirectoryInfo(companyPeriod.Entity.SourceDataPath).Parent;
            if (di == null)
                return;

            var sourceFileName = di.FullName + @"\" + getChartOfAccountsGroupFileName();

            if (!File.Exists(sourceFileName))
                throw new ValidationException(string.Format(Resources.GeneralLedgerGroupFileNotFound,
                                                            getChartOfAccountsGroupFileName()));

            var destFileName = destinationFolder + @"\" + getChartOfAccountsGroupFileName();
            File.Copy(sourceFileName, destFileName, true);
        }

        protected override Database GetSourceDataContext(string sourceDataPath)
        {
            var connInfo = SourceDbConnInfoFactory.GetConnectionInfo(sourceDataPath);
            return FerryUtil.GetSourceDatabase(connInfo);
        }

        protected virtual string getChartOfAccountsGroupFileName()
        {
            return "MNGRP.DBF";
        }
    }
}
