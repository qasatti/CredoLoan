using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CredoLoan.Api.Extensions
{
    public static class ModelStateExtensions
    {
        public static string GetErrors(this ModelStateDictionary modelState)
        {
            return string.Join(Environment.NewLine, modelState.SelectMany(x => x.Value.Errors.Select(x => x.ErrorMessage)));
        }
    }
}
