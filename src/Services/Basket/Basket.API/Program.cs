using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Discount.Grpc.Protos;
using MassTransit;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// General Configuration
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

// Grpc Configuration
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
  (o => o.Address = new Uri(configuration["GrpcSettings:DiscountUrl"]));

builder.Services.AddScoped<DiscountGrpcService>();

// Grpc Configurationß
builder.Services.AddMassTransit(config => {
  config.UsingRabbitMq((ctx, cfg) => {
      cfg.Host(configuration["EventBusSettings:HostAddress"]);
  });
});

builder.Services.AddMassTransitHostedService();

// Redis Configuration
builder.Services.AddStackExchangeRedisCache(options =>
{
  options.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
