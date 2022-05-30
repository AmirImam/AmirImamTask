
namespace AmirImamTask.Entities;

public class EntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}
