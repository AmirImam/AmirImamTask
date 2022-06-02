namespace AmirImamTask.Entities.Infrastructures;

public interface IItemServiceBase<TResult> : IServiceBase<Item, TResult>
{
    Task<IEnumerable<ItemStoreDto>> GetItemBalancesAsync();
}
