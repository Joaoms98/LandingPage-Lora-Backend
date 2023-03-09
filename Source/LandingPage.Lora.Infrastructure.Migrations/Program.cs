using LandingPage.Lora.Infrastructure.Migrations;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var connectionStr = config.GetConnectionString("LoraConnection");

var migrator = new Migrator(connectionStr, true);
migrator.Run();