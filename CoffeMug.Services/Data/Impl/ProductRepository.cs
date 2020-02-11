using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeMug.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoffeMug.Services.Data.Impl
{
	public class ProductRepository : IProductRepository
	{
		private readonly CoffeemugContext _db;

		public ProductRepository(CoffeemugContext db)
		{
			_db = db;
		}

		public async Task AddAsync(Product product)
		{
			await _db.AddAsync(product);
			await _db.SaveChangesAsync();
		}

		public void Delete(Product product)
		{
			_db.Remove(product);
			_db.SaveChanges();
		}

		public async Task<Product> GetProductAsync(Guid id)
		{
			var product = await _db.Products.FirstOrDefaultAsync(u => u.Id == id);
            return product;
		}

		public async Task<IEnumerable<Product>> GetProductsAsync()
		{
			var products = await _db.Products.ToListAsync();
            return products;
		}

		public Task<bool> SaveAllAsync()
		{
			throw new System.NotImplementedException();
		}

		public Product Update(Product product)
		{
			var entityUpdated = _db.Update(product);
			_db.SaveChanges();
			return entityUpdated.Entity;
		}
	}
}