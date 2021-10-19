using MediatR;
using Poq.Application.DTOs;
using Poq.Application.Parameter;
using Poq.Application.Response;

namespace Poq.Application.Queries.GetProducts
{
    public record GetProductsQuery(ProductParams Params) : IRequest<Result<ProductDto>>;
}
