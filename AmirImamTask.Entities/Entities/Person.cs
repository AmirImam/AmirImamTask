namespace AmirImamTask.Entities;

[Table(nameof(Person))]
public class Person : EntityBase
{
    [StringLength(36)]
    public string? IdentityUserId { get; set; }
    [StringLength(200), Required]
    public string PersonName { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required, StringLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;
    public string Locker { get; set; } = string.Empty;
    public ICollection<Store>? Stores { get; set; }

    [NotMapped]
    public string? AccessToken { get; set; }
}
