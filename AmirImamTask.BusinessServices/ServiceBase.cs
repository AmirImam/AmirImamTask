using AmirImamTask.DataServices;
using AmirImamTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmirImamTask.BusinessServices;

public class ServiceBase<T> : IServiceBase<T,ResponseResult<T>> where T : EntityBase
{
    private readonly ApplicationDbContext context;

    public ServiceBase(ApplicationDbContext context)
    {
        this.context = context;
        this.Set = context.Set<T>();
    }
    protected DbSet<T> Set { get; }

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await Set.ToListAsync();
    public virtual async Task<T> GetAsync(Guid id) => await Set.FindAsync(id);

    public virtual async Task<ResponseResult<T>> CreateAsync(T entity)
    {
        try
        {
            Set.Add(entity);
            await context.SaveChangesAsync();
            return ResponseResult<T>.Ok(entity);
        }
        catch (Exception ex)
        {
            return ResponseResult<T>.Error(ex);
        }
    }
    public virtual async Task<ResponseResult<T>> UpdateAsync(T entity)
    {
        try
        {
            Set.Update(entity);
            await context.SaveChangesAsync();
            return ResponseResult<T>.Ok(entity);
        }
        catch (Exception ex)
        {
            return ResponseResult<T>.Error(ex);
        }
    }
    public virtual async Task<ResponseResult<T>> DeleteAsync(Guid id)
    {
        try
        {
            var entity = await GetAsync(id);
            if(entity == null)
            {

            }
            Set.Remove(entity);
            await context.SaveChangesAsync();
            return ResponseResult<T>.Ok(entity);
        }
        catch (Exception ex)
        {
            return ResponseResult<T>.Error(ex);
        }
    }

    

}
