using CoffeMug.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeMug.Services.Data
{
    public class CoffeemugContext : DbContext
    {
        public CoffeemugContext(DbContextOptions<CoffeemugContext> options) : base(options){ }

        public DbSet<Product> Products { get; set; }
    }
}