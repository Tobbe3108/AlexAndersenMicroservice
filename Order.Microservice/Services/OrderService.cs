using Order.Microservice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Order.Microservice.Services
{
    public class OrderService : IOrderService
    {
        private readonly SqlService<Models.Order?> _sqlService;
        public OrderService(SqlService<Models.Order?> sqlService)
        {
            _sqlService = sqlService;
        }

        public async Task<Models.Order?> CreateOrder(Models.Order? order)
        {
            return await _sqlService.Create(order);
        }

        public async Task<Models.Order?> GetOrder(int id)
        {
            return await _sqlService.GetById(id);
        }

        public async Task<Models.Order?> UpdateOrder(Models.Order? order)
        {
            return await _sqlService.Update(order) is 0 ? null : order;
        }
    }
}
