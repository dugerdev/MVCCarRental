using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CarRental.Data;
using MVC_CarRental.Extentions;
using MVC_CarRental.Models;

namespace MVC_CarRental.Controllers;

/// <summary>
/// Controller responsible for managing customer operations
/// Handles CRUD operations for customers in the car rental system
/// </summary>
public class CustomersController(ApplicationDbContext context, IValidator<Customer> validator) : Controller
{
    #region Index Actions

    /// <summary>
    /// Displays the list of all customers
    /// </summary>
    /// <returns>View containing the customer list</returns>
    public IActionResult Index()
    {
        // Retrieve all customers without tracking for read-only operations
        var customers = context.Customers
            .AsNoTracking()
            .ToList();

        return View(customers);
    }

    #endregion

    #region Create Actions

    /// <summary>
    /// Displays the create customer form
    /// </summary>
    /// <returns>View containing the create form</returns>
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// Handles the creation of a new customer
    /// </summary>
    /// <param name="model">Customer data from the form</param>
    /// <returns>Redirects to index on success, returns view with errors on failure</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Customer model)
    {
        // Validate the model using FluentValidation
        var validationResult = validator.Validate(model);

        if (validationResult.IsValid)
        {
            // Check for duplicate data before saving
            if (HasDuplicateData(model))
            {
                return View(model);
            }

            // Set audit fields
            model.Id = Guid.CreateVersion7(TimeProvider.System.GetLocalNow());
            model.CreatedOn = TimeProvider.System.GetLocalNow();

            // Save the customer to database
            context.Customers.Add(model);
            context.SaveChanges();

            // Redirect to customer list on success
            return RedirectToAction(nameof(Index));
        }

        // Add validation errors to ModelState
        validationResult.AddToModelState(ModelState);
        return View(model);
    }

    #endregion

    #region Edit Actions

    /// <summary>
    /// Displays the edit customer form
    /// </summary>
    /// <param name="id">Customer ID to edit</param>
    /// <returns>View containing the edit form or NotFound if customer doesn't exist</returns>
    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        var customer = context.Customers.Find(id);
        if (customer is null)
        {
            return NotFound();
        }

        return View(customer);
    }

    /// <summary>
    /// Handles the update of an existing customer
    /// </summary>
    /// <param name="id">Customer ID to update</param>
    /// <param name="model">Updated customer data from the form</param>
    /// <returns>Redirects to index on success, returns view with errors on failure</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Guid id, Customer model)
    {
        // Verify that the ID matches the model ID
        if (id != model.Id)
        {
            return BadRequest();
        }

        // Validate the model using FluentValidation
        var validationResult = validator.Validate(model);
        if (validationResult.IsValid)
        {
            // Check for duplicate data (excluding current record)
            if (HasDuplicateDataForUpdate(model))
            {
                return View(model);
            }

            // Find the existing customer
            var existingCustomer = context.Customers.Find(id);
            if (existingCustomer is null)
            {
                return NotFound();
            }

            // Update customer properties
            existingCustomer.FirstName = model.FirstName;
            existingCustomer.LastName = model.LastName;
            existingCustomer.NationalId = model.NationalId;
            existingCustomer.Email = model.Email;
            existingCustomer.Phone = model.Phone;
            existingCustomer.UpdatedOn = TimeProvider.System.GetLocalNow();

            // Save changes to database
            context.Update(existingCustomer);
            context.SaveChanges();

            // Redirect to customer list on success
            return RedirectToAction(nameof(Index));
        }

        // Add validation errors to ModelState
        validationResult.AddToModelState(ModelState);
        return View(model);
    }

    #endregion

    #region Delete Actions

    /// <summary>
    /// Displays the delete confirmation page
    /// </summary>
    /// <param name="id">Customer ID to delete</param>
    /// <returns>View containing delete confirmation or NotFound if customer doesn't exist</returns>
    [HttpGet]
    public IActionResult Delete(Guid id)
    {
        var customer = context.Customers
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        if (customer is null)
        {
            return NotFound();
        }

        return View(customer);
    }

    /// <summary>
    /// Handles the deletion of a customer
    /// </summary>
    /// <param name="id">Customer ID to delete</param>
    /// <returns>Redirects to index on success, returns NotFound if customer doesn't exist</returns>
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(Guid id)
    {
        var customer = context.Customers.Find(id);
        if (customer is null)
        {
            return NotFound();
        }

        // Remove customer from database
        context.Customers.Remove(customer);
        context.SaveChanges();

        // Redirect to customer list
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Private Helper Methods

    /// <summary>
    /// Checks if the customer data contains any duplicate values
    /// Used during customer creation
    /// </summary>
    /// <param name="customer">Customer to check</param>
    /// <returns>True if duplicates found, false otherwise</returns>
    private bool HasDuplicateData(Customer customer)
    {
        bool hasDuplicates = false;

        // Check for duplicate email
        if (context.Customers.AsNoTracking().Any(x => x.Email == customer.Email))
        {
            ModelState.AddModelError(nameof(customer.Email), "This email has been used before.");
            hasDuplicates = true;
        }

        // Check for duplicate national ID
        if (context.Customers.AsNoTracking().Any(x => x.NationalId == customer.NationalId))
        {
            ModelState.AddModelError(nameof(customer.NationalId), "This national ID has been used before.");
            hasDuplicates = true;
        }

        // Check for duplicate phone number
        if (context.Customers.AsNoTracking().Any(x => x.Phone == customer.Phone))
        {
            ModelState.AddModelError(nameof(customer.Phone), "This phone number has been used before.");
            hasDuplicates = true;
        }

        return hasDuplicates;
    }

    /// <summary>
    /// Checks if the customer data contains any duplicate values (excluding current record)
    /// Used during customer update
    /// </summary>
    /// <param name="customer">Customer to check</param>
    /// <returns>True if duplicates found, false otherwise</returns>
    private bool HasDuplicateDataForUpdate(Customer customer)
    {
        bool hasDuplicates = false;

        // Check for duplicate email (excluding current record)
        if (context.Customers.AsNoTracking().Any(x => x.Email == customer.Email && x.Id != customer.Id))
        {
            ModelState.AddModelError(nameof(customer.Email), "This email has been used before.");
            hasDuplicates = true;
        }

        // Check for duplicate national ID (excluding current record)
        if (context.Customers.AsNoTracking().Any(x => x.NationalId == customer.NationalId && x.Id != customer.Id))
        {
            ModelState.AddModelError(nameof(customer.NationalId), "This national ID has been used before.");
            hasDuplicates = true;
        }

        // Check for duplicate phone number (excluding current record)
        if (context.Customers.AsNoTracking().Any(x => x.Phone == customer.Phone && x.Id != customer.Id))
        {
            ModelState.AddModelError(nameof(customer.Phone), "This phone number has been used before.");
            hasDuplicates = true;
        }

        return hasDuplicates;
    }

    #endregion
}
