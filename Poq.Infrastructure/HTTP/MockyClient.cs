using Poq.Application.Products;
using System.Net.Http;
using System.Threading.Tasks;

namespace Poq.Infrastructure.HTTP
{
    public class MockyClient : BaseHttpClient
    {
        public MockyClient(HttpClient httpClient) : base(httpClient)
        {

        }

        public async Task<GetProductsResponse> GetProducts()
        {
            return await Get<GetProductsResponse>();
        }

    }
}
