using FluentValidation;
using IdentityService.Api.Request;
using IdentityService.Api.Validation.ValidationRules;

namespace IdentityService.Api.Validators
{
    /// <summary>
    /// The validator for the user update request
    /// </summary>
    public class UserRequestUpdateValidator : AbstractValidator<UserRequestUpdate>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UserRequestUpdateValidator"/>
        /// </summary>
        public UserRequestUpdateValidator()
        {
            RuleFor(x => x.Email)
                    .MustValidEmail();
            RuleFor(x => x.Password)
                    .MustValidPassword();
            RuleFor(x => x.PhoneNumber)
                    .MustValidPhoneNumber();
            RuleFor(x => x.FirstName)
                    .MustValidName();
            RuleFor(x => x.LastName)
                    .MustValidName();
        }
    }
}
