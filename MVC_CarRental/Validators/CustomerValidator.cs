using FluentValidation;
using MVC_CarRental.Models;

namespace MVC_CarRental.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.NationalId)
                .NotEmpty()
                .WithMessage("It is mandatory to enter the National ID.")
                .Length(11, 11)
                .WithMessage("National ID must have a minimum and maximum of 11 characters.");

            RuleFor(x => x.FirstName)
               .NotEmpty()
               .WithMessage("It is mandatory to enter the First Name.")
               .Length(2, 255)
               .WithMessage("First Name must have a minimum 2 characters and maximum 255 characters.");


            RuleFor(x => x.LastName)
               .NotEmpty()
               .WithMessage("It is mandatory to enter the Last Name.")
               .Length(2, 255)
               .WithMessage("Last Name must have a minimum 2 characters and maximum 255 characters.");

            RuleFor(x => x.Email)
              .NotEmpty()
              .WithMessage("It is mandatory to enter the Email Address.")
              .EmailAddress()
              .WithMessage("Please enter a valid email address.");

            RuleFor(x => x.Phone)
                 .NotEmpty()
                 .WithMessage("It is mandatory to enter the Phone Number.")
                 .Length(15)
                 .WithMessage("Phone number must be exactly 15 characters long.")
                 .Matches(@"^\+\d{2}\s\d{3}\s\d{3}\s\d{4}$")
                 .WithMessage("Phone number format is invalid. Example: +90 555 444 3322");

        }
    }
}
