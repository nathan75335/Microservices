using FluentValidation;

namespace BookingService.Api.ValidationRules
{
    /// <summary>
    /// The validation rules for the models
    /// </summary>
    public static class ModelValidationRules
    {
        /// <summary>
        /// validation rules for the time
        /// </summary>
        /// <typeparam name="T"> is T</typeparam>
        /// <param name="rulebuilder">The rule builder</param>
        /// <returns>A <see cref="IRuleBuilderOptions<T, DateTimeOffset>"/></returns>
        public static IRuleBuilderOptions<T, DateTimeOffset> MustValidateDate<T>(this IRuleBuilder<T, DateTimeOffset> rulebuilder)
        {
            var builder = rulebuilder
                .NotNull()
                .NotEmpty()
                .GreaterThan(x => DateTimeOffset.Now)
                .WithMessage("Invalid Date");

            return builder;
        }
    }
}
