using AmirImamTask.Entities.Dtos;

namespace AmirImamTask.BusinessServices;

public class ItemStoreService : ServiceBase<ItemStore>, IItemStoreService
{
    public ItemStoreService(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ItemStoreDto>> GetItemStoresByItemAsync(Guid itemId)
    {
        var result = from store in Context.Stores
                     join itemStore in Context.ItemStores on store.Id equals itemStore.StoreId into store_itemStore_j
                     from store_itemStore in store_itemStore_j.DefaultIfEmpty()

                     join item in Context.Items on store_itemStore.ItemId equals item.Id into item_itemStore_j
                     from item_itemStore in item_itemStore_j.DefaultIfEmpty()
                     where store_itemStore.ItemId == itemId || store_itemStore.ItemId == null
                     select new ItemStoreDto
                     {
                         
                         ItemName = item_itemStore.ItemName,
                         StoreName = store.StoreName,
                         Quantity = store_itemStore.Quantity
                     };
                     

        //var result = from store in Context.Stores
        //               join itemStore in Context.ItemStores 
        //               on store.Id equals itemStore.StoreId into store_itemStore_join
        //               from store_itemStore in store_itemStore_join.DefaultIfEmpty()
        //               join item in Context.Items
        //               on store_itemStore.ItemId equals item.Id into item_itemStore_join
        //               from item_itemStore in item_itemStore_join.DefaultIfEmpty()

        //               where store_itemStore.ItemId == itemId || store_itemStore.ItemId == null
        //             select new ItemStoreDto
        //             {
        //                 ItemStoreId = store_itemStore.Id,
                         
        //                 ItemId = item_itemStore.Id,
        //                 ItemName = item_itemStore.ItemName,

        //                 StoreId = store.Id,
        //                 StoreName = store.StoreName,

        //                 Quantity = store_itemStore.Quantity

        //             };

        
        return await result.ToListAsync();
    }
}
