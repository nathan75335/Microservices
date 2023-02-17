using System.Runtime.InteropServices.ComTypes;
using CustomValidation.Api.Models;
using CustomValidation.Api.ValidationHelpers;

namespace CustomValidation.Api.Validators;

public class WeatherForecastValidator : AbstractValidator<WeatherForecast>
{
    public override void ValidateModel(WeatherForecast model)
    {
        model.IsRequired($"{model.GetType()}", true);
        model.ValidDate(i => i.Date.Year > 2022);
        model.TemperatureF.ValidTemperature(i => i < 1000);
        model.Summary.IsRequired("Summary", true);
        model.Summary.MustNotContainNumberAndCaractere("#1234547678790*");
    }
}
