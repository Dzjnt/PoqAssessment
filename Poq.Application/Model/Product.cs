using System.Collections.Generic;

namespace Poq.Application.Model
{
    public class Product
    {
        public string Title { get; init; }
        public int Price { get; init; }
        public List<string> Sizes { get; init; }
        public string Description { get; set; }
    }
}
