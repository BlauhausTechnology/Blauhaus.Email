using Blauhaus.Email.Server.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Email.Server.SendGrid.Ioc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSendGridEmailSender(this IServiceCollection services, Action<SendGridOptions> options)
    {
        services.Configure(options);
        services.AddScoped<IEmailDispatcher, SendGridEmailDispatcher>();
        return services;
    }
}