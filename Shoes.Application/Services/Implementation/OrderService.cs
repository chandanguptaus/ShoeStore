using System.Threading.Tasks;
using Shoes.Application.Services.Contract;
using Shoes.Domain.OrderAggregate;

namespace Shoes.Application.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _ordRepository;
        public OrderService(IOrderRepository repository)  // Dependency Injection repository.
        {
            _ordRepository = repository;
        }
        public async Task Create(OrderDetails ordered)
        {
            await Task.Delay(1000);
            throw  new System.NotImplementedException();
        }
    }
}