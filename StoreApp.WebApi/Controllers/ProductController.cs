using Microsoft.AspNetCore.Mvc;
using StoreApp.Application.CQRS.Categories.Command.Request;
using StoreApp.Application.CQRS.Categories.Query.Request;
using StoreApp.Application.CQRS.Product.Command.Request;
using StoreApp.Application.CQRS.Product.Query.Request;

namespace StoreApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            return Ok(await Sender.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await Sender.Send(new GetAllProductQueryRequest()));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await Sender.Send(new DeleteProductCommandRequest { Id = id }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            return Ok(await Sender.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            return Ok(await Sender.Send(new GetByIdCategoryQueryRequest { Id = id }));
        }
    }
}