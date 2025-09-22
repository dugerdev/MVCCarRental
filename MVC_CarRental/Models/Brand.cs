namespace MVC_CarRental.Models;

public class Brand
    : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Series>? Series { get; set; }
}
