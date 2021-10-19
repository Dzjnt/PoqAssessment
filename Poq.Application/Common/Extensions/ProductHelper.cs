using Poq.Application.Common.Wrapper;
using Poq.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Poq.Application.Common.Extensions
{
    public static class ProductHelper
    {
        public static List<Product> ByMaxPrice(this List<Product> query, double maxPrice)
        {
            return query.Where(e => e.Price <= maxPrice).ToList();
        }

        public static List<Product> BySize(this List<Product> query, string size)
        {
            return query.Where(x => x.Sizes.All(e => e == size)).ToList();
        }
        public static void ToHighlight(this List<Product> query, string highlights)
        {
            query.ForEach(x => x.Description = HtmlSanitizerWrapper.Sanitize(HighlightKeywords(x.Description, highlights)));
        }
        private static string HighlightKeywords(string text, string keywords)
        {

            if (text == string.Empty || keywords == string.Empty)
                return text;
            var words = keywords.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return words.Select(word => word.Trim()).Aggregate(text,
                                (current, pattern) =>
                                Regex.Replace(current, pattern,
                                                $"<em>{current}</em>",
                                                RegexOptions.IgnoreCase));
        }
    }
}
