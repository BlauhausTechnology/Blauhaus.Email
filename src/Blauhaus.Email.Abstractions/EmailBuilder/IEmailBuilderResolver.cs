namespace Blauhaus.Email.Abstractions.EmailBuilder;

public interface IEmailBuilderResolver
{
    IEmailBuilder Resolve(Guid id);
}