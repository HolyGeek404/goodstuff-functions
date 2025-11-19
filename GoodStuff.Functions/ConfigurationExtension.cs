using GoodStuff.Functions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GoodStuff.Functions;

public static class ConfigurationExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IFunctionService, FunctionService>();
        services.AddScoped<IHttpRequestMessageProvider, HttpRequestMessageProvider>();
        services.AddScoped<ITokenProviderService, TokenProviderService>();
        
        return services;
    }
}