namespace AmirImamTask.Entities.Dtos;

public class TransactionDetailDto
{
    public Guid Id { get; set; }
    public Guid? TransactionId { get; set; }

    public Guid? ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string? ItemDescription { get; set; }
    public double Price { get; set; }
    public string ItemCode { get; set; } = "";

    public int TransactionFactor { get; set; }
    public double Quantity { get; set; }
    public double Value { get; set; }
}
