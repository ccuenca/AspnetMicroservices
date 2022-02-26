using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

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

builder.Services.AddOcelot()
    .AddCacheManager(settings =>
    {
        settings.WithDictionaryHandle();
    });

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

await app.UseOcelot();

app.Run();