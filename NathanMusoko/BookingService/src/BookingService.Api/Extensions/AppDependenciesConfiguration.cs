using BookingService.Api.Middleware;
using BookingService.Api.Profiles;
using BookingService.Api.Validators;
using BookingService.BusinessLogic.Jobs;
using BookingService.BusinessLogic.RabbitMq;
using BookingService.BusinessLogic.Services;
using BookingService.DataAccess;
using BookingService.DataAccess.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.SqlServer;
using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Api.Extensions
{
    /// <summary>
    /// Configurartion of services and midllewares
    /// </summary>
    public static partial class AppDependenciesConfiguration
    {
        /// <summary>
        /// Configure the services
        /// </summary>
        /// <param name="builder">The builder</param>
        /// <returns>A <see cref="WebApplicationBuilder"/></returns>
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.AddLogger(builder.Configuration);

            builder.Services
                .AddBookingDatabase(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")))
                .AddHealthCheck(builder.Configuration)
                .AddRepositories()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IMessageSenderRabbitMq, MessageSenderRabbitMq>()
                .AddValidatorsFromAssemblyContaining<OrderRequestValidator>()
                .AddFluentValidationAutoValidation()
                .AddAutoMapper(typeof(OrderProfile));

            builder.Services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(builder.Configuration.GetConnectionString("ConnectionString"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            builder.Services.AddHangfireServer(options => options.SchedulePollingInterval = TimeSpan.FromSeconds(1));

            return builder;
        }

        /// <summary>
        /// Configure midlleware
        /// </summary>
        /// <param name="app">The web application</param>
        public static void Configure(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.InitializeDatabase();

            app.UseHangfireDashboard();

            RecurringJob.AddOrUpdate<SenderNotificationJob>("print-time", service =>
            service.SendNotificationToReturnBook(), Cron.Daily);
        }

        /// <summary>
        /// Initialize the database 
        /// </summary>
        /// <param name="app">The application</param>
        public static void InitializeDatabase(this WebApplication app)
        {
            var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>();

            using (var service = serviceScope.CreateScope())
            {
                var databaseService = service.ServiceProvider.GetRequiredService<OrderContext>();

                databaseService.Database.Migrate();
            }
        }
    }
}
