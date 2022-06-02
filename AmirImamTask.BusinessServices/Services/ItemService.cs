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

    public override async Task<ResponseResult<Item>> CreateAsync(Item entity)
    {
        var demo = Set.Where(it => it.ItemCode == entity.ItemCode).Any();
        if(demo == true)
        {
            return ResponseResult<Item>.Error("ItemCode", "Item code already exists");
        }
        return await base.CreateAsync(entity);
    }

    public override async Task<ResponseResult<Item>> UpdateAsync(Item entity)
    {
        var demo = Set.Where(it => it.ItemCode == entity.ItemCode && it.Id != entity.Id).Any();
        if (demo == true)
        {
            return ResponseResult<Item>.Error("ItemCode", "Item code already exists");
        }

        return await base.UpdateAsync(entity);
    }
}
