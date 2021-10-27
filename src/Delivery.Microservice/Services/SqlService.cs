namespace Delivery.Microservice.Services;

using Interfaces;
using  Models;

internal class SqlService : ISqlService
{
  public Task<Delivery?> GetById(string? packageId)
  {
    return Task.FromResult(new Delivery("HTJMD7556GH"))!;
  }
}