using FluentValidation;

namespace IdentityService.Api.Validation.ValidationRules
{
    /// <summary>
    /// The model validations rules
    /// </summary>
    public static class ModelValidationRules
    {
        /// <summary>
        /// Rule to validate the email
        /// </summary>
        /// <typeparam name="T">T is <see cref="string"/></typeparam>
        /// <param name="ruleBuilder">The Rule Builder Options</param>
        /// <returns>A <see cref="IRuleBuilderOptions{T, string}"/></returns>
        public static IRuleBuilderOptions<T, string> MustValidEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Received invalid email");

            return builder;
        }

        /// <summary>
        /// Rule to validate the Name
        /// </summary>
        /// <typeparam name="T">T is <see cref="string"/></typeparam>
        /// <param name="ruleBuilder">The Rule Builder Options</param>
        /// <returns>A <see cref="IRuleBuilderOptions{T, string}"/></returns>
        public static IRuleBuilderOptions<T, string> MustValidName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .WithMessage("Invalid Name");

            return builder;
        }

        /// <summary>
        /// Rule To validate Number Phone
        /// </summary>
        /// <typeparam name="T">T is <see cref="string"/></typeparam>
        /// <param name="ruleBuilder">The Rule Builder Options</param>
        /// <returns>A <see cref="IRuleBuilderOptions{T, string}"/></returns>
        public static IRuleBuilderOptions<T, string> MustValidPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder
                .NotEmpty()
                .MinimumLength(9)
                .Matches(@"\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|
                    2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|
                    4[987654310]|3[9643210]|2[70]|7|1)\d{1,14}$")
                .WithMessage("Invalid Telephon Number");

            return builder;
        }

        /// <summary>
        /// Rule to validate Password
        /// </summary>
        /// <typeparam name="T">T is <see cref="string"/></typeparam>
        /// <param name="ruleBuilder">The Rule Builder Options</param>
        /// <returns>A <see cref="IRuleBuilderOptions{T, string}"/></returns>
        public static IRuleBuilderOptions<T, string> MustValidPassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builder = ruleBuilder
                .NotEmpty()
                .MinimumLength(10);

            return builder;
        }
    }
}
