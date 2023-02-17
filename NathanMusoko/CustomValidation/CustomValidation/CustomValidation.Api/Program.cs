using CustomValidation.Api.Extensions;
using CustomValidation.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//.Services.AddValidation(WeatherForecastValidator);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionsHandlerMiddleware>();

app.UseValidation();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
