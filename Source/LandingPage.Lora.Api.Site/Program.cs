using LandingPage.Lora.Api.Configurations;
using LandingPage.Lora.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string mySqlConnection =
              builder.Configuration.GetConnectionString("LoraConnection");

builder.Services.AddDbContextPool<LoraDbContext>(opt =>
                opt.UseMySql(mySqlConnection,ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddApplicationServices();
builder.Services.AddDomainServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{   
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.Run();
