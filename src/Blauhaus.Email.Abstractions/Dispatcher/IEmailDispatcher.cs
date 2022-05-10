using Blauhaus.Responses;

namespace Blauhaus.Email.Abstractions.Dispatcher;

public interface IEmailDispatcher
{
    Task<Response> DispatchAsync(EmailDispatchCommand command);
}