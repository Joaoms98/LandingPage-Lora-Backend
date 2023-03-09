using LandingPage.Lora.Infrastructure.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace LandingPage.Lora.Api.Configurations;

public static class ConfigureDomainServices
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        IoCWrapper.ConfigureDomainServices(services);
        IoCWrapper.RegisterUseCases(services);

        return services;
    }
}
