using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Gravity.Root.Entities;
using Gravity.Root.Properties;
using Scalable.Shared.Common;

namespace Gravity.Root.Repositories
{
    class UserRepository : RepositoryBase
    {
        public void SaveUserRole(UserRoleEntity entity)
        {
            EntityValidator.Validate(entity);
            base.Save(entity);
        }

        public IEnumerable<UserRoleEntity> GetAllUserRoles()
        {
            using (var s = Store.OpenSession())
                return s.Query<UserRoleEntity>().ToList();
        }

        public void DeleteUserRoleById(string id)
        {
            checkIsUserRoleIsInUse(id);
            base.DeleteById(id);
        }

        private void checkIsUserRoleIsInUse(string userRoleId)
        {
            List<UserEntity> userEntities;
            using (var s = Store.OpenSession())
                userEntities = s.Query<UserEntity>().ToList();

            bool flag = false;

            foreach (var userEntity in userEntities)
                flag = userEntity.Roles.Where(r => r.Id == userRoleId).Count() > 0;

            if (flag)
                throw new ValidationException(string.Format(Resources.UserRoleInUse));
        }

        public void SaveRoleResponsibility(RoleResponsibilityEntity entity)
        {
            EntityValidator.Validate(entity);
            base.Save(entity);
        }

        public IEnumerable<RoleResponsibilityEntity> GetAllRoleResponsibilities()
        {
            using (var s = Store.OpenSession())
                return s.Query<RoleResponsibilityEntity>().ToList();
        }

        public void DeleteRoleResponsibilityById(string id)
        {
            checkIsUserResponsibilityIsInUse(id);
            base.DeleteById(id);
        }

        private void checkIsUserResponsibilityIsInUse(string id)
        {
            var userRoles = new List<UserRoleEntity>();
            using (var s = Store.OpenSession())
                userRoles = s.Query<UserRoleEntity>().ToList();

            var isRoleResponsibility = false;

            foreach (var userRole in userRoles)
                isRoleResponsibility = userRole.Responsibilities.Where(r => r.Id == id).Count() > 0;

            if (isRoleResponsibility)
                throw new ValidationException(string.Format(Resources.UserResponsibilityInUse));
        }
    }
}
