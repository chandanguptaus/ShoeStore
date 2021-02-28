using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoes.Application.Services.Contract;
using Shoes.Domain.ColorAggregate;

namespace Shoes.Application.Services.Implementation
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _brandRepository;
        public ColorService(IColorRepository repository)  // Dependency Injection repository.
        {
            _brandRepository = repository;
        }
        public async Task<IQueryable<Color>> GetAll()
        {
            var query =  await _brandRepository.GetAllAsync();
            query = query.Include(s => s.Products);
            return query;
        }
        public async Task Add(Color brand)
        {
            await _brandRepository.Add(brand);
        }
        public async Task AddRange(IEnumerable<Color> brands)
        {
            await _brandRepository.AddRange(brands);
        }
        public async Task<Color> Get(int id)
        {
            return await _brandRepository.Get(id);
        }

    }
}