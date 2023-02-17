using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace GatewayService.Api.Extensions;

/// <summary>
/// Configuration of the services 
/// </summary>
public static partial  class AppDependenciesConfiguration
{
    /// <summary>
    /// Function to configure the services
    /// </summary>
    /// <param name="builder">The builder</param>
    /// <returns>A <see cref="WebApplicationBuilder"/></returns>
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile("ocelot.json")
            .AddJsonFile($"ocelot.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional:true)
            .AddEnvironmentVariables(); 
        builder.AddLogger();
        builder.Services.AddOcelot();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["JWT:Issuer"],
                ValidAudience = builder.Configuration["JWT:Audience"],
                RequireExpirationTime = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true
            };
        });

        return builder;
    }
    
    /// <summary>
    /// Function to configure the different middleware in the application
    /// </summary>
    /// <param name="app">The web application</param>
    public static void Configure(this WebApplication app)
    {
        app.UseOcelot().Wait();

        app.UseAuthentication();
    }
}
