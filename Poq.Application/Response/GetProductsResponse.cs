using Poq.Application.Model;
using System.Collections.Generic;

namespace Poq.Application.Response
{
    public class GetProductsResponse
    {
        public List<Product> Products { get; init; }
    }
}
