using Ganss.XSS;

namespace Poq.Application.Common.Wrapper
{
    public static class HtmlSanitizerWrapper
    {
        private static readonly HtmlSanitizer _htmlSanitizer = new();
        public static string Sanitize(string content) => _htmlSanitizer.Sanitize(content);

    }
}
