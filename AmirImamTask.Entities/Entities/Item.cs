namespace AmirImamTask.Entities;

[Table(nameof(Item))]
public class Item : EntityBase
{
    [Required, StringLength(200)]
    public string ItemName { get; set; } = string.Empty;
    [StringLength(500)]
    public string? ItemDescription { get; set; }
    public double Price { get; set; }
    public ICollection<ItemStore>? ItemStores { get; set; }
}
