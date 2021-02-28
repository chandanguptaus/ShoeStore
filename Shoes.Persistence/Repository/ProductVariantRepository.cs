using System.Collections.Generic;
using Shoes.Domain.ProductAggregate;

namespace Shoes.Persistence.Repository
{
    public class ProductVariantRepository : GenericRepository<ProductVariant> , IProductVariantRepository
    {
        public ProductVariantRepository(DataContext context) : base(context)
        {
            
        }


    }
}