namespace AmirImamTask.Entities.Infrastructures;
public interface ITransactionDetailServiceBase<TResult> : IServiceBase<TransactionDetail, TResult>
{
    Task<IEnumerable<TransactionDetailDto>> FindItemsByStoreAsync(Guid storeId);
}