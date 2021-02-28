using System.Threading.Tasks;
using Shoes.Domain.OrderAggregate;

namespace Shoes.Application.Services.Contract
{
    public interface IOrderService
    {
     Task Create(OrderDetails ordered);
       
    }
}