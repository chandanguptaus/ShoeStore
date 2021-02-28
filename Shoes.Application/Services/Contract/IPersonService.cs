using System.Collections.Generic;
using System.Threading.Tasks;
using Shoes.Domain.CategoryAgggregate;
using Shoes.Domain.SizeAggregate;
using Shoes.Domain.PersonAgggregate;
using System.Linq;

namespace Shoes.Application.Services.Contract
{
    public interface IPersonService
    {
         Task<IQueryable<Person>>  GetAll();
         Task<Person> Get(int id);
         Task Add(Person brand);
         Task AddRange(IEnumerable<Person> brand);

    }
}