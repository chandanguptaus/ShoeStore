using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoes.Application.Services.Contract;
using Shoes.Domain.BrandAggregate;

namespace Shoes.Application.Services.Implementation
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository repository)  // Dependency Injection repository.
        {
            _brandRepository = repository;
        }
        public async Task<IQueryable<Brand>>    GetAll()
        {
            var query =  await _brandRepository.GetAllAsync();
            query = query.Include(s => s.Products)
                    .ThenInclude(s => s.Product_id);
            return query;
        }
        public async Task Add(Brand brand)
        {
            await _brandRepository.Add(brand);
        }
        public async Task AddRange(IEnumerable<Brand> brands)
        {
            await _brandRepository.AddRange(brands);
        }
        public async Task<Brand> Get(int id)
        {
            return await _brandRepository.Get(id);
        }

    }
}