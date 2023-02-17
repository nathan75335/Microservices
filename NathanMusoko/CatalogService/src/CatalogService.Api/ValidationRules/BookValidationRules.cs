using FluentValidation;

namespace CatalogService.Api.ValidationRules
{
    /// <summary>
    /// 
    /// </summary>
    public static class BookValidationRules
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, string> MustValidName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builderOptions = ruleBuilder
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20)
                .WithMessage("Invalid Name");

            return builderOptions;
        }

    }
}
