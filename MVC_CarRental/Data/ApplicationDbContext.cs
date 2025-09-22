using Microsoft.EntityFrameworkCore;
using MVC_CarRental.Models;
using System.Reflection;

namespace MVC_CarRental.Data;

public class ApplicationDbContext
    : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected ApplicationDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
}
