using InPay__CuriousCat_BackEnd.Domain.Services;

namespace InPay__CuriousCat_BackEnd.Config;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddServicesLayer(this IServiceCollection services)
    {

        services.AddScoped<UserServices>();


        return services;
    }
}