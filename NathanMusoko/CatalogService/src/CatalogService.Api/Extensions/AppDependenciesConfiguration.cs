using CatalogService.Api.Middlewares;
using CatalogService.Api.Profiles;
using CatalogService.Api.Validators;
using CatalogService.BusinessLogic.Services;
using CatalogService.DataAccess.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text;
using System.Text.Json;

namespace CatalogService.Api.Extensions
{
    /// <summary>
    /// The configuration of the services of the applications
    /// </summary>
    public static partial class AppDependenciesConfiguration
    {
        /// <summary>
        /// Function to configure the service of the web application
        /// Function to configure the service of the web application
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.AddLogger();

            builder.AddLogger();

            builder.Services
                .AddCatalogDbContext(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString")))
                .AddRepositories()
                .AddScoped<IBookService, BookService>()
                .AddScoped<IEditionHouseService, EditionHouseService>()
                .AddScoped<IGenreService, GenreService>()
                .AddHealthCheck(builder.Configuration)
                .AddValidatorsFromAssemblyContaining<BookValidatorCreate>()
                .AddFluentValidationAutoValidation()
                .AddAutoMapper(typeof(BookProfile), typeof(EditionHouseProfile), typeof(GenreProfile));

            return builder;
        }

        /// <summary>
        /// Function to configure the application
        /// </summary>
        /// <param name="app"><see cref="IApplicationBuilder"/></param>
        public static void Configure(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.MapHealthChecks("/health", new HealthCheckOptions()
             {
                 Predicate = (check) => !check.Tags.Contains("services"),
                 AllowCachingResponses = false,
                 ResponseWriter = WriteResponse,
             });
        }

        /// <summary>
        /// Function to write the response
        /// </summary>
        /// <param name="context">The http context</param>
        /// <param name="result">The result</param>
        /// <returns></returns>
        private static Task WriteResponse(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions
            {
                Indented = true
            };

            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream, options))
            {
                writer.WriteStartObject();
                writer.WriteString("status", result.Status.ToString());
                writer.WriteStartObject("results");
                foreach (var entry in result.Entries)
                {
                    writer.WriteStartObject(entry.Key);
                    writer.WriteString("status", entry.Value.Status.ToString());
                    writer.WriteEndObject();
                }
                writer.WriteEndObject();
                writer.WriteEndObject();
            }

            var json = Encoding.UTF8.GetString(stream.ToArray());

            return context.Response.WriteAsync(json);
        }

        /// <summary>
        /// Function to configure the application
        /// </summary>
        /// <param name="app"><see cref="IApplicationBuilder"/></param>
        public static void Configure(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.MapHealthChecks("/health", new HealthCheckOptions()
             {
                 Predicate = (check) => !check.Tags.Contains("services"),
                 AllowCachingResponses = false,
                 ResponseWriter = WriteResponse,
             });
        }

        /// <summary>
        /// Function to write the response
        /// </summary>
        /// <param name="context">The http context</param>
        /// <param name="result">The result</param>
        /// <returns></returns>
        private static Task WriteResponse(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions
            {
                Indented = true
            };

            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream, options))
            {
                writer.WriteStartObject();
                writer.WriteString("status", result.Status.ToString());
                writer.WriteStartObject("results");
                foreach (var entry in result.Entries)
                {
                    writer.WriteStartObject(entry.Key);
                    writer.WriteString("status", entry.Value.Status.ToString());
                    writer.WriteEndObject();
                }
                writer.WriteEndObject();
                writer.WriteEndObject();
            }

            var json = Encoding.UTF8.GetString(stream.ToArray());

            return context.Response.WriteAsync(json);
        }
    }
}
