using LandingPage.Lora.Infrastructure.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace LandingPage.Lora.Api.Configurations;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        IoCWrapper.RegisterServices(services);

        return services;
    }
}
    