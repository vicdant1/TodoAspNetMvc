using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TodoApp.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static List<string> GetModelValidationErrorMessages(this ModelStateDictionary model)
        {
            List<string> errorMessages = new();

            if (model != null && model.Values.Any(error => error.ValidationState == ModelValidationState.Invalid))
            {
                var validations = model.Values.Where(error => error.ValidationState != ModelValidationState.Valid).ToArray();
                foreach (var validation in validations)
                    foreach (var message in validation.Errors)
                        errorMessages.Add(message.ErrorMessage.ToString());
            }

            return errorMessages;
        }

        public static string GetNormalizedStringErrorMessages(this ModelStateDictionary model)
        {
            string returnErrors = string.Empty;
            var errors = GetModelValidationErrorMessages(model);
            if (errors != null)
                returnErrors = String.Join("\n", errors);

            return returnErrors;
        }
    }
}
