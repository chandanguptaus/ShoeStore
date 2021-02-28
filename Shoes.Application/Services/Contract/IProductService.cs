using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shoes.Domain.ProductAggregate;
namespace Shoes.Application.Services.Contract
{
    public interface IProductService
    {
         Task<IQueryable<Product>>  GetAll();
         Task<Product> Get(int id);
         Task Add(Product brand);
         Task AddRange(IEnumerable<Product> brand);

    }
}