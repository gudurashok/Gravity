using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Ferry.Logic.Base;
using Ferry.Logic.Common;
using Ferry.Logic.Connection;
using Ferry.Logic.Properties;
using Foresight.Logic.DataAccess;
using Insight.Domain.Model;

namespace Ferry.Logic.EASY
{
    internal class EasyDataImportContext : DataImportContext
    {
        private const string easyFileExtension = "ASK";
        private const string easyFileSearchPattern = "*." + easyFileExtension;

        internal EasyDataImportContext(CompanyPeriod companyPeriod)
            : base(companyPeriod)
        {
        }

        protected override void ValidateSourceData()
        {
            if (Directory.GetFiles(companyPeriod.Entity.SourceDataPath, "TXN_FILE.ASK").Length == 0)
                throw new ValidationException(string.Format(Resources.InvalidSourceDataPath, companyPeriod.Entity.SourceDataPath));
        }

        protected override string MakeCopyOfSourceData()
        {
            var destinationFolder = new DirectoryInfo(MakeCopyOfSourceDataInternal(easyFileSearchPattern));
            RenameFileExtToDbf(destinationFolder, destinationFolder.GetFiles(easyFileSearchPattern));
            return destinationFolder.FullName;
        }

        private void RenameFileExtToDbf(DirectoryInfo destinationFolder, IEnumerable<FileInfo> files)
        {
            foreach (var file in files)
            {
                var destFileName = destinationFolder + @"\" + file.Name.Replace("." + easyFileExtension, ".dbf");
                file.MoveTo(destFileName); // Rename
            }
        }

        protected override Database GetSourceDataContext(string sourceDataPath)
        {
            var connInfo = SourceDbConnInfoFactory.GetConnectionInfo(sourceDataPath);
            return FerryUtil.GetSourceDatabase(connInfo);
        }
    }
}
