namespace MVC_CarRental.Models;

public class Office
    : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public Employee? Employee { get; set; }
    public ICollection<Rental>? PickupRentals { get; set; }
    public ICollection<Rental>? ReturnRentals { get; set; }
}
