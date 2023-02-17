using FluentValidation;
using IdentityService.Api.Request;
using IdentityService.Api.Validation.ValidationRules;

namespace IdentityService.Api.Validators
{
    /// <summary>
    /// The validator fot he user login request
    /// </summary>
    public class UserRequestLoginValidator : AbstractValidator<UserRequestLogin>
    {
       /// <summary>
       /// Initilizes a new instance of <see cref="UserRequestLoginValidator"/>
       /// </summary>
        public UserRequestLoginValidator()
        {
            RuleFor(x => x.Email)
                .MustValidEmail();
            RuleFor(x => x.Password)
                .MustValidPassword();
        }
    }
}
