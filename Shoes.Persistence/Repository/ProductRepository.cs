using Shoes.Domain.ProductAggregate;

namespace Shoes.Persistence.Repository
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
            
        }
    }
}