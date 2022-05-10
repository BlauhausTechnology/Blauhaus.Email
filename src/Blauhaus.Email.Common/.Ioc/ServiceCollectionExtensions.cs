using Blauhaus.Email.Abstractions.EmailBuilder;
using Blauhaus.Email.Common.Resolvers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Blauhaus.Email.Common.Ioc;

public static class ServiceCollectionExtensions
{


    public static IServiceCollection AddEmailservices(this IServiceCollection services) 
    {
        services.TryAddTransient<IEmailBuilderResolver, EmailBuilderResolver>();
        return services;
    }

    public static IServiceCollection AddEmailBuilder<TBuilder>(this IServiceCollection services, Guid id) where TBuilder : class, IEmailBuilder
    {
        EmailBuilderRegistry.AddEmailBuilder<TBuilder>(id);
        return services;

    }

}