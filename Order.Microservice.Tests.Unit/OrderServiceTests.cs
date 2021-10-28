using Moq;
using Order.Microservice.Controllers;
using Order.Microservice.Interfaces;
using Order.Microservice.Services;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using Order.Microservice.Tests.Unit.Model;

namespace Order.Microservice.Tests.Unit
{
    public class OrderServiceTests
    {
        private readonly OrderService _sut;
        private readonly Mock<ISqlService> _sqlService = new();

        public OrderServiceTests()
        {
            _sut = new OrderService(_sqlService.Object);
        }


        [Theory]
        [ClassData(typeof(OrderServiceTestData))]
        public async Task CreateOrder_ShouldReturnCreateOrder(int orderId, DateTime createdDate, int customerId, string deliveryAddress, string orderNo)
        {
            // Arrange
            var orderToCreate = new Models.Order { OrderId = orderId, CreatedDate = createdDate, CustomerId = customerId, DeliveryAddress = deliveryAddress, OrderNo = orderNo };

            _sqlService.Setup(service => service.CreateOrder(orderToCreate))
                .ReturnsAsync(orderToCreate);

            // Act
            var actual = await _sut.CreateOrder(orderToCreate);

            // Assert
            actual.Should().NotBeNull();
            actual?.OrderId.Should().Be(orderToCreate.OrderId);
        }

        [InlineData(42)]
        [InlineData(53)]
        [Theory]
        public async Task GetOrder_ShouldReturnOrder(int orderId)
        {
            // Arrange
            _sqlService.Setup(service => service.GetOrder(orderId))
                .ReturnsAsync(new Models.Order { OrderId = orderId, CreatedDate = DateTime.Now, CustomerId = 1, DeliveryAddress = "Boulevard", OrderNo = "1" });

            // Act
            var actual = await _sut.GetOrder(orderId);

            // Assert
            actual?.Should().NotBeNull();
            actual?.OrderId.Should().Be(orderId);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public async Task UpdateOrder_ShouldReturnUpdatedDeliveryAddress(int orderId, DateTime createdDate, int customerId, string deliveryAddress, string orderNo)
        {
            // Arrange
            var orderToUpdate = new Models.Order { OrderId = 1, CreatedDate = DateTime.Now, CustomerId = 1, DeliveryAddress = "Boulevard", OrderNo = "1" };

            _sqlService.Setup(service => service.UpdateOrder(orderToUpdate))
                .ReturnsAsync(new Models.Order { OrderId = orderId, CreatedDate = createdDate, CustomerId = customerId, DeliveryAddress = deliveryAddress, OrderNo = orderNo });

            // Act
            var actual = await _sut.UpdateOrder(orderToUpdate);

            // Assert
            actual?.Should().NotBeNull();
            actual?.DeliveryAddress.Should().Be("Updated");
        }

        public static IEnumerable<object[]> TestData()
        {
            return new List<object[]>
            {
                new object[] {1, DateTime.Now, 1, "Updated", "1"},
                new object[] {1, DateTime.Now, "IdAsString", "Updated", "1" }
            };
        }
    }
}
