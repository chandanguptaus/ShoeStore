using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shoes.Domain.ColorAggregate;

namespace Shoes.Application.Services.Contract
{
    public interface IColorService
    {
         Task<IQueryable<Color>>  GetAll();
         Task<Color> Get(int id);
         Task Add(Color brand);
         Task AddRange(IEnumerable<Color> brand);

    }
}