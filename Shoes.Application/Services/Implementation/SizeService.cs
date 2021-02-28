using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoes.Application.Services.Contract;
using Shoes.Domain.SizeAggregate;

namespace Shoes.Application.Services.Implementation
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _repository;
        public SizeService(ISizeRepository repository)  // Dependency Injection repository.
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Size>> GetAll()
        {
           var query =  await _repository.GetAllAsync();
            query = query.Include(s => s.Products)
                    .ThenInclude(s => s.Product_id);
            return query;
        }
        public async Task Add(Size brand)
        {
            await _repository.Add(brand);
        }
        public async Task AddRange(IEnumerable<Size> brands)
        {
            await _repository.AddRange(brands);
        }
        public async Task<Size> Get(int id)
        {
            return await _repository.Get(id);
        }

    }
}