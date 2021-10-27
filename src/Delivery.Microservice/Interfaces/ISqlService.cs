namespace Delivery.Microservice.Interfaces;

using Models;

public interface ISqlService
{
  public Task<Delivery?> GetById(string? packageId);
}