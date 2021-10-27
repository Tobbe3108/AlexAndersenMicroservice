using Order.Microservice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Microservice.Services
{
    public class SqlService : ISqlService
    {
        public async Task<Models.Order> CreateOrder(Models.Order order)
        {
            return new Models.Order { OrderId = 1, CreatedDate = DateTime.Now, CustomerId = 1, DeliveryAddress = "Boulevard", OrderNo = "1" };
        }
        public async Task<Models.Order> GetOrder(int? orderId)
        {
            return new Models.Order { OrderId = 1, CreatedDate = DateTime.Now, CustomerId = 1, DeliveryAddress = "Boulevard", OrderNo = "1" };
        }
        public async Task<Models.Order> UpdateOrder(Models.Order order)
        {
            return new Models.Order { OrderId = 1, CreatedDate = DateTime.Now, CustomerId = 1, DeliveryAddress = "Updated", OrderNo = "1" };
        }
    }
}
