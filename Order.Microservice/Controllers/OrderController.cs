using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order.Microservice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Microservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Models.Order order)
        {
            var createdOrder = await _orderService.CreateOrder(order);

            if (createdOrder != null)
            {
                _logger.LogInformation($"Created order {order.OrderId} at {DateTime.Now}");
                return Ok(createdOrder);
            }

            _logger.LogInformation($"Failed to create order {order.OrderId} at {DateTime.Now}");
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder(int? orderId)
        {
            var orderFound = await _orderService.GetOrder(orderId);

            if(orderFound != null)
            {
                _logger.LogInformation($"Found order {orderFound.OrderId} at {DateTime.Now}");
                return Ok(orderFound);
            }

            _logger.LogInformation($"Error finding order {orderId} at {DateTime.Now}");
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] Models.Order order)
        {
            var updatedOrder = await _orderService.UpdateOrder(order);

            if(updatedOrder != null)
            {
                _logger.LogInformation($"Updated order {updatedOrder.OrderId} at {DateTime.Now}");
                return Ok(updatedOrder);
            }

            _logger.LogInformation($"Error finding order {order.OrderId} at {DateTime.Now}");
            return BadRequest();
        }
    }
}
