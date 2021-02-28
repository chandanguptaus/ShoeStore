using Shoes.Domain.CategoryAgggregate;

namespace Shoes.Persistence.Repository
{
    public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
            
        }
        
    }
}