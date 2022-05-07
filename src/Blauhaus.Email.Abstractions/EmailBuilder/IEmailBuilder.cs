namespace Blauhaus.Email.Server.Abstractions.EmailBuilder
{
    public interface IEmailBuilder
    {
        IEmailBuilder WithParagraph(string paragraph);
        IEmailBuilder WithSubjectText(string subjectText);
        IEmailBuilder WithParagraphs(List<string> paragraphs);
        string GetText();
        string GetHtml();
    }

}