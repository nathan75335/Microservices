using CustomValidation.Api.Models;

namespace CustomValidation.Api.Validators;

public abstract class AbstractValidator<T> where T : IModelValidation
{
    public abstract void ValidateModel(T model);
}
