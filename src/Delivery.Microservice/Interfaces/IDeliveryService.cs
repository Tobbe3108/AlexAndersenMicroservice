namespace Delivery.Microservice.Interfaces;

using Models;

public interface IDeliveryService
{
  public Task<Delivery?> GetById(string? packageId);
}