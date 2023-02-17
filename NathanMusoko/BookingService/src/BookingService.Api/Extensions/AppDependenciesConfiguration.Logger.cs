using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace BookingService.Api.Extensions
{
    /// <summary>
    /// The application dependency Logger
    /// </summary>
    public static partial class AppDependenciesConfiguration
    {
        /// <summary>
        /// Function to add logger to the application
        /// </summary>
        /// <param name="builder">The web application builder</param>
        /// <param name="config">The configuraiton</param>
        /// <returns>The webapplication builder</returns>
        public static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder,
            IConfiguration config)
        {
            builder.Host.UseSerilog((context, configuration) =>
            {
                configuration.Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .WriteTo.Console()
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(config["ElasticConfiguration:Uri"]))
                    {
                        IndexFormat = $"{context.Configuration["ApplicationName"]}-logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                        AutoRegisterTemplate = true,
                        NumberOfShards = 2,
                        NumberOfReplicas = 1
                    })
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .ReadFrom.Configuration(config);
                
            });
        
            return builder;
        }
    }
}
