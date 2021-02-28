using Shoes.Domain.BrandAggregate;
namespace Shoes.Persistence.Repository
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(DataContext context): base(context)
        {
            
        }
    }
}