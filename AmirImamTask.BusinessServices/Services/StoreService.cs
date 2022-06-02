

namespace AmirImamTask.BusinessServices;

public class StoreService : ServiceBase<Store>, IStoreService
{
    public StoreService(ApplicationDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Store>> GetAllAsync()
    {
        var result = from store in Context.Stores
                     join person in Context.People
                     on store.PersonId equals person.Id
                     select new Store
                     {
                         Id = store.Id,
                         PersonId = person.Id,
                         PersonName = person.PersonName,
                         StoreName = store.StoreName
                     };
        return await result.ToListAsync();
    }
}
