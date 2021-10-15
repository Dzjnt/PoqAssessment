using MediatR;
using Poq.Application.Common.Extensions;
using Poq.Application.DTOs;
using Poq.Application.Parameter;

namespace Poq.Application.Queries.GetProducts
{
    public record GetProductsQuery(ProductParams Params) : IRequest<Result<ProductDto>>;
}
