using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shoes.Domain.CategoryAgggregate;

namespace Shoes.Application.Services.Contract
{
    public interface ICategoryService
    {
        Task<IQueryable<Category>> GetAll();
         Task<Category> Get(int id);
         Task Add(Category brand);
         Task AddRange(IEnumerable<Category> brand);
       
    }
}