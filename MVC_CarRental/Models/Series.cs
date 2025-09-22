namespace MVC_CarRental.Models;

public class Series
    : BaseEntity
{
    public Guid BrandId { get; set; }
    public string Name { get; set; } = string.Empty;

    public Brand? Brand { get; set; }
    public ICollection<Vehicle>? Vehicles { get; set; }
}
