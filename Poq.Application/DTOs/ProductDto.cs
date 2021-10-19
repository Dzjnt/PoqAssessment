using Poq.Application.Model;
using System.Collections.Generic;
using System.Linq;

namespace Poq.Application.DTOs
{
    public class ProductDto
    {
        public List<Product> Products { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public List<string> MostCommonWords { get; set; }

        public ProductDto SetMaxPrice()
        {
            MaxPrice = Products.Max(x => x.Price);
            return this;

        }
        public ProductDto SetMinPrice()
        {
            MinPrice = Products.Min(x => x.Price);
            return this;
        }
        public ProductDto SetMostCommonWords()
        {
            var temp = string.Join(" ", Products.Select(x => x.Description).ToArray());

            MostCommonWords = temp.Split(' ')
                                    .GroupBy(x => x)
                                    .OrderByDescending(g => g.Count())
                                    .Select(g => g.Key)
                                    .Skip(5)
                                    .Take(10)
                                    .ToList();
            return this;
        }
    }
}
