using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.WebApi;
using CleanArchitecture.WebApi.Filters;
using CleanArchitecture.WebApi.Modules;
using Microsoft.AspNetCore.Builder;
using Serilog;

//serilog setting
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Warning()
    .CreateLogger();

try
{
    //serilog message
    Log.Information("Starting web application");


    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSerilog();


    builder.Services.AddControllers(opt =>
    {
        opt.Filters.Add<GlobalExceptionFilter>();
    });
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

    builder.Services.AddSwaggerGen();

    builder.Services.AddCustomOpenApiDocument();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddWebApi(builder.Configuration);


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}