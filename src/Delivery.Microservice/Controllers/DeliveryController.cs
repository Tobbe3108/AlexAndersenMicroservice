namespace Delivery.Microservice.Controllers;
using Microsoft.AspNetCore.Mvc;
using Interfaces;

[ApiController]
[Route("[controller]")]
public class DeliveryController : ControllerBase
{
  private readonly ILogger<DeliveryController> _logger;
  private readonly IDeliveryService _deliveryService;

  public DeliveryController(ILogger<DeliveryController> logger, IDeliveryService deliveryService)
  {
    _logger = logger;
    _deliveryService = deliveryService;
  }

  [HttpGet("/{packageId}", Name = nameof(GetById))]
  public async Task<IActionResult> GetById(string? packageId)
  {
    _logger.LogInformation("Fetching track info for package with id: {PackageId}", packageId);
    var delivery = await _deliveryService.GetById(packageId);
    
    if (delivery is null)
    {
      _logger.LogInformation("No package found with id: {PackageId}", packageId);
      return NotFound();
    }
    
    _logger.LogInformation("Found package: {Delivery}", delivery);
    return Ok(delivery);
  }
}