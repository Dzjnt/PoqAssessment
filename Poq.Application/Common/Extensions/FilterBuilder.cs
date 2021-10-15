using Poq.Application.Common.Extensions;
using Poq.Application.DTOs;
using Poq.Application.Parameter;

namespace Poq.Application.Core
{
    public class FilterBuilder
    {
        private ProductParams _productParams;
        public FilterBuilder() : this(new ProductParams()) { }
        public FilterBuilder(ProductParams productParams)
        {
            _productParams = productParams;
        }
        public FilterBuilder SetHighPrice(double maxPrice)
        {
            _productParams.MaxPrice = maxPrice;
            return this;
        }

        public FilterBuilder SetSize(string size)
        {
            _productParams.Size = size;
            return this;
        }
        public FilterBuilder SetHighlights(string highligts)
        {
            _productParams.Highlights = highligts;
            return this;
        }
        public ProductDto Build(ProductDto productDTO)
        {
            productDTO
                .SetMaxPrice()
                .SetMinPrice()
                .SetMostCommonWords();

            if (_productParams.MaxPrice > 0.0)
            {
                productDTO.Products.ByMaxPrice(_productParams.MaxPrice);
            }

            if (!string.IsNullOrEmpty(_productParams.Size))
            {
                productDTO.Products.BySize(_productParams.Size);

            }

            if (_productParams.Highlights.Length > 0)
            {
                productDTO.Products.ToHighlight(_productParams.Highlights);
            }

            return productDTO;

        }
    }
}
