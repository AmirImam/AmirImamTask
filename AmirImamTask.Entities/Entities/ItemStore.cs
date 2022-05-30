namespace AmirImamTask.Entities;

[Table(nameof(ItemStore))]
public class ItemStore : EntityBase
{
    public Guid? ItemId { get; set; }
    public Item? Item { get; set; }

    public Guid? StoreId { get; set; }
    public Store? Store { get; set; }

    public double Quantity { get; set; }

}