using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var host = builder.Host
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
    })
    .ConfigureLogging((hostingContext, logginbuilder) =>
    {
        logginbuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        logginbuilder.AddConsole();
        logginbuilder.AddDebug();
    });

builder.Services.AddOcelot();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

await app.UseOcelot();

app.Run();