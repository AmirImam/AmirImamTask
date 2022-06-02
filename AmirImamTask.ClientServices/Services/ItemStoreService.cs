using AmirImamTask.Entities.Dtos;
//using Microsoft.EntityFrameworkCore;

namespace AmirImamTask.ClientServices;

public class ItemStoreService : ServiceBase<ItemStore>, IItemStoreService
{
    public ItemStoreService(HttpClient context) : base(context)
    {
    }

    public async Task<IEnumerable<ItemStoreDto>> GetItemStoresByItemAsync(Guid itemId)
        => await Context.GetFromJsonAsync<IEnumerable<ItemStoreDto>>($"{nameof(ItemStore)}/GetItemStoresByItem/{itemId}");
}
