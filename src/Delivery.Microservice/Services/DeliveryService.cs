namespace Delivery.Microservice.Services;

using Ardalis.GuardClauses;
using Interfaces;
using Models;

internal class DeliveryService : IDeliveryService
{
  private readonly SqlService<Delivery> _sqlService;

  public DeliveryService(SqlService<Delivery> sqlService)
  {
    _sqlService = sqlService;
  }
  
  public Task<Delivery?> GetById(string? packageId)
  {
    Guard.Against.NullOrWhiteSpace(packageId, nameof(packageId));
    
    return _sqlService.GetById(packageId);
  }
}