using Blauhaus.Email.Abstractions.EmailBuilder;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.Email.Common.Resolvers;

internal static class EmailBuilderRegistry
{
    internal static Dictionary<Guid, Func<IServiceProvider, IEmailBuilder>> BuilderResolvers { get; } = new();

    public static void AddEmailBuilder<TEmailBuilder>(Guid id) where TEmailBuilder : class, IEmailBuilder
    {
        BuilderResolvers[id] = serviceProvider => serviceProvider.GetRequiredService<TEmailBuilder>();
    }
    internal static IEmailBuilder Resolve(IServiceProvider serviceProvider, Guid id)
    {
        return BuilderResolvers[id].Invoke(serviceProvider);
    }

}