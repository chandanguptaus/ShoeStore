using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoes.Application.Services.Contract;
using Shoes.Domain.ProductAggregate;

namespace Shoes.Application.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)  // Dependency Injection repository.
        {
            _repository = repository;
        }
        public async Task<IQueryable<Product>> GetAll()
        {
            var data = await _repository.GetAllAsync();
            return data
              .Include(p => p.Brand)
              .Include(p => p.Category)
              .Include(p => p.Person);
        }
        public async Task Add(Product brand)
        {
            await _repository.Add(brand);
        }
        public async Task AddRange(IEnumerable<Product> brands)
        {
            await _repository.AddRange(brands);
        }
        public async Task<Product> Get(int id)
        {
            return await _repository.Get(id);
        }

    }
}