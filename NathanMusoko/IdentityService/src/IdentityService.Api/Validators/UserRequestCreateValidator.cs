using FluentValidation;
using IdentityService.Api.Request;
using IdentityService.Api.Validation.ValidationRules;

namespace IdentityService.Api.Validation.Validators
{
    /// <summary>
    /// The validator for the user create request
    /// </summary>
    public class UserRequestCreateValidator : AbstractValidator<UserRequestCreate>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UserRequestCreateValidator"/>
        /// </summary>
        public UserRequestCreateValidator()
        {
            RuleFor(x => x.Email)
                .MustValidEmail();
            RuleFor(x => x.Password)
                .MustValidPassword();
            RuleFor(x => x.ConfirmedPassword)
                .Equal(x => x.Password);
            RuleFor(x => x.PhoneNumber)
                .MustValidPhoneNumber();
            RuleFor(x => x.FirstName)
                .MustValidName();
            RuleFor(x => x.LastName)
                .MustValidName();
        }
    }
}
