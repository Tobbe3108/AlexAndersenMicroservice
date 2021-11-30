namespace Shared.Database;

public interface IUpdate<T> where T : class?
{
  public Task<T> Update(T model);
}