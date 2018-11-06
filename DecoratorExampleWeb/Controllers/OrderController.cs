using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DecoratorExample;

namespace DecoratorExampleWeb
{
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        public async Task<Order> Get(Guid id) => await _orderService.Get(id);
         
        public async Task<Order> Add(Guid id) =>  await _orderService.Add(id);
    }
}