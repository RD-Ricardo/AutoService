namespace AutoService.Application.Extensions
{
    public static class ValidationResultExtension
    {
        public static IEnumerable<string> ReturnErros(this FluentValidation.Results.ValidationResult validationResult) =>
           validationResult.Errors.Select(e => e.ErrorMessage);
    }
}
