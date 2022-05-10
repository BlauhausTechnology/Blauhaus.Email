using Blauhaus.Analytics.Abstractions;
using Blauhaus.Analytics.Abstractions.Extensions;
using Blauhaus.Email.Abstractions.Dispatcher;
using Blauhaus.Email.SendGrid.Ioc;
using Blauhaus.Errors;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Response = Blauhaus.Responses.Response;

namespace Blauhaus.Email.SendGrid;

public class SendGridEmailDispatcher : IEmailDispatcher
{
    private readonly IAnalyticsLogger<SendGridEmailDispatcher> _logger;
    private readonly string _apiKey;

    public SendGridEmailDispatcher(
        IAnalyticsLogger<SendGridEmailDispatcher> logger,
        IOptions<SendGridOptions> options)
    {
        _apiKey = options.Value.ApiKey;
        _logger = logger;
    }

    public async Task<Response> DispatchAsync(EmailDispatchCommand command)
    {
        if (string.IsNullOrEmpty(command.FromAddress))
        {
            return _logger.LogErrorResponse(Error.RequiredValue<EmailDispatchCommand>(x => x.FromAddress));
        }
        var from = new EmailAddress(command.FromAddress, command.FromName);

        if (string.IsNullOrEmpty(command.ToAddress))
        {
            return _logger.LogErrorResponse(Error.RequiredValue<EmailDispatchCommand>(x => x.ToAddress));
        }
        var to = new EmailAddress(command.ToAddress, command.FromName);

        var sendGridEmail = MailHelper.CreateSingleEmail(from, to, command.Subject, command.Text, command.Html);
        var client = new SendGridClient(_apiKey);
        var response = await client.SendEmailAsync(sendGridEmail);
        if (!response.IsSuccessStatusCode)
        {
            var responseBody = await response.Body.ReadAsStringAsync();
            _logger.LogInformation("Sendgrid failed: {SendGridResponse}", responseBody);
            return _logger.LogErrorResponse(Error.Generic("Email dispatch failed: " + response.StatusCode));
        }

        _logger.LogInformation("Email sent: {EmailSubject}", command.Subject);
        return Response.Success();
    }
}