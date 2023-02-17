using CatalogService.Api.Request;
using CatalogService.Api.ValidationRules;
using FluentValidation;

namespace CatalogService.Api.Validators
{
    /// <summary>
    /// The validator for BookRequestCreate model
    /// </summary>
    public class BookValidatorCreate :AbstractValidator<BookRequestCreate>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BookValidatorCreate"/>
        /// </summary>
        public BookValidatorCreate()
        {
            RuleFor(e => e.Title)
                .MustValidName();
            RuleFor(e => e.Author)
                .MustValidName();
            RuleFor(e => e.CreationDate)
                .NotEmpty()
                .NotNull()
                .LessThan(DateTimeOffset.Now);
            RuleFor(e => e.Price)
                .NotEmpty()
                .NotNull();
        }
    }
}
