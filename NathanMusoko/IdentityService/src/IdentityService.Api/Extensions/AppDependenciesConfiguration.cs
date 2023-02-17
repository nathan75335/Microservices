using IdentityService.Api.Mappings.Profiles;
using IdentityService.BusinessLogic.Services;
using IdentityService.DataAccess.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using IdentityService.Api.Middlewares;
using HealthChecks.UI.Client;
using FluentValidation;
using IdentityService.Api.Validation.Validators;
using FluentValidation.AspNetCore;
using IdentityService.BusinessLogic.SeedData;
using IdentityService.DataAccess;

namespace IdentityService.Api.Extensions
{
    /// <summary>
    /// The configuration of services of the application
    /// </summary>
    public partial class AppDependenciesConfiguration
    {
        /// <summary>
        /// Function to add services to the application builder
        /// </summary>
        /// <param name="builder">The application builder</param>
        /// <returns>A <see cref="WebApplicationBuilder"/></returns>
        public static WebApplicationBuilder ConfigureServicesApplication(this WebApplicationBuilder builder)
        {
            builder.AddLogger(builder.Configuration);
            builder.Services
                .AddIdentityServiceConfigutation(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Sql"));
                })
                .AddAutoMapper(typeof(UserProfile), typeof(ClaimProfile))
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IAuthorizationService, AuthorizationService>()
                .AddScoped<ISessionService, SessionService>()
                .AddScoped<SeedRolesData>()
                .AddHealthCheck(builder.Configuration)
                .AddValidatorsFromAssemblyContaining<UserRequestCreateValidator>()
                .AddFluentValidationAutoValidation();

            return builder;
        }

        /// <summary>
        /// Function to configure middlewares and endpoint of the application
        /// </summary>
        /// <param name="app">The <see cref="WebApplication"/></param>
        public static void Configure(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.AddSeedData();
        }
        
        /// <summary>
        /// Function to add seed data to the application
        /// </summary>
        /// <param name="app">The application</param>
        public static void AddSeedData(this WebApplication app)
        {
            var serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var handler = scope.ServiceProvider.GetRequiredService<IdentityContext>();

                handler.Database.Migrate();

                var service = scope.ServiceProvider.GetRequiredService<SeedRolesData>();

                service.SeedData();
            }
        }
    }
}
