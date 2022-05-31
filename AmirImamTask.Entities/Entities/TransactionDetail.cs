namespace AmirImamTask.Entities;

[Table(nameof(TransactionDetail))]
public class TransactionDetail : EntityBase
{
    public Guid? TransactionId { get; set; }
    public Transaction? Transaction { get; set; }

    public Guid? ItemId { get; set; }
    public Item? Item { get; set; }
    public int TransactionFactor { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public double Value { get; set; }
}
