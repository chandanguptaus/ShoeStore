using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoes.Domain;
namespace Shoes.Persistence
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<T>> GetAllAsync()   // Get All entities
        {
            var data =  await _context.Set<T>().ToListAsync();
            return data.AsQueryable();
        }
        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task Add(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
        }
        public async Task AddRange(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }
    }
}