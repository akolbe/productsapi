using System;
using System.Threading.Tasks;
using CoffeMug.Services.Services;
using CoffeMug.Services.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CoffeMug.API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       private readonly IProductDataObject _productDataObject;

		public ProductsController(IProductDataObject productDataObject)
        {
			_productDataObject = productDataObject;
		}

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var products = await _productDataObject.GetListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productDataObject.GetByIdAsync(id);
            return Ok(product);
        }

		[HttpPost]
        public async Task<IActionResult> CreateProduct(ProductAddDto product)
        {
            await _productDataObject.Create(product);
            return Ok();
        }

		[HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] ProductDto product)
        {
			 if (id != product.Id)
                return BadRequest();

            var productUpdated = _productDataObject.Update(product);
            return Ok(productUpdated);
        }

		[HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
			await _productDataObject.RemoveAsync(id);
            return Ok();
        }
    }
}
