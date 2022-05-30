namespace AmirImamTask.BusinessServices;

public class ItemStoreService : ServiceBase<ItemStore>, IItemStoreService
{
    public ItemStoreService(ApplicationDbContext context) : base(context)
    {
    }
}
