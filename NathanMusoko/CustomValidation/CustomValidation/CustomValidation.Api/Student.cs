using CustomValidation.Api.Models;

namespace CustomValidation.Api;

public class Student : IModelValidation
{
    public string Name { get; set; }
    public string School { get; set; }
}
