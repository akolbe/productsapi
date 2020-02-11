using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoffeMug.Core.Domain;
using CoffeMug.Services.Data;
using CoffeMug.Services.Services.Dtos;

namespace CoffeMug.Services.Services.Impl
{
	public class ProductDataObject : IProductDataObject
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public ProductDataObject(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task Create(ProductAddDto product)
		{
			var productDomain = _mapper.Map<Product>(product);
			await _productRepository.AddAsync(productDomain);

		}

		public async Task<ProductDto> GetByIdAsync(Guid id)
		{
			var productDomain =  await _productRepository.GetProductAsync(id);
			var productDto = _mapper.Map<ProductDto>(productDomain);
			return productDto;
		}

		public async Task<IEnumerable<ProductDto>> GetListAsync()
		{
			var productDomains = await _productRepository.GetProductsAsync();
			var productDtos = _mapper.Map<IEnumerable<ProductDto>>(productDomains);
			return productDtos;
		}

		public async Task RemoveAsync(Guid id)
		{
			var productDomain = await _productRepository.GetProductAsync(id);
			_productRepository.Delete(productDomain);

		}

		public ProductDto Update(ProductDto product)
		{
			var productDomain = _mapper.Map<Product>(product);
			var productUpdated =_productRepository.Update(productDomain);
			return _mapper.Map<ProductDto>(productUpdated);
		}
	}
}