using System;
using System.ComponentModel.DataAnnotations;
using Gravity.Root.Properties;

namespace Gravity.Root.Entities
{
    public class Credentials
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "LoginNameCannotBeEmpty")]
        public string LoginName { get; set; }
        public string Password { get; set; }

        public static Credentials New()
        {
            return new Credentials();
        }

        public static Credentials New(string loginName, string password)
        {
            var result = New();
            result.LoginName = loginName;
            result.Password = string.IsNullOrWhiteSpace(password) ? null : password;
            return result;
        }

        public static bool IsPasswordConfirms(string password, string confirmPassword)
        {
            return (string.Equals(password, confirmPassword, StringComparison.Ordinal));
        }
    }
}
