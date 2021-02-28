using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shoes.Domain.ProductAggregate;
namespace Shoes.Application.Services.Contract
{
    public interface IProductVariantService
    {
         Task<IQueryable<ProductVariant>>  GetAll();
         Task<IQueryable<ProductVariant>> GetProductsFilterSort(string brand, string category, string custType, string color, float size, string sort);
         Task<IQueryable<ProductVariant>> GetProductsWithDiscount(float Discount);
         Task<ProductVariant> Get(int id);
         Task Add(ProductVariant brand);
         Task AddRange(IEnumerable<ProductVariant> brand);
    }
}