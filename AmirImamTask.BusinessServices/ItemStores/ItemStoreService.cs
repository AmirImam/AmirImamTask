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
        //  string query = $@" SELECT Item.[ItemName], Store.[StoreName], ItemStore.[Quantity]
        //FROM [Store] 
        //LEFT JOIN [ItemStore] ON Store.[Id] = ItemStore.[StoreId]
        //LEFT OUTER JOIN [Item]  ON ItemStore.[ItemId] = Item.[Id] and ItemStore.ItemId = '{itemId}'";
        //  var result = new DbSet<ItemStoreDto>().FromSqlRaw<ItemStoreDto>(query);
        //var xcasx = from x in Context.ItemStores
        //            join y in Context.Items
        //            on new { X1 = x.ItemId.Value, X2 = x.ItemId.Value } equals new { X1 = y.Id, X2 = itemId }
        //            select new
        //            {
        //                /// Columns
        //            };
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
