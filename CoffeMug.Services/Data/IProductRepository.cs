using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeMug.Core.Domain;

namespace CoffeMug.Services.Data
{
    public interface IProductRepository
    {
         Task<bool> SaveAllAsync();
         Task<IEnumerable<Product>> GetProductsAsync();
         Task<Product> GetProductAsync(Guid id);
		 Task AddAsync(Product product);
		 Product Update(Product product);
		 void Delete(Product product);
    }
}