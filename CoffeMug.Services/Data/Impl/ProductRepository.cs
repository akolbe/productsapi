using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeMug.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeMug.Services.Data.Impl
{
	public class ProductRepository : IProductRepository
	{
		private readonly CoffeemugContext _context;
		private readonly IBaseRepository _baseRepository;

		public ProductRepository(CoffeemugContext context, IBaseRepository baseRepository)
		{
			_context = context;
			_baseRepository = baseRepository;
		}

		public async Task AddAsync(Product product)
		{
			await _baseRepository.AddAsync(_context, product);
		}

		public void Delete(Product product)
		{
			_baseRepository.Delete(_context, product);
		}

		public async Task<Product> GetProductAsync(Guid id)
		{
			var product = await _context.Products.FirstOrDefaultAsync(u => u.Id == id);
            return product;
		}

		public async Task<IEnumerable<Product>> GetProductsAsync()
		{
			var products = await _context.Products.ToListAsync();
            return products;
		}

		public Task<bool> SaveAllAsync()
		{
			throw new System.NotImplementedException();
		}

		public Product Update(Product product)
		{
			return _baseRepository.Update(_context, product);
		}
	}
}