using System;
using CoffeMug.Services.Models;

namespace CoffeMug.Services.Services.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
    }
}