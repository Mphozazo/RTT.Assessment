using RTT.Assessment.Application;
using RTT.Assessment.Persistence;
using RTT.Assessment.WebApi;
using RTT.Assessment.WebApi.Middleware;
using Serilog;
try
{
    Log.Information("Starting web host");
    var builder = WebApplication.CreateBuilder(args);

    // Add serilog logging
    builder.Host.UseSerilog((context, services, loggerConfiguration) =>
        loggerConfiguration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext());

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //Cors configuration
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

    // RTT service registration for each layer and other services
    //builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.AddApplicationServiceRegistration();
    builder.Services.AddPersistenceServiceRegistration(builder.Configuration);
    builder.Services.AddExcelBuilderRegisterServices();



    // Add services to the container.
    var app = builder.Build();

    app.UseMiddleware<ExceptionMiddleware>();
    // Log each HTTP request (method, path, status code, duration)
    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "RTT Assessment API v1");
        });
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();



}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}   
