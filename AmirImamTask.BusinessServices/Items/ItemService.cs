using AmirImamTask.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AmirImamTask.BusinessServices;

public class ItemService : ServiceBase<Item>, IItemService
{
    public ItemService(ApplicationDbContext context) : base(context)
    {
    }
    //c36734ba-2697-43e9-2619-08da4312fa08
    public async Task<IEnumerable<ItemStoreDto>> GetItemBalancesAsync()
    {
        var results = from itemStore in Context.ItemStores
                      join item in Context.Items
                      on itemStore.ItemId equals item.Id
                      group itemStore by new { itemStore.ItemId,item.ItemName } into g
                      select new ItemStoreDto
                      {
                          ItemName = g.Key.ItemName,
                          Quantity = g.Sum(it=> it.Quantity)
                      };
        return await results.ToListAsync();
    }
}
