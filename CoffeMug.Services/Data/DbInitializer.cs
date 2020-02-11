using System.Collections.Generic;
using System.Linq;
using CoffeMug.Services.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CoffeMug.Services.Data
{
    public class DbInitializer
    {
        private readonly CoffeemugContext _db;

		public DbInitializer(CoffeemugContext db)
        {
            _db = db;
        }

		 public void Seed()
        {
            _db.Database.Migrate();

            if (_db.Products.Any())
                return;

             SeedProducts();
		}

		private void SeedProducts()
		{
			var productData = System.IO.File.ReadAllText("Data/Jsons/productSeedData.json");
            var products = JsonConvert.DeserializeObject<List<Product>>(productData);
			_db.Products.AddRange(products);
            _db.SaveChanges();
		}
    }
}