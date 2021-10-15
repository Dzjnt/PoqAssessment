using Microsoft.AspNetCore.Mvc;
using Poq.Application.DTOs;
using Poq.Application.Parameter;
using Poq.Application.Queries.GetProducts;
using System.Threading.Tasks;

namespace Poq.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {

        /// <summary>
        /// Endpoint which allow users to get filtered products
        /// </summary>
        /// <param name="size" example="medium">The product's size</param>
        /// <param name="highlight" example="red,blue">The product's description keywords to highlight</param>
        ///  <param name="max price" example="12.00">The products max price user can pay</param>
        /// <response code="200">Product retrieved</response>
        /// <response code="404">Product not found</response>
        /// <response code="500">Oops! Can't lookup your product right now :(</response>
        [ProducesResponseType(typeof(ProductDto), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet(Name = "GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParams parameters)
        {
            var result = await Mediator.Send(new GetProductsQuery(parameters));

            return Ok(result);

        }
    }
}
