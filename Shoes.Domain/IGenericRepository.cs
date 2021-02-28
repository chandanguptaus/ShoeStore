using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoes.Domain
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> Get(int id);
        Task<IQueryable<T>> GetAllAsync();
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
    }
}