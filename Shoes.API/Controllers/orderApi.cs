using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shoes.Application.Services;
using Shoes.Application.Services.Contract;
using Shoes.Domain.OrderAggregate;

namespace Shoes.API.Controllers
{
    [Route("api/[controller]")]
    public class orderApi : ControllerBase
    {
        private readonly IOrderService _productOrderService;
        public orderApi(IServiceFactory servicefactory, ILogger<orderApi> logger)
        {
            _productOrderService = servicefactory.GetServiceInstance<IOrderService>();
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            // Get the product id details from Cart

            // if cart empty

            // Create an order object  // just a sample
             OrderDetails o = new OrderDetails
                    {
                        Amount = 90,
                        ProductVariant_Id = 1,
                        Order_Id = 10,
                    };
            await _productOrderService.Create(o);
            return Ok("Ordered created succesfully");
           
        }
    }
}