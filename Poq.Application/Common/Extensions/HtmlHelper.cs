using Ganss.XSS;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Poq.Application.Common.Extensions
{
    public static class HtmlHelper
    {
        private readonly static HtmlSanitizer Sanitizer = new HtmlSanitizer();

        public static string HighlightKeywords(string text, string keywords)
        {

            if (text == string.Empty || keywords == string.Empty)
                return text;
            var words = keywords.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return Sanitizer.Sanitize(words.Select(word => word.Trim()).Aggregate(text,
                                (current, pattern) =>
                                Regex.Replace(current, pattern,
                                                $"<em>{current}</em>",
                                                RegexOptions.IgnoreCase)));

        }
    }
}
