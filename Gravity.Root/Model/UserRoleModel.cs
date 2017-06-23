using System.ComponentModel.DataAnnotations;
using Gravity.Root.Entities;
using Gravity.Root.Properties;
using Gravity.Root.Repositories;

namespace Gravity.Root.Model
{
    public class UserRoleModel
    {
        public readonly UserRoleEntity Entity;

        public UserRoleModel(UserRoleEntity entity)
        {
            Entity = entity;
        }

        public static UserRoleModel New()
        {
            return new UserRoleModel(UserRoleEntity.New());
        }

        public void Save()
        {
            validateUserRole();

            var repo = new UserRepository();
            repo.Save(Entity);
        }


        private void validateUserRole()
        {
            if (string.IsNullOrWhiteSpace(Entity.Name))
                throw new ValidationException(string.Format(Resources.UserRoleNameCannotBeEmpty));
        }
    }
}
