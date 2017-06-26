using System.ComponentModel.DataAnnotations;
using Insight.Domain.Entities;
using Insight.Domain.Properties;
using Insight.Domain.Repositories;
using Mingle.Domain.Model;
using System;

namespace Insight.Domain.Model
{
    public class Company
    {
        public CompanyEntity Entity { get; private set; }
        public Party Party { get; set; }

        private Company()
        {
            Entity = new CompanyEntity();
        }

        public Company(CompanyEntity entity)
        {
            Entity = entity;
        }

        public override string ToString()
        {
            return Entity.Name;
        }

        public bool IsNew()
        {
            return string.IsNullOrWhiteSpace(Entity.Id);
        }

        public void Save()
        {
            var repo = new InsightRepository();
            if (IsNew() && repo.GetCompanyByName(Entity.Name) != null)
                throw new ValidationException(Resources.CompanyAlreadyExist);

            repo.Save(Entity);
        }

        public string GetCodeCreatedFromId()
        {
            var result = Entity.Id.Substring(Entity.Id.IndexOf("/") + 1);
            return result;
        }

        public static Company New()
        {
            return new Company();
        }
    }
}
