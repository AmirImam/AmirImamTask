using AmirImamTask.Entities.Dtos;
//using Microsoft.EntityFrameworkCore;

namespace AmirImamTask.ClientServices;

public class ItemService : ServiceBase<Item>, IItemService
{
    public ItemService(HttpClient context) : base(context)
    {
    }
    //c36734ba-2697-43e9-2619-08da4312fa08
    public async Task<IEnumerable<ItemStoreDto>> GetItemBalancesAsync()
        => await Context.GetFromJsonAsync<IEnumerable<ItemStoreDto>>($"{nameof(Item)}/GetItemBalances");

   
   
}
