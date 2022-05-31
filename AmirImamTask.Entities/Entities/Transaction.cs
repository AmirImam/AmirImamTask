namespace AmirImamTask.Entities;
[Table(nameof(Transaction))]
public class Transaction : EntityBase
{
    public DateTime TransactionDate { get; set; }
    public Guid? StoreId { get; set; }
    public Store? Store { get; set; }

    public int ItemsCount { get; set; }
    public double TotalPrices { get; set; }
    public double Net { get; set; }

    public ICollection<TransactionDetail>? TransactionDetails { get; set; }
}
