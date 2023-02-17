using CatalogService.Api.Request;
using CatalogService.Api.ValidationRules;
using FluentValidation;

namespace CatalogService.Api.Validators
{
    /// <summary>
    /// The validator for BookRequestUpdate model
    /// </summary>
    public class BookValidatorUpdate : AbstractValidator<BookRequestUpdate>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BookValidatorUpdate"/>
        /// </summary>
        public BookValidatorUpdate()
        {
            RuleFor(e => e.Title)
                .MustValidName();
            RuleFor(e => e.Author)
                .MustValidName();
            RuleFor(e => e.Price)
                .NotEmpty()
                .NotNull();
        }
    }
}
