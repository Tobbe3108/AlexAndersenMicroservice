namespace Delivery.Microservice.Services;

using Ardalis.GuardClauses;
using Interfaces;
using Models;

internal class DeliveryService : IDeliveryService
{
  private readonly ISqlService _sqlService;

  public DeliveryService(ISqlService sqlService)
  {
    _sqlService = sqlService;
  }
  
  public Task<Delivery?> GetById(string? packageId)
  {
    Guard.Against.NullOrWhiteSpace(packageId, nameof(packageId));
    
    return _sqlService.GetById(packageId);
  }
}