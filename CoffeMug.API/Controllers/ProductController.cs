﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeMug.Services.Services;
using CoffeMug.Services.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoffeMug.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly IProductDataObject _productDataObject;

		public ProductController(IProductDataObject productDataObject)
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

		[HttpPost("add")]
        public async Task<IActionResult> CreateProduct(ProductDto product)
        {
            await _productDataObject.Create(product);
            return Ok();
        }

		[HttpPost("modify")]
        public IActionResult UpdateProduct(ProductDto product)
        {
            var productUpdated = _productDataObject.Update(product);
            return Ok(productUpdated);
        }

		[HttpPost("remove/{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
			await _productDataObject.RemoveAsync(id);
            return Ok();
        }
    }
}
