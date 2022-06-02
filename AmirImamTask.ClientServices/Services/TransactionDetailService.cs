using AmirImamTask.Entities.Dtos;
//using Microsoft.EntityFrameworkCore;

namespace AmirImamTask.ClientServices;

public class TransactionDetailService : ServiceBase<TransactionDetail>, ITransactionDetailService
{
    public TransactionDetailService(HttpClient context) : base(context)
    {
    }

    public async Task<IEnumerable<TransactionDetailDto>> FindItemsByStoreAsync(Guid storeId)
        => await Context.GetFromJsonAsync<IEnumerable<TransactionDetailDto>>($"{nameof(TransactionDetail)}/FindItemsByStoreAsync/{storeId}");
}
