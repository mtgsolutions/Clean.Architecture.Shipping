using Clean.Architecture.Application.Services.Contracts;
using Clean.Architecture.Application.Services.Implementations;
using Clean.Architecture.Infrastructure.DependencyInjections;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Architecture.Application.DependencyInjections;

public static class DependencyInjecionApplicationHelper
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddInfrastructure()
            .AddApplicationServices();


        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IShippingOrderService, ShippingOrderService>();
        services.AddScoped<IShippingServiceService, ShippingServiceService>();

        return services;
    }

}
