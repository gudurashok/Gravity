using System.ComponentModel.DataAnnotations;

namespace Scalable.Shared.Common
{
    public static class EntityValidator
    {
        public static void Validate(object entity)
        {
            Validate(entity, false);
        }

        public static void Validate(object entity, bool validateAllProperties)
        {
            var validationContext = new ValidationContext(entity, null, null);
            Validator.ValidateObject(entity, validationContext);



            //var validationContext = new ValidationContext(entity, null, null);
            //var validationResults = new List<ValidationResult>();
            //Validator.TryValidateObject(entity, validationContext, validationResults, validateAllProperties);

            //var validationResults = new List<ValidationResult>();
            //Validator.TryValidateObject(entity, validationContext, validationResults);
            //Validator.TryValidateObject(entity, validationContext, validationResults, true);

            //Validator.ValidateObject(entity, validationContext);
            //Validator.ValidateObject(entity, validationContext, true);
            //ValidationException

            //if (validationResults.Count > 0) return;
            //throw new ValidationException(validationResults[0].ErrorMessage, validationResults[0].MemberNames.First());
        }
    }
}
