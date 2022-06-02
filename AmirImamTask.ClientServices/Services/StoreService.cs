

namespace AmirImamTask.ClientServices;

public class StoreService : ServiceBase<Store>, IStoreService
{
    public StoreService(HttpClient context) : base(context)
    {
    }

   
}
