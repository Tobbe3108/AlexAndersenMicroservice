using System;
using System.Threading.Tasks;
using Delivery.Microservice.Interfaces;
using Delivery.Microservice.Services;
using FluentAssertions;
using Moq;
using Shared;
using Xunit;

namespace Delivery.Microservice.Tests.Unit;

public class DeliveryServiceTests
{
  private readonly DeliveryService _sut;
  private readonly Mock<SqlService<Models.Delivery>> _sqlService = new();

  public DeliveryServiceTests()
  {
    _sut = new DeliveryService(_sqlService.Object);
  }

  [Fact]
  public async Task GetById_ReturnDelivery_WithId_WhenIdIsNotNullOrWhitespace()
  {
    //Arrange
    const string id = "TestPackageId";
    _sqlService.Setup(service => service.GetById(id))
      .ReturnsAsync(new Models.Delivery(id));

    //Act
    var actual = await _sut.GetById(id);

    //Assert
    actual.Should().NotBeNull();
    actual?.PackageId.Should().NotBeNullOrWhiteSpace();
    actual?.PackageId.Should().Be(id);
  }

  [Fact]
  public async Task GetById_ThrowsArgumentNullException_WhenIdIsNull()
  {
    //Arrange
    const string? id = null;
    _sqlService.Setup(service => service.GetById(id))
      .Returns(Task.FromResult<Models.Delivery?>(null));

    //Act
    Action act = () => _sut.GetById(id);

    //Assert
    act.Should().Throw<ArgumentNullException>().WithParameterName("packageId");
  }

  [Fact]
  public async Task GetById_ThrowsArgumentException_WhenIdIsWhitespace()
  {
    //Arrange
    const string? id = "";
    _sqlService.Setup(service => service.GetById(id))
      .Returns(Task.FromResult<Models.Delivery?>(null));

    //Act
    Action act = () => _sut.GetById(id);

    //Assert
    act.Should().Throw<ArgumentException>().WithParameterName("packageId");
  }
}