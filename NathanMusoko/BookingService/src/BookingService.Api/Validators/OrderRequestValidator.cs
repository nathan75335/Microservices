using BookingService.Api.Requests;
using BookingService.Api.ValidationRules;
using FluentValidation;

namespace BookingService.Api.Validators
{
    /// <summary>
    /// The validator for order request model
    /// </summary>
    public class OrderRequestValidator : AbstractValidator<OrderRequest>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="OrderRequestValidator"/>
        /// </summary>
        public OrderRequestValidator()
        {
            RuleFor(x => x.UserEmail)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("The user email must not be null");

            RuleFor(x => x.BookId)
                .NotNull()
                .NotEmpty()
                .WithMessage("The user Id must not be null");

            RuleFor(x => x.ReturnBookDate)
                .MustValidateDate();

            RuleFor(x => x.BorrowBookDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Invalid date");
        }
    }
}
