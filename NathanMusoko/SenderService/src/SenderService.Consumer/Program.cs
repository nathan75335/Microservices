using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SenderService.Consumer.Extensions;
using Serilog;

internal class Program
{
    public static void Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler((sender, eventArgs) =>
        {
            Log.Logger.Error($"an error occured {eventArgs.ExceptionObject}");
            Console.WriteLine("Press Enter To continue");
            Console.ReadLine();
            Environment.Exit(1);
        });

        var builder = new ConfigurationBuilder();
        BuildConfig(builder);

        Console.WriteLine(builder.Build()["ElasticConfiguration:Uri"]);
        var host = Host.CreateDefaultBuilder()
            .AddLogger(builder.Build())
            .ConfigureServices((hostContext, services) =>
            {
                services.ConfigureServices();
            })
            .UseConsoleLifetime()
            .Build();

        host.Run();
    }

    static void BuildConfig(IConfigurationBuilder builder)
    {
        builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development" }.json", optional:true)
                                .AddEnvironmentVariables(); 
    }
}
