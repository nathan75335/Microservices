using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace CatalogService.Api.Extensions
{
    /// <summary>
    /// The configuration of Logger service
    /// </summary>
    public static partial class AppDependenciesConfiguration
    {
        /// <summary>
        /// Configure the Logger service
        /// </summary>
        /// <param name="builder">The builder</param>
        /// <returns>A <see cref="WebApplication"/></returns>
        public static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
        {
            var config = builder.Configuration;

            builder.Host.UseSerilog((context, configuration) =>
            {
                configuration.Enrich.FromLogContext()
                 .Enrich.WithMachineName()
                 .WriteTo.Console()
                 .ReadFrom.Configuration(config);

                configuration.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(config["ElasticConfiguration:Uri"]))
                {
                    IndexFormat = $"{context.Configuration["ApplicationName"]} -logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                    AutoRegisterTemplate = true,
                    NumberOfShards = 2,
                    NumberOfReplicas = 1
                })
                   .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName);
            });

            return builder;
        }
    }
}
