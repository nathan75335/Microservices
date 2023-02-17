using CustomValidation.Api.Models;
using CustomValidation.Api.ValidationHelpers;

namespace CustomValidation.Api.Validators;

public class StudentValidator : AbstractValidator<Student>
{
    public override void ValidateModel(Student model)
    {
        model.School
            .IsRequired("School", true)
            .MustNotContainNumberAndCaractere("$Q#!*&$");
        model.Name.IsRequired("Name", true);
    }
}
