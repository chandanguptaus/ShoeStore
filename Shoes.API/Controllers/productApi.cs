using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shoes.Application.Services;
using Shoes.Application.Services.Contract;
using Shoes.Domain.ProductAggregate;

namespace Shoes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class productApi : ControllerBase
    {
        private readonly IProductService _productDetailsService;
        private readonly IProductVariantService _productVariantService;
        public productApi(IServiceFactory servicefactory, ILogger<productApi> logger)
        {   
            _productDetailsService = servicefactory.GetServiceInstance<IProductService>();
            _productVariantService = servicefactory.GetServiceInstance<IProductVariantService>();
        }
        [Route("Products")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {            
            var products  =  await _productDetailsService.GetAll();
            var ajaxProductsVM = products.Select(p => new     // Return Anonmous type
            {
                Product_id = p.Product_id,
                category_id = p.Category_id,
                Brand_id = p.Brand_id,
                Person_id = p.Person_id,
                Brand = (p.Brand.Name),
                Category = (p.Category.Name),
                CustType = (p.Person.Name),
                IsActive = p.IsActive,
                ModifiedOn = p.ModifiedOn,
                Modifiedby = p.ModifiedBy,
            });
            return Ok(ajaxProductsVM);
        }

        //<Summary>
        // Input - Shoe Product filters
        // Output - Filtered Shoe product variance based on filters        
        //</Summmary>
        [Route("filterProducts")]
        [HttpGet]
        public async Task<IActionResult> GetFilterProducts(string brand, string category, string custType, string color, string size, string sort)
        {

            var isSizeValid = float.TryParse(size, out float sizeParam);
            var filterProducts  =  await _productVariantService.GetProductsFilterSort(brand,category,custType,color,sizeParam,sort);
            var ajaxProductsVM = filterProducts.Select(p => new {
                Product_id =  p.Product.Product_id,
                category_id = p.Product.Category.Category_id,
                Brand_id = p.Product.Brand.Brand_id,
                Person_id = p.Product.Person.Person_id,
                Color_id = p.Color.Color_id,
                Size_id = p.Size.Size_id,
                Brand = p.Product.Brand.Name,
                Category = p.Product.Category.Name,
                CustType = p.Product.Person.Name,
                Color = p.Color.Description,
                Size = p.Size.Number,
                IsActive = p.Product.IsActive,
                ModifiedOn = p.Product.ModifiedOn,
                Modifiedby = p.Product.ModifiedBy,
            });
            return Ok(ajaxProductsVM);
        }

    }
}