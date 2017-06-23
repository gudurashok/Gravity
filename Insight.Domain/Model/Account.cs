﻿using System.ComponentModel.DataAnnotations;
using Insight.Domain.Entities;
using Insight.Domain.Properties;
using Insight.Domain.Repositories;
using Mingle.Domain.Model;

namespace Insight.Domain.Model
{
    public class Account
    {
        public AccountEntity Entity { get; private set; }
        public Account Group { get; set; }
        public ChartOfAccount ChartOfAccount { get; set; }
        public Party Party { get; set; }

        public Account(AccountEntity entity)
        {
            Entity = entity;
        }

        public string ToStringAddress()
        {
            return string.Format("{0} {1} {2} {3} {4}", Entity.AddressLine1, Entity.AddressLine2,
                                                        Entity.City, Entity.State, Entity.Pin);
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
            if (IsNew() && repo.GetAccountByName(Entity.Name) != null)
                throw new ValidationException(Resources.AccountAlreadyExist);

            repo.Save(Entity);
        }

        public static Account New()
        {
            return new Account(new AccountEntity());
        }
    }
}
