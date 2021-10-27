using System.Threading.Tasks;
using Delivery.Microservice.Controllers;
using Delivery.Microservice.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Delivery.Microservice.Tests.Unit;

public class DeliveryControllerTests
{
  private readonly DeliveryController _sut;
  private readonly Mock<IDeliveryService> _deliveryService = new();
  private readonly Mock<ILogger<DeliveryController>> _logger = new();

  public DeliveryControllerTests()
  {
    _sut = new DeliveryController(_logger.Object, _deliveryService.Object);
  }

  [Fact]
  public async Task GetById_ReturnOkObjectResult_WithDelivery_WithId_WhenIdIsNotNullOrWhitespace()
  {
    //Arrange
    const string? id = "TestPackageId";
    _deliveryService.Setup(service => service.GetById(id))
      .ReturnsAsync(new Models.Delivery(id));

    //Act
    var actual = await _sut.GetById(id);

    //Assert
    actual.Should().BeOfType<OkObjectResult>();
    actual.As<OkObjectResult>().Value.Should().Be(new Models.Delivery(id));
  }

  [Fact]
  public async Task GetById_ReturnNotFound_WhenIdIsNull()
  {
    //Arrange
    const string? id = null;
    _deliveryService.Setup(service => service.GetById(id))
      .Returns(Task.FromResult<Models.Delivery?>(null));

    //Act
    var actual = await _sut.GetById(id);

    //Assert
    actual.Should().BeOfType<NotFoundResult>();
  }

  [Fact]
  public async Task GetById_ReturnNotFound_WhenIdIsWhitespace()
  {
    //Arrange
    const string? id = "";
    _deliveryService.Setup(service => service.GetById(id))
      .Returns(Task.FromResult<Models.Delivery?>(null));

    //Act
    var actual = await _sut.GetById(id);

    //Assert
    actual.Should().BeOfType<NotFoundResult>();
  }
}