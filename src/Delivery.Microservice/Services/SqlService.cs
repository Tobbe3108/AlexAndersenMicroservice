using Microsoft.Data.SqlClient;
using Shared.Database;
using RepoDb;

namespace Delivery.Microservice.Services;

internal class SqlService<T> : IGetById<T> where T : class?
{
  private readonly SqlConnection _sqlConnection;
  public async Task<T?> GetById(object id)
  {
    return (await _sqlConnection.QueryAsync<T>(id)).FirstOrDefault();
  }
}