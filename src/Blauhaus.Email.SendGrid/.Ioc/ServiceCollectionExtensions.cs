using Blauhaus.Email.Abstractions.Dispatcher;
using Blauhaus.Email.Abstractions.EmailBuilder;
using Blauhaus.Email.Common.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Email.SendGrid.Ioc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSendGridEmailSender(this IServiceCollection services, Action<SendGridOptions> options)
    {
        services.Configure(options);
        services.AddScoped<IEmailDispatcher, SendGridEmailDispatcher>();
        services.AddEmailservices();
        return services;
    }
     

}