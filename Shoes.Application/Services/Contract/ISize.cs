using System.Collections.Generic;
using System.Threading.Tasks;
using Shoes.Domain.SizeAggregate;
namespace Shoes.Application.Services.Contract
{
    public interface ISizeService
    {
         Task<IEnumerable<Size>>  GetAll();
         Task<Size> Get(int id);
         Task Add(Size brand);
         Task AddRange(IEnumerable<Size> brand);

    }
}