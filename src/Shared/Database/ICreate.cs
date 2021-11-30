namespace Shared.Database;

public interface ICreate<T> where T : class?
{
  public Task<T> Create(T model);
}