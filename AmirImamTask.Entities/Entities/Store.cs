namespace AmirImamTask.Entities;

[Table(nameof(Store))]
public class Store : EntityBase
{
    [StringLength(200), Required]
    public string StoreName { get; set; } = string.Empty;

    public Guid? PersonId { get; set; }
    public Person? Person { get; set; }
    public ICollection<ItemStore>? ItemStores { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }

    [NotMapped]
    public string? PersonName { get; set; }
}
