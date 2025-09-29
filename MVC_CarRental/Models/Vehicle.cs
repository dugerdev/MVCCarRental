using MVC_CarRental.Models.Enums;

namespace MVC_CarRental.Models;

/// <summary>
/// Represents a vehicle in the car rental system
/// Contains vehicle specifications and rental information
/// </summary>
public class Vehicle : BaseEntity
{
    /// <summary>
    /// Foreign key reference to the vehicle series
    /// </summary>
    public Guid SeriesId { get; set; }

    /// <summary>
    /// Vehicle's license plate number
    /// </summary>
    public string Plate { get; set; } = string.Empty;

    /// <summary>
    /// Manufacturing year of the vehicle series
    /// </summary>
    public string SeriesYear { get; set; } = string.Empty;

    /// <summary>
    /// Type of fuel the vehicle uses (Gas, Diesel, Electric)
    /// </summary>
    public FuelType FuelType { get; set; }

    /// <summary>
    /// Transmission type: true for Automatic, false for Manual
    /// </summary>
    public bool GearType { get; set; }

    /// <summary>
    /// Gets a human-readable string representation of the gear type
    /// </summary>
    public string GearTypeName => GearType ? "Automatic" : "Manual";

    /// <summary>
    /// Daily rental price for this vehicle
    /// </summary>
    public decimal DailyPrice { get; set; }

    /// <summary>
    /// Navigation property to the vehicle's series
    /// </summary>
    public Series? Series { get; set; }

    /// <summary>
    /// Navigation property for rental history of this vehicle
    /// </summary>
    public ICollection<Rental>? Rentals { get; set; }
}
