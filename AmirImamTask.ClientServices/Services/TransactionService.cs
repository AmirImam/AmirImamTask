//using Microsoft.EntityFrameworkCore;

namespace AmirImamTask.ClientServices;

public class TransactionService : ServiceBase<Transaction>, ITransactionService
{
    public TransactionService(HttpClient context) : base(context)
    {
    }
    
}
