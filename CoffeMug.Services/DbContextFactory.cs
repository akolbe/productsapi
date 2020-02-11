using CoffeMug.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoffeMug.Services
{
	public class DbContextFactory : IDesignTimeDbContextFactory<CoffeemugContext>
	{
		public CoffeemugContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<CoffeemugContext>();
			builder.UseSqlite("Data Source=coffemugapp.db");

			return new CoffeemugContext(builder.Options);
		}
	}
}