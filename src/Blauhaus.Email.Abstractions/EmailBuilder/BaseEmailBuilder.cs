using System.Text;

namespace Blauhaus.Email.Server.Abstractions.EmailBuilder
{
    public abstract class BaseEmailBuilder : IEmailBuilder
    {
        protected abstract string Top(string preview);
        protected abstract string Bottom { get; }
        protected abstract string GetParagraph(string paragraphText);

        private readonly List<string> _paragraphs = new();
        private string _subjectText = string.Empty;

        public IEmailBuilder WithParagraph(string paragraph)
        {
            _paragraphs.Add(paragraph);
            return this;
        }
         
        public IEmailBuilder WithSubjectText(string subjectText)
        {
            _subjectText = subjectText;
            return this;
        }

        public IEmailBuilder WithParagraphs(List<string> paragraphs)
        {
            foreach (var paragraph in paragraphs)
            {
                _paragraphs.Add(paragraph);
            }
            return this;
        }

        public string GetText()
        {
            var content = new StringBuilder();
            foreach (var paragraph in _paragraphs)
            {
                content.Append($"{paragraph}\n\n");
            }
            return content.ToString();
        }

        public string GetHtml()
        {
            var content = new StringBuilder();
            content.Append(Top(_subjectText));
            foreach (var paragraph in _paragraphs)
            {
                content.Append(GetParagraph(paragraph));
            }
            content.Append(Bottom);
            return content.ToString();
        }
    }
}