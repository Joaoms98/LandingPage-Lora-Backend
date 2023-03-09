using LandingPage.Lora.Domain.Interfaces;
using LandingPage.Lora.Domain.Interfaces.Services;
using LandingPage.Lora.Infrastructure.Repositories;
using LandingPage.Lora.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LandingPage.Lora.Infrastructure.IoC;

public static class IoCWrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IFileService, AzureFileService>();
        // services.AddScoped<IFileService, LocalFileService>();
    }

    public static void RegisterUseCases(IServiceCollection services)
    {
    }

    public static void ConfigureDomainServices(IServiceCollection services)
    {
    }
}
