using AmirImamTask.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AmirImamTask.BusinessServices;

public class TransactionDetailService : ServiceBase<TransactionDetail>, ITransactionDetailService
{
    public TransactionDetailService(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TransactionDetailDto>> FindItemsByStoreAsync(Guid storeId)
    {
        var result = from itemStore in Context.ItemStores
                     join item in Context.Items
                     on itemStore.ItemId equals item.Id
                     where itemStore.StoreId == storeId
                     select new TransactionDetailDto
                     {
                         ItemCode = item.ItemCode,
                         ItemDescription = item.ItemDescription,
                         ItemId = item.Id,
                         ItemName = item.ItemName,
                         Price = item.Price,
                         Quantity = 0,
                     };
        return await result.ToListAsync();
    }
}
