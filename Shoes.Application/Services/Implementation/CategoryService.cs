using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoes.Application.Services.Contract;
using Shoes.Domain.CategoryAgggregate;

namespace Shoes.Application.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _brandRepository;
        public CategoryService(ICategoryRepository repository)  // Dependency Injection repository.
        {
            _brandRepository = repository;
        }
        public async Task<IQueryable<Category>> GetAll()
        {
           var query =  await _brandRepository.GetAllAsync();
            query = query.Include(s => s.Products)
                    .ThenInclude(s => s.Product_id);
            return query;
        }
        public async Task Add(Category brand)
        {
            await _brandRepository.Add(brand);
        }
        public async Task AddRange(IEnumerable<Category> brands)
        {
            await _brandRepository.AddRange(brands);
        }
        public async Task<Category> Get(int id)
        {
            return await _brandRepository.Get(id);
        }

    }
}