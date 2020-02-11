using System.Threading.Tasks;

namespace CoffeMug.Services.Data.Impl
{
	public abstract class BaseRepository : IBaseRepository
	{
		public async Task AddAsync<T>(CoffeemugContext context, T entity) where T : class
		{
			await context.AddAsync(entity);
			await context.SaveChangesAsync();
		}

		public void Delete<T>(CoffeemugContext context, T entity) where T : class
		{
			context.Remove(entity);
		}

		public T Update<T>(CoffeemugContext context, T entity) where T : class
		{
			var entityUpdated = context.Update(entity);
			return entityUpdated.Entity;
		}
	}
}