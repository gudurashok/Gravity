using System;
using Gravity.Root.Common;
using Gravity.Root.Entities;
using Scalable.Shared.Common;
using Scalable.Shared.Enums;
using System.Reflection;

namespace Gravity.Root.Model
{
    public class CompanyGroup
    {
        private const string DefaultId = "CoGroupEntities/1";
        public CoGroupEntity Entity { get; private set; }
        private string _databaseName;

        public CompanyGroup(CoGroupEntity entity)
        {
            Entity = entity;
        }

        private CompanyGroup()
            : this(CoGroupEntity.New())
        {
        }

        public static CompanyGroup New()
        {
            return new CompanyGroup();
        }

        public static CompanyGroup NewFrom(string id, string databaseName)
        {
            var coGroup = New();
            coGroup.Entity.Id = id;
            coGroup.DatabaseName = databaseName;
            return coGroup;
        }

        public static CompanyGroup CreateTestCoGroup()
        {
            var coGroup = New();
            coGroup.Entity.Id = DefaultId;
            coGroup.Entity.Name = getCompanyName();
            //coGroup.CreateDatabaseName();
            return coGroup;
        }

        private static string getCompanyName()
        {
            var asm = Assembly.GetExecutingAssembly();
            var attr = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(asm,
                                typeof(AssemblyCompanyAttribute));

            return attr.Company;
        }

        public bool IsNew()
        {
            return Entity.Id == EntityPrefix.CoGroupPrefix;
        }

        public string DatabaseName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_databaseName))
                    return _databaseName;

                if (string.IsNullOrWhiteSpace(Entity.DatabaseName))
                {
                    if (AppConfig.AppGenus == Genus.RavenHQ)
                        Entity.DatabaseName = AppConfig.RavenHQDatabaseName;
                    else
                        createDatabaseName();
                }

                _databaseName = getDatabaseName();
                return _databaseName;
            }
            private set { _databaseName = value; }
        }

        private void createDatabaseName()
        {
            Entity.DatabaseName = FileNameUtil.GetValidFileName(
                                    string.Concat(Entity.Name.Replace(" ", ""), ".",
                                                    AppConfig.AppDbNameSuffix));
        }

        private string getDatabaseName()
        {
            return AppConfig.AppGenus == Genus.Server || AppConfig.AppGenus == Genus.RavenHQ
                        ? Entity.DatabaseName
                        : getDatabaseNameWithPath();
        }

        private string getDatabaseNameWithPath()
        {
            return string.Format(@"{0}\{1}", AppConfig.CoGroupDataPath, Entity.DatabaseName);
        }

        public bool Equals(CompanyGroup coGroup)
        {
            return coGroup != null && coGroup.Entity.Id == Entity.Id;
        }
    }
}
