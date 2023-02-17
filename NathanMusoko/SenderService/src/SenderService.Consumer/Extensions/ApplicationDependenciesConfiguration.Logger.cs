using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace SenderService.Consumer.Extensions
{
    /// <summary>
    /// Configuration of the logger
    /// </summary>
    public static partial class ApplicationDependenciesConfiguration
    {
        /// <summary>
        /// Configure the logger of the application
        /// </summary>
        /// <param name="builder">The builder</param>
        /// <param name="config">The configuration</param>
        /// <returns>A <see cref="IHostBuilder"/></returns>
        public static IHostBuilder AddLogger(this IHostBuilder builder, IConfiguration config)
        {
            Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
                   .Enrich.WithMachineName()
                   .WriteTo.Console()
                   .ReadFrom.Configuration(config)
                   .CreateLogger();
            builder.UseSerilog((context, configuration) =>
            {
                configuration.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                {
                    IndexFormat = $"sender-service-app -logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                    AutoRegisterTemplate = true,
                    NumberOfShards = 2,
                    NumberOfReplicas = 1
                })
                   .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName);
            });

            return builder.UseSerilog();
        }
    }
}
