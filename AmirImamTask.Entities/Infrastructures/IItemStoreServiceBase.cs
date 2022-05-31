

namespace AmirImamTask.Entities.Infrastructures;

public interface IItemStoreServiceBase<TResult>:IServiceBase<ItemStore, TResult>
{
    Task<IEnumerable<ItemStoreDto>> GetItemStoresByItemAsync(Guid itemId);
}