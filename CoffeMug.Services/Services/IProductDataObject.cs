using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeMug.Services.Services.Dtos;

namespace CoffeMug.Services.Services
{
    public interface IProductDataObject
    {
		Task<IEnumerable<ProductDto>> GetListAsync();
		Task<ProductDto> GetByIdAsync(Guid id);
		Task Create(ProductAddDto product);
		ProductDto Update(ProductDto product);
		Task RemoveAsync(Guid id);
    }
}