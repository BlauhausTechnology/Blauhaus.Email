using Blauhaus.Email.Abstractions.EmailBuilder;
using Blauhaus.Email.Common.Builder;

namespace Blauhaus.Email.Common.Resolvers;

public class EmailBuilderResolver : IEmailBuilderResolver
{
    private readonly IServiceProvider _serviceProvider;

    public EmailBuilderResolver(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IEmailBuilder Resolve(Guid id)
    {
        return EmailBuilderRegistry.BuilderResolvers.TryGetValue(id, out var customBuilder) 
            ? customBuilder.Invoke(_serviceProvider) 
            : new SimpleEmailBuilder();
    }
}