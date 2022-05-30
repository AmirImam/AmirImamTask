

namespace AmirImamTask.Entities;

public interface IServiceBase<T,TResult> where T : EntityBase
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(Guid id);
    Task<TResult> CreateAsync(T entity);
    Task<TResult> UpdateAsync(T entity);
    Task<TResult> DeleteAsync(Guid id);

}
