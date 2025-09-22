using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CarRental.Data;
using MVC_CarRental.Extentions;
using MVC_CarRental.Models;

namespace MVC_CarRental.Controllers;

public class CustomersController(ApplicationDbContext context, IValidator<Customer> Validator)
    : Controller
{
    public IActionResult Index()
    {
        List<Customer> customers = context.Customers
            .AsNoTracking()
            .ToList();

        return View(customers);
    }

    // -------- CREATE --------
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Customer model)
    {
        var FluentValidatorResult = Validator.Validate(model);

        if (FluentValidatorResult.IsValid)
        {
            if (context.Customers.AsNoTracking().Any(x => x.Email == model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "This email has been used before.");
                return View(model);
            }

            if (context.Customers.AsNoTracking().Any(x => x.NationalId == model.NationalId))
            {
                ModelState.AddModelError(nameof(model.NationalId), "This national id has been used before.");
                return View(model);
            }

            if (context.Customers.AsNoTracking().Any(x => x.Phone == model.Phone))
            {
                ModelState.AddModelError(nameof(model.Phone), "This phone number has been used before.");
                return View(model);
            }

            model.Id = Guid.CreateVersion7(TimeProvider.System.GetLocalNow());
            model.CreatedOn = TimeProvider.System.GetLocalNow();

            context.Customers.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        FluentValidatorResult.AddToModelState(this.ModelState);
        return View(model);
    }

    // -------- UPDATE --------
    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        var customer = context.Customers.Find(id);
        if (customer is null)
            return NotFound();

        return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Guid id, Customer model)
    {
        if (id != model.Id)
            return BadRequest();

        var FluentValidatorResult = Validator.Validate(model);
        if (FluentValidatorResult.IsValid)
        {
            // Duplicate check (except current record)
            if (context.Customers.AsNoTracking().Any(x => x.Email == model.Email && x.Id != model.Id))
            {
                ModelState.AddModelError(nameof(model.Email), "This email has been used before.");
                return View(model);
            }

            if (context.Customers.AsNoTracking().Any(x => x.NationalId == model.NationalId && x.Id != model.Id))
            {
                ModelState.AddModelError(nameof(model.NationalId), "This national id has been used before.");
                return View(model);
            }

            if (context.Customers.AsNoTracking().Any(x => x.Phone == model.Phone && x.Id != model.Id))
            {
                ModelState.AddModelError(nameof(model.Phone), "This phone number has been used before.");
                return View(model);
            }

            var existingCustomer = context.Customers.Find(id);
            if (existingCustomer is null)
                return NotFound();

            // Güncelleme
            existingCustomer.FirstName = model.FirstName;
            existingCustomer.LastName = model.LastName;
            existingCustomer.NationalId = model.NationalId;
            existingCustomer.Email = model.Email;
            existingCustomer.Phone = model.Phone;
            existingCustomer.UpdatedOn = TimeProvider.System.GetLocalNow();

            context.Update(existingCustomer);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        FluentValidatorResult.AddToModelState(this.ModelState);
        return View(model);
    }

    // -------- DELETE --------
    [HttpGet]
    public IActionResult Delete(Guid id)
    {
        var customer = context.Customers
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        if (customer is null)
            return NotFound();

        return View(customer);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(Guid id)
    {
        var customer = context.Customers.Find(id);
        if (customer is null)
            return NotFound();

        context.Customers.Remove(customer);
        context.SaveChanges();
        return RedirectToAction("Index");
    }
}
