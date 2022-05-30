namespace AmirImamTask.DataServices;
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions options):base(options)
    {

    }

    public DbSet<Person> People { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemStore> ItemStores { get; set; }    
}
