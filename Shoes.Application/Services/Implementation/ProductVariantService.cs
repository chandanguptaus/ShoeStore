using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shoes.Application.Services.Contract;
using Shoes.Domain.ProductAggregate;

namespace Shoes.Application.Services.Implementation
{
    public class ProductVariantService : IProductVariantService
    {
        private readonly IProductVariantRepository _repository;
        public ProductVariantService(IProductVariantRepository repository)  // Dependency Injection repository.
        {
            _repository = repository;
        }
        public async Task<IQueryable<ProductVariant>> GetAll()
        {
            var productVariants = await _repository.GetAllAsync();
            return productVariants
              .Include(p => p.Product)
              .Include(p => p.Size)
              .Include(p => p.Color);   // lazy loading
        }
        public async Task<IQueryable<ProductVariant>> GetProductsFilterSort(string brand, string category, string custType, string color, float size, string sort)
        {
            var productVariants = await _repository.GetAllAsync();

            IQueryable<ProductVariant> query = productVariants
                .Include(p => p.Product)
                .Include(p => p.Size)
                .Include(p => p.Color);

            //Filter Shoes.
            if (!string.IsNullOrEmpty(brand))  // filter by Brand
                query = query.Where(p => p.Product.Brand.Name == brand);  // Brand
            if (!string.IsNullOrEmpty(category)) // filter by Category
                query = query.Where(p => p.Product.Category.Name == category);
            if (!string.IsNullOrEmpty(color)) // filter by Color
                query = query.Where(p => p.Color.Code == color);
            if (!string.IsNullOrEmpty(custType)) // filter by CustType
                query = query.Where(p => p.Product.Person.Name == custType);
            if (size > 0) // filter by Size
                query = query.Where(p => p.Size.Number == size);
            return query;
        }
        public async Task<IQueryable<ProductVariant>> GetProductsWithDiscount(float Discount)
        {
            var productVariants = await _repository.GetAllAsync();
            IQueryable<ProductVariant> productQuery = productVariants
                .Include(p => p.Product)
                .Include(p => p.Size)
                .Include(p => p.Color);
            productQuery = productQuery.Where(s => s.Discount >= Discount);
            return productQuery;
        }

        public async Task Add(ProductVariant brand)
        {
            await _repository.Add(brand);
        }
        public async Task AddRange(IEnumerable<ProductVariant> brands)
        {
            await _repository.AddRange(brands);
        }
        public async Task<ProductVariant> Get(int id)
        {
            return await _repository.Get(id);
        }
    }
}