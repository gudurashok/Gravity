using System;
using Gravity.Root.Entities;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using System.ComponentModel.DataAnnotations;
using Gravity.Root.Properties;
using Gravity.Root.Repositories;

namespace Gravity.Root.Services
{
    public static class AuthenticationService
    {
        #region Authentication

        public static User AuthenticateWithRootCredentials(Credentials credentials)
        {
            EntityValidator.Validate(credentials);
            var builtinUser = User.GetRootLoginUser();
            if (!builtinUser.CredentialsMatch(credentials))
                throwIncorrectLoginException();

            return builtinUser;
        }

        public static User Authenticate(Credentials credentials)
        {
            EntityValidator.Validate(credentials);

            var users = new Users();
            var user = users.GetByLoginName(credentials.LoginName);

            if (loginIsIncorrect(credentials, user))
                throwIncorrectLoginException();

            if (loginIsDisabled(user))
                throwLoginDisabledException();

            return user;
        }

        #endregion

        #region Helper Methods

        private static bool loginIsIncorrect(Credentials credentials, User user)
        {
            return loginNotFound(user) || passowrdDoesNotMatch(user, credentials.Password);
        }

        private static bool loginNotFound(User user)
        {
            return user == null;
        }

        private static bool passowrdDoesNotMatch(User user, string password)
        {
            return (!string.Equals(user.Entity.Credentials.Password, password, StringComparison.Ordinal));
        }

        private static void throwIncorrectLoginException()
        {
            throwValidationException(Resources.IncorrectLogin);
        }

        private static bool loginIsDisabled(User user)
        {
            return !user.Entity.IsActive;
        }

        private static void throwLoginDisabledException()
        {
            throwValidationException(Resources.LoginDisabled);
        }

        private static void throwValidationException(string errorMessage)
        {
            var result = new ValidationResult(errorMessage, new[] { "LoginName" }); //TODO... constant? (used to for focusing to login name textbox)
            throw new ValidationException(result, null, null);
        }

        #endregion
    }
}
