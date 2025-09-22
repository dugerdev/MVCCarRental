namespace MVC_CarRental.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? UpdatedOn { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }
}
