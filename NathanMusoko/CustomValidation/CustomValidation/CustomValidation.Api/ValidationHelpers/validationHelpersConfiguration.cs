using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using CustomValidation.Api.Exceptions;
using Microsoft.OpenApi.Any;


namespace CustomValidation.Api.ValidationHelpers;

public static class ValidationHelpersConfiguration
{
    public static void IsRequired<TProperty>(this TProperty property, string name,  bool isNull = false) 
    {
        if (isNull)
        {
            if (property is null)
            {
                throw new NullException($"The property {name} can not be null");
            }
        }
    }
    
    public static string IsRequired(this string property, string name,  bool isNull = false)
    {
        if (isNull)
        {
            if (property.Length == 0)
            {
                throw new NullException($"The property {name} can not be null");
            }
        }

        return property;
    }

    public static string MustNotContainNumberAndCaractere(this string property, string caracteres)
    {
        StringBuilder builder = new StringBuilder(10);
        
        foreach (var caractere in caracteres)
        {
            if (property.Contains(caractere))
            {
                builder.Append(caractere);
            }
        }

        var sentence = builder.ToString();
        
        Console.WriteLine(sentence);
        
        if (sentence.Length != 0)
        {
            throw new ArgumentException($"Can not contain those caracteres {sentence}");
        }

        return property;
    }

    public static void ValidDate(this WeatherForecast weatherForecast, Predicate<DateTime> predicate) 
    {
        if (predicate(weatherForecast.Date) == false)
        {
            throw new ArgumentException("The date is not valid");
        }
    }

    public static void ValidTemperature(this int temperature, Predicate<int> predicate)
    {
        if (predicate(temperature) == false)
        {
            throw new ArgumentException("The temperature is not valid");
        }
    }
}
