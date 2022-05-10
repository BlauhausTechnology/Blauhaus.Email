using Blauhaus.Email.Abstractions.EmailBuilder;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.Email.TestHelpers.MockBuilders;

public class EmailBuilderResolverMockBuilder : BaseMockBuilder<EmailBuilderResolverMockBuilder, IEmailBuilderResolver>
{
    public EmailBuilderResolverMockBuilder Where_Resolve_returns(IEmailBuilder builder, Guid id)
    {
        Mock.Setup(x => x.Resolve(id)).Returns(builder);
        return this;
    }
    
    public EmailBuilderResolverMockBuilder Where_Resolve_returns(IEmailBuilder builder)
    {
        Mock.Setup(x => x.Resolve(It.IsAny<Guid>())).Returns(builder);
        return this;
    }
}