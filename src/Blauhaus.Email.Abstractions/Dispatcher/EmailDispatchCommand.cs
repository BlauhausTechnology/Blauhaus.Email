namespace Blauhaus.Email.Abstractions.Dispatcher;

public class EmailDispatchCommand
{
    public string FromAddress { get; set; } = null!;
    public string? FromName { get; set; } 
    public string ToAddress { get; set; } = null!;
    public string? ToName { get; set; }
    public string Subject { get; set; } = null!;
    public string Text { get; set; } = null!;
    public string Html { get; set; } = null!;
}