using Shoes.Domain.PersonAgggregate;

namespace Shoes.Persistence.Repository
{
    public class PersonRepository : GenericRepository<Person> , IPersonRepository
    {
        public PersonRepository(DataContext context) : base(context)
        {
            
        }
    }
}