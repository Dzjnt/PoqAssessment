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
        /// <param name="parameters">Products filter parameters</param>
        /// <response code="200">Product retrieved</response>
        /// <response code="400">Invalid parameters</response>
        /// <response code="500">Oops! Can't lookup your product right now :(</response>
        [ProducesResponseType(typeof(ProductDto), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        [HttpGet(Name = "GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParams parameters)
        {
            var result = await Mediator.Send(new GetProductsQuery(parameters));

            return Ok(result);

        }
    }
}
