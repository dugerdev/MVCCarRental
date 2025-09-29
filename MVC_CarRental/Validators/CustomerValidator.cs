using FluentValidation;
using MVC_CarRental.Models;

namespace MVC_CarRental.Validators;

/// <summary>
/// Validator for Customer entity using FluentValidation
/// Provides comprehensive validation rules for customer data
/// </summary>
public class CustomerValidator : AbstractValidator<Customer>
{
    /// <summary>
    /// Initializes validation rules for Customer entity
    /// </summary>
    public CustomerValidator()
    {
        // National ID validation (Turkish format - 11 digits)
        RuleFor(x => x.NationalId)
            .NotEmpty()
            .WithMessage("National ID is required.")
            .Length(11, 11)
            .WithMessage("National ID must be exactly 11 characters long.")
            .Matches(@"^\d{11}$")
            .WithMessage("National ID must contain only digits.");

        // First name validation
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.")
            .Length(2, 50)
            .WithMessage("First name must be between 2 and 50 characters.")
            .Matches(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$")
            .WithMessage("First name can only contain letters and spaces.");

        // Last name validation
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.")
            .Length(2, 50)
            .WithMessage("Last name must be between 2 and 50 characters.")
            .Matches(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]+$")
            .WithMessage("Last name can only contain letters and spaces.");

        // Email validation
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email address is required.")
            .EmailAddress()
            .WithMessage("Please enter a valid email address.")
            .MaximumLength(100)
            .WithMessage("Email address cannot exceed 100 characters.");

        // Phone number validation (Turkish format)
        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(@"^\+\d{2}\s\d{3}\s\d{3}\s\d{4}$")
            .WithMessage("Phone number format is invalid. Expected format: +90 555 123 4567");
    }
}
