using Poq.Application.Products;
using System.Threading.Tasks;

namespace Poq.Application.Common.Interfaces
{
    public interface IProductsService
    {
        Task<GetProductsResponse> GetProducts();
    }
}
