using CustomValidation.Api.Middleware;
using CustomValidation.Api.Validators;

namespace CustomValidation.Api.Extensions;

public static class AppDependenciesConfifuration
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddTransient<AbstractValidator<WeatherForecast>, WeatherForecastValidator>();
        services.AddTransient<AbstractValidator<Student>, StudentValidator>();

        return services;
    }

    public static void UseValidation(this WebApplication app)
    {
        app.UseMiddleware<ValidationMiddleware>();
    }
}
