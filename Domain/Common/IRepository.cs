namespace Domain.Common;

public interface IRepository<T>
{
  Task<T?> GetByIdAsync(Guid id);
  Task AddAsync(T entity);
  Task DeleteAsync(T entity);
}
