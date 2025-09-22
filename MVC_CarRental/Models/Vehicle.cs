using MVC_CarRental.Models.Enums;

namespace MVC_CarRental.Models;

public class Vehicle
    : BaseEntity
{
    public Guid SeriesId { get; set; }
    public string Plate { get; set; } = string.Empty;
    public string SeriesYear { get; set; } = string.Empty;
    public FuelType FuelType { get; set; }
    public bool GearType { get; set; }
    public string GearTypeName => this.GearType ? "Automatic" : "Manuel";
    public decimal DailyPrice { get; set; }

    public Series? Series { get; set; }
    public ICollection<Rental>? Rentals { get; set; }
}
