using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoes.Application.Services.Contract;
using Shoes.Domain.PersonAgggregate;

namespace Shoes.Application.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        public PersonService(IPersonRepository repository)  // Dependency Injection repository.
        {
            _repository = repository;
        }
        public async Task<IQueryable<Person>> GetAll()
        {
            var query =  await _repository.GetAllAsync();
            query = query.Include(s => s.Products)
                    .ThenInclude(s => s.Product_id);
            return query;
        }
        public async Task Add(Person brand)
        {
            await _repository.Add(brand);
        }
        public async Task AddRange(IEnumerable<Person> brands)
        {
            await _repository.AddRange(brands);
        }
        public async Task<Person> Get(int id)
        {
            return await _repository.Get(id);
        }

    }
}