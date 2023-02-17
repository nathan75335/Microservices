using CustomValidation.Api.Models;
using CustomValidation.Api.Validators;
using Newtonsoft.Json;

namespace CustomValidation.Api.Middleware;

public class ValidationMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        
        var body = context.Request.Body;
        using StreamReader reader = new StreamReader(body);
        var request = await reader.ReadToEndAsync();
        
        if (request.Length  != 0 )
        {
            var settings = new JsonSerializerSettings
            {
                Converters = 
                {
                    new AbstractConverter<WeatherForecast, IModelValidation>(),
                    new AbstractConverter<Student, IModelValidation>()
                }
            };

            var modelValidation = JsonConvert.DeserializeObject<IModelValidation>(request, settings);
            
            if (modelValidation.GetType() == typeof(WeatherForecast))
            {
                var model = JsonConvert.DeserializeObject<WeatherForecast>(request, settings);
                var service = context.RequestServices.GetRequiredService<AbstractValidator<WeatherForecast>>();
                service.ValidateModel(model);
                
            }else if (modelValidation.GetType() == typeof(Student))
            {
                var model = JsonConvert.DeserializeObject<Student>(request, settings);
                var service = context.RequestServices.GetRequiredService<AbstractValidator<Student>>();
                service.ValidateModel(model);
        
            }
            
        }

        _next(context);
    }
}
