using Order.Microservice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Microservice.Services
{
    public class OrderService : IOrderService
    {
        private readonly ISqlService _sqlService;
        public OrderService(ISqlService sqlService)
        {
            _sqlService = sqlService;
        }

        public async Task<Models.Order> CreateOrder(Models.Order order)
        {
            return await _sqlService.CreateOrder(order);
        }

        public async Task<Models.Order> GetOrder(int? id)
        {
            return await _sqlService.GetOrder(id);
        }

        public async Task<Models.Order> UpdateOrder(Models.Order order)
        {
            return await _sqlService.UpdateOrder(order);
        }
    }
}
