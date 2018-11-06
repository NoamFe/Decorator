using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DecoratorExample;

namespace DecoratorExampleWeb
{
    public class OrderCacheService : IOrderService
    {
        private readonly IOrderService _orderService;
        private readonly ICacheService _cacheService;

        public OrderCacheService(IOrderService orderService, ICacheService cacheService)
        {
            _orderService = orderService;
            _cacheService = cacheService;
        }
        
        public async Task<Order> Get(Guid id)
        {
            var key = $"orderId:{id}";

            var order = await _cacheService.Get<Order>(key);

            if (order != null)
                return order;

            order = await _orderService.Get(id);

            await _cacheService.Add(key, order);

            return order;
        }

        public async Task<Order> Add(Guid id)
        {
            var key = $"orderId:{id}";

            var newOrder = await _orderService.Add(id);

            await _cacheService.Add(key, newOrder);
            
            return newOrder;
        }
    }
}