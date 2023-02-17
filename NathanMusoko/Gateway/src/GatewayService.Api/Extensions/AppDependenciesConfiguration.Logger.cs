using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace GatewayService.Api.Extensions;

/// <summary>
/// Configuration of the Logger in the applicaton
/// </summary>
public static partial class AppDependenciesConfiguration
{
    /// <summary>
    /// Configuration of the logger 
    /// </summary>
    /// <param name="builder">The builder</param>
    /// <returns>A <see cref="WebApplicationBuilder"/></returns>
    public static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Console()
                .ReadFrom.Configuration(builder.Configuration);

            configuration.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(builder.Configuration["ElasticConfiguration:Uri"]))
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
