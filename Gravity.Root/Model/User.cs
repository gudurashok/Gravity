using System;
using System.ComponentModel.DataAnnotations;
using Gravity.Root.Common;
using Gravity.Root.Entities;
using Gravity.Root.Properties;
using Gravity.Root.Repositories;
using Scalable.Shared.Common;

namespace Gravity.Root.Model
{
    public class User
    {
        private const string adminUserName = "Administrator";

        public UserEntity Entity { get; set; }
        public User Parent { get; set; }

        public User(UserEntity entity)
        {
            Entity = entity;
        }

        public static User New()
        {
            return new User(UserEntity.New());
        }

        public static User GetRootLoginUser()
        {
            var user = New();
            user.Entity.Name = adminUserName;
            user.Entity.Credentials.LoginName = "a"; //TODO: adminUserName;
            user.Entity.Credentials.Password = null; //TODO: "JaiSriRam";
            user.Entity.IsAdmin = true;
            return user;
        }

        public static Credentials CreateAdminCredentials()
        {
            return new Credentials { LoginName = "admin" };
        }

        public bool CredentialsMatch(Credentials credentials)
        {
            return (Entity.Credentials.LoginName.Equals(credentials.LoginName, StringComparison.OrdinalIgnoreCase)) &&
                    string.Equals(Entity.Credentials.Password, credentials.Password, StringComparison.Ordinal);
        }

        public void Save()
        {
            EntityValidator.Validate(Entity);
            EntityValidator.Validate(Entity.Credentials);
            checkUserIsAdministrator();

            var repo = new Users();
            checkLoginNameAlreadyExists(repo);
            repo.Save(Entity);
        }

        private void checkUserIsAdministrator()
        {
            if (IsNew() && Entity.Name == adminUserName)
                throw new ValidationException(Resources.UserNameCannotBeAdministrator);
        }

        private void checkLoginNameAlreadyExists(Users users)
        {
            var user = users.GetByLoginName(Entity.Credentials.LoginName);

            if (user != null && user.Entity.Id != Entity.Id)
                throw new ValidationException(
                    string.Format(Resources.LoginNameAlreadyExists, user.Entity.Credentials.LoginName));
        }

        public bool IsNew()
        {
            return Entity.Id == EntityPrefix.UserPrefix;
        }

        public bool IsAdministratorUser()
        {
            return Entity.Name == adminUserName;
        }
    }
}
