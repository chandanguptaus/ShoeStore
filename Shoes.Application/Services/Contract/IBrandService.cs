using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shoes.Domain.BrandAggregate;
using Shoes.Domain.CategoryAgggregate;
using Shoes.Domain.SizeAggregate;

namespace Shoes.Application.Services.Contract
{
    public interface IBrandService
    {
         Task<IQueryable<Brand>>    GetAll();
         Task<Brand> Get(int id);
         Task Add(Brand brand);
         Task AddRange(IEnumerable<Brand> brand);

    }
}