namespace Shared.Database;

public interface IGetById<T> where T : class?
{
  public Task<T?> GetById(object id);
}