using AutoMapper;
using MediatR;
using Poq.Application.Common.Extensions;
using Poq.Application.Common.Interfaces;
using Poq.Application.Core;
using Poq.Application.DTOs;
using Poq.Application.Products;
using Poq.Application.Queries.GetProducts;
using System.Threading;
using System.Threading.Tasks;

namespace Poq.Application.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<ProductDto>>
    {
        private readonly IProductsService _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductsService context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.GetProducts();

            var mappedResult = _mapper.Map<GetProductsResponse, ProductDto>(result);
            var filterBuilder = new FilterBuilder()
                .SetHighPrice(request.Params.MaxPrice)
                .SetSize(request.Params.Size)
                .SetHighlights(request.Params.Highlights)
                .Build(mappedResult);

            return Result<ProductDto>.Success(filterBuilder);
        }
    }
}
