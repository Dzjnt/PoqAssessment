using Poq.Application.Products;
using System.Collections.Generic;
using System.Linq;

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
            query.ForEach(x => x.Description = HtmlHelper.HighlightKeywords(x.Description, highlights));
        }
    }
}
