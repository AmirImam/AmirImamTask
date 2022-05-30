namespace AmirImamTask.BusinessServices;

public class ItemService : ServiceBase<Item>, IItemService
{
    public ItemService(ApplicationDbContext context) : base(context)
    {
    }
}
