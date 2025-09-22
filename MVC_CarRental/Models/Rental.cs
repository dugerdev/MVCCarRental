namespace MVC_CarRental.Models;

public class Rental
    : BaseEntity
{
    public Guid CustomerId { get; set; }
    public Guid VehicleId { get; set; }
    public DateTimeOffset StartsDate { get; set; }
    public DateTimeOffset EndsDate { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid PickupLocationId { get; set; }
    public Guid ReturnLocationId { get; set; }

    public Customer? Customer { get; set; }
    public Vehicle? Vehicle { get; set; }
    public Office? PickupOffice { get; set; }
    public Office? ReturnOffice { get; set; }
}
