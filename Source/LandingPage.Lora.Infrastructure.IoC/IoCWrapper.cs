using LandingPage.Lora.Domain.Interfaces;
using LandingPage.Lora.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LandingPage.Lora.Infrastructure.IoC;

public static class IoCWrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void RegisterUseCases(IServiceCollection services)
    {
    }

    public static void ConfigureDomainServices(IServiceCollection services)
    {
    }
}
