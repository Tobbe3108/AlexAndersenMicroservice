using Delivery.Microservice.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace Delivery.Microservice.Tests.Integration;

public class DeliveryEndpointsTests : IClassFixture<WebApplicationFactory<DeliveryController>>
{
  private readonly WebApplicationFactory<DeliveryController> _factory;

  public DeliveryEndpointsTests(WebApplicationFactory<DeliveryController> factory)
  {
    _factory = factory;
  }

  [Fact]
  public async void GetById_ReturnsHttpSuccess_WhenIdIsNotNullOrWhitespace()
  {
    // Arrange
    var client = _factory.CreateClient();

    // Act
    var response = await client.GetAsync("/1234");

    // Assert
    response.EnsureSuccessStatusCode(); // Status Code 200-299
    Assert.Equal("application/json; charset=utf-8",
        response.Content.Headers.ContentType.ToString());
  }

  [Fact]
  public async void GetById_ReturnsHttpMethodNotAllowed_WhenRequestMethodIsPost()
  {
    // Arrange
    var client = _factory.CreateClient();

    // Act
    var response = await client.PostAsync("/1234", null);

    // Assert
    Assert.Equal(HttpStatusCode.MethodNotAllowed, response.StatusCode);
  }
}