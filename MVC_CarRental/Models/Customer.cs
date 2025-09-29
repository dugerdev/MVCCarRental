namespace MVC_CarRental.Models;

/// <summary>
/// Represents a customer in the car rental system
/// Contains personal information and rental history
/// </summary>
public class Customer : BaseEntity
{
    /// <summary>
    /// Customer's first name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Customer's last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Customer's national identification number (11 digits for Turkey)
    /// </summary>
    public string NationalId { get; set; } = string.Empty;

    /// <summary>
    /// Customer's email address for communication
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Customer's phone number for contact
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Navigation property for customer's rental history
    /// </summary>
    public ICollection<Rental>? Rentals { get; set; }

    /// <summary>
    /// Gets the full name of the customer (FirstName + LastName)
    /// </summary>
    public string FullName => $"{FirstName} {LastName}".Trim();
}
