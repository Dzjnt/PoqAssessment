using Poq.Application.Common.Interfaces;
using Poq.Application.Parameter;
using Poq.Application.Products;
using Poq.Infrastructure.HTTP;
using System.Threading.Tasks;

namespace Poq.Infrastructure.Services
{
    public class ProductsService : IProductsService
    {
        private readonly MockyClient _client;

        public ProductsService(MockyClient client)
        {
            _client = client;
        }

        public async Task<GetProductsResponse> GetProducts()
        {
            return await _client.GetProducts();
        }
    }
}
