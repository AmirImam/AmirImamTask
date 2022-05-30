namespace AmirImamTask.BusinessServices;

public class StoreService : ServiceBase<Store>, IStoreService
{
    public StoreService(ApplicationDbContext context) : base(context)
    {
    }
}
