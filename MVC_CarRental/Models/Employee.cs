namespace MVC_CarRental.Models;

public class Employee
    : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty; 
    public string NationalId { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty; 
    public string Phone { get; set; } = string.Empty;

    public ICollection<Office>? Offices { get; set; }
}
