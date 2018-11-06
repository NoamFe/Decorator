using System;
using System.Threading.Tasks;
using DecoratorExample;

namespace DecoratorExampleWeb
{ 
    public interface IOrderService
    {
        Task<Order> Get(Guid id);

        Task<Order> Add(Guid id);
    }
}