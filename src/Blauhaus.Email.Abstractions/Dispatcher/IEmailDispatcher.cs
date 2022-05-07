using Blauhaus.Responses;

namespace Blauhaus.Email.Server.Abstractions.Dispatcher;

public interface IEmailDispatcher
{
    Task<Response> DispatchAsync(EmailDispatchCommand command);
}