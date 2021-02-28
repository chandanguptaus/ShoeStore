using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shoes.Application.Services;
using Shoes.Application.Services.Contract;
using Shoes.Domain.BrandAggregate;
using Shoes.Domain.CategoryAgggregate;
using Shoes.Domain.ColorAggregate;
using Shoes.Domain.PersonAgggregate;
using Shoes.Domain.ProductAggregate;
using Shoes.Domain.SizeAggregate;

namespace Shoes.API.Controllers
{
    // Common API action methods to read all shoe brands, colors, Sizes, person (men, women and kids) and categories.
    // Factory pattern used to get the required service instance from DI container.
    [ApiController]
    [Route("[controller]")]
    public class searchApi : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly ISizeService _sizeService;
        private readonly IColorService _colorService;
        private readonly IPersonService _personService;
        public searchApi(IServiceFactory servicefactory, ILogger<searchApi> logger)
        {
            // Factory pattern Get the instances from the factory for the E-commerce Shoes filtering options. 
            _brandService = servicefactory.GetServiceInstance<IBrandService>();
            _categoryService = servicefactory.GetServiceInstance<ICategoryService>();
            _sizeService = servicefactory.GetServiceInstance<ISizeService>();
            _colorService = servicefactory.GetServiceInstance<IColorService>();
            _personService = servicefactory.GetServiceInstance<IPersonService>();
        }
        [Route("brands")]
        [HttpGet]
        public async Task<ActionResult<IList<Brand>>> GetBrands()
        {
            var brands = await _brandService.GetAll();
            var ajaxBrands = brands.Select(s => new
            {

                Brand_id = s.Brand_id,
                Name = s.Name,
                Description = s.Name,
                Products = s.Products.Count()
            });

            return Ok(ajaxBrands.ToList());
        }
        [Route("brand/{id}")]
        [HttpGet]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            var data = await _brandService.Get(id);
            return Ok(data);
        }
        [Route("categories")]
        [HttpGet]
        public async Task<ActionResult<IList<Category>>> GetCategories()
        {
            var data = await _categoryService.GetAll();
            return Ok(data.ToList());
        }
        [Route("category/{id}")]
        [HttpGet]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var data = await _categoryService.Get(id);
            return Ok(data);
        }
        [Route("sizes")]
        [HttpGet]
        public async Task<ActionResult<IList<Size>>> GetAvailableShoesSizes()
        {
            var data = await _sizeService.GetAll();
            return Ok(data.ToList());
        }
        [Route("size/{id}")]
        [HttpGet]
        public async Task<ActionResult<Size>> GetSize(int id)
        {
            var data = await _sizeService.Get(id);
            return Ok(data);
        }
        [Route("colors")]
        [HttpGet]
        public async Task<ActionResult<IList<Color>>> GetColors()
        {
            var data = await _colorService.GetAll();
            var colors = data.Select(s => new
            {
                color = s.Code,
                Description = s.Description,
               // Products = product,
            });
            return Ok(colors.ToList());
        }
        [Route("customertype")]
        [HttpGet]
        public async Task<ActionResult<IList<Person>>> GetCustomerType()
        {
            var data = await _personService.GetAll();
            return Ok(data.ToList());
        }
    }
}
