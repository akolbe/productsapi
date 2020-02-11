using System.Threading.Tasks;

namespace CoffeMug.Services.Data
{
    public interface IBaseRepository
    {
         Task AddAsync<T>(CoffeemugContext context, T entity) where T: class;
         void Delete<T>(CoffeemugContext context, T entity) where T: class;
		 T Update<T>(CoffeemugContext context, T entity) where T: class;
    }
}