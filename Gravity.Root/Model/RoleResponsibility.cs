using System.ComponentModel.DataAnnotations;
using Gravity.Root.Entities;
using Gravity.Root.Properties;
using Gravity.Root.Repositories;

namespace Gravity.Root.Model
{
    public class RoleResponsibility
    {
        public readonly RoleResponsibilityEntity Entity;

        public RoleResponsibility(RoleResponsibilityEntity entity)
        {
            Entity = entity;
        }

        public static RoleResponsibility New()
        {
            return new RoleResponsibility(RoleResponsibilityEntity.New());
        }

        public void Save()
        {
            validateRoleResponsibility();

            var repo = new UserRepository();
            repo.Save(Entity);
        }


        private void validateRoleResponsibility()
        {
            if (string.IsNullOrWhiteSpace(Entity.Name))
                throw new ValidationException(string.Format(Resources.ResponsibilityNameCannotBeEmpty));
        }
    }
}
