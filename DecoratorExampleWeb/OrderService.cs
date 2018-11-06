using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DecoratorExample;

namespace DecoratorExampleWeb
{
    public class OrderService : IOrderService
    { 
        public Task<Order> Get(Guid orderId)
        {
            var order = new Order()
            {
                CompletedDateTime = new DateTime(2007, 5, 22, 13, 54, 35),
                CreateDateTime = new DateTime(2007, 5, 22, 11, 55, 22),
                OrderId = orderId,
                TotalAmount = 1400.19
            };

            return Task.FromResult<Order>(order);
        }

        public Task<Order> Add(Guid orderId)
        {
            var order = new Order()
            {
                CompletedDateTime = null,
                CreateDateTime = new DateTime(2007, 5, 22, 11, 55, 22),
                OrderId = orderId,
                TotalAmount = 1400.19
            };

            //todo add to sql database

            return Task.FromResult<Order>(order);
        }

    }
}