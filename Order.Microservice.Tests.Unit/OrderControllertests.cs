using Microsoft.Extensions.Logging;
using Moq;
using Order.Microservice.Controllers;
using Order.Microservice.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Order.Microservice.Tests.Unit
{
    public class OrderControllerTests
    {
        private readonly OrderController _sut;
        private readonly Mock<IOrderService> _orderService = new();
        private readonly Mock<ILogger<OrderController>> _logger = new();

        public OrderControllerTests()
        {
            _sut = new OrderController(_logger.Object, _orderService.Object);
        }

        [Fact]
        public async Task GetOrder_ReturnOkObjectResult_WhenIdExists()
        {
            // Arrange
            int id = 1;
            var order = new Models.Order { OrderId = id, CreatedDate = DateTime.Now, CustomerId = 1, DeliveryAddress = "Boulevard", OrderNo = "1" };

            _orderService.Setup(service => service.GetOrder(id))
                .ReturnsAsync(order);

            // Act 
            var actual = await _sut.GetOrder(id);

            // Assert
            actual?.Should().NotBeNull();
            actual?.As<OkObjectResult>().Value.Should().Be(order);

        }

        [Fact]
        public async Task CreateOrder_ReturnOkObjectResultWithObject_WhenSuccessfullyCreated()
        {
            // Arrange
            var order = new Models.Order { OrderId = 1, CreatedDate = DateTime.Now, CustomerId = 1, DeliveryAddress = "Boulevard", OrderNo = "1" };

            _orderService.Setup(service => service.CreateOrder(order))
                .ReturnsAsync(order);

            // Act 
            var actual = await _sut.CreateOrder(order);

            // Assert
            actual?.Should().NotBeNull();
            actual?.As<OkObjectResult>().Value.Should().Be(order);

        }

        [Fact]
        public async Task UpdateOrder_ReturnOkObjectResultWithObject_WhenSuccessfullyUpdated()
        {
            // Arrange
            var order = new Models.Order { OrderId = 1, CreatedDate = DateTime.Now, CustomerId = 1, DeliveryAddress = "Boulevard", OrderNo = "1" };

            _orderService.Setup(service => service.UpdateOrder(order))
                .ReturnsAsync(order);

            // Act 
            var actual = await _sut.UpdateOrder(order);

            // Assert
            actual?.Should().NotBeNull();
            actual?.As<OkObjectResult>().Value.Should().Be(order);

        }
    }
}
