using AmirImamTask.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AmirImamTask.BusinessServices;

public class ItemStoreService : ServiceBase<ItemStore>, IItemStoreService
{
    public ItemStoreService(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ItemStoreDto>> GetItemStoresByItemAsync(Guid itemId)
    {
       
        var result = from store in Context.Stores
                     join itemStore in Context.ItemStores 
                     on new { s1 = store.Id,s2=itemId } equals new { s1 = itemStore.StoreId.Value,s2=itemStore.ItemId.Value } into store_itemStore_j
                     from store_itemStore in store_itemStore_j.DefaultIfEmpty()
                     join item in Context.Items
                     on new 
                     { i1 = store_itemStore.ItemId.Value, i2 = store_itemStore.ItemId.Value } 
                     equals new { i1= item.Id, i2= itemId }
                     into item_itemStore_j
                     from item_itemStore in item_itemStore_j.DefaultIfEmpty()
                     //where store_itemStore.ItemId == itemId || store_itemStore.ItemId == null
                     select new ItemStoreDto
                     {
                         ItemId = item_itemStore.Id,
                         StoreId = store.Id,
                         ItemStoreId = store_itemStore.Id,
                         ItemName = item_itemStore.ItemName,
                         StoreName = store.StoreName,
                         Quantity = store_itemStore.Quantity
                     };


       
        return await result.ToListAsync();
    }
}
