using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeMug.Services.Models
{
    public class Product
    {
		[Key]
        public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
    }
}