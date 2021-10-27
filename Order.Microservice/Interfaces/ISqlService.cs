using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Microservice.Interfaces
{
    public interface ISqlService
    {
        public Task<Models.Order> CreateOrder(Models.Order order);
        public Task<Models.Order> GetOrder(int? orderId);
        public Task<Models.Order> UpdateOrder(Models.Order order);
    }
}
