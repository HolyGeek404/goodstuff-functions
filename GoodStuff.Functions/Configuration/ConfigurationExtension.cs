using GoodStuff.Functions.Functions.EmailNotification.Services;
using GoodStuff.Functions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GoodStuff.Functions.Configuration;

public static class ConfigurationExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailNotificationService, EmailNotificationService>();
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}
