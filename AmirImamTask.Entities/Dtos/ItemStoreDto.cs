namespace AmirImamTask.Entities.Dtos;

public class ItemStoreDto
{
    public Guid? ItemStoreId { get; set; }
    public Guid? ItemId { get; set; }
    public string? ItemName { get; set; } = string.Empty;

    public Guid? StoreId { get; set; }
    public string? StoreName { get; set; } = string.Empty;

    public Guid? PersonId { get; set; }
    public string? PersonName { get; set; } = string.Empty;

    public double? Quantity { get; set; }
}
