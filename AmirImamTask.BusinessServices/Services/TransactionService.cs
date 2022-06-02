using Microsoft.EntityFrameworkCore;

namespace AmirImamTask.BusinessServices;

public class TransactionService : ServiceBase<Transaction>, ITransactionService
{
    public TransactionService(ApplicationDbContext context) : base(context)
    {
    }


    public override async Task<ResponseResult<Transaction>> CreateAsync(Transaction entity)
    {
        using (var dbTrans = Context.Database.BeginTransaction())
        {
            try
            {
                Context.Transactions.Add(entity);

                foreach (TransactionDetail detail in entity.TransactionDetails)
                {
                    var itemStore = await (from _is in Context.ItemStores
                                     where _is.ItemId == detail.ItemId && _is.StoreId == entity.StoreId
                                     select _is).FirstOrDefaultAsync();
                    if(itemStore == null)
                    {
                        dbTrans.Rollback();
                        return ResponseResult<Transaction>.Error("ItemStore", "Item not found in the store");
                    }

                    if(detail.TransactionFactor == -1 && detail.Quantity > itemStore.Quantity)
                    {
                        dbTrans.Rollback();
                        return ResponseResult<Transaction>.Error("Item", "Item quantity is not enough");
                    }

                    //itemStore.Quantity += (detail.Quantity * detail.TransactionFactor);
                    //Context.ItemStores.Update(itemStore);
                }
                await Context.SaveChangesAsync();
                dbTrans.Commit();
                entity.TransactionDetails = null;
                return ResponseResult<Transaction>.Ok(entity);
            }
            catch (Exception ex)
            {
                dbTrans.Rollback();
                return ResponseResult<Transaction>.Error(ex);
            }
        }
    }
}
