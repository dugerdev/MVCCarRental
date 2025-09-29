using Microsoft.EntityFrameworkCore;
using MVC_CarRental.Models;
using System.Reflection;

namespace MVC_CarRental.Data;

/// <summary>
/// Entity Framework DbContext for the Car Rental application
/// Manages database operations and entity configurations
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the ApplicationDbContext
    /// </summary>
    /// <param name="options">Database context options</param>
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    /// Parameterless constructor for design-time scenarios
    /// </summary>
    protected ApplicationDbContext()
    {
    }

    #region DbSets

    /// <summary>
    /// DbSet for Brand entities - represents car manufacturers
    /// </summary>
    public DbSet<Brand> Brands { get; set; }

    /// <summary>
    /// DbSet for Customer entities - represents rental customers
    /// </summary>
    public DbSet<Customer> Customers { get; set; }

    /// <summary>
    /// DbSet for Employee entities - represents staff members
    /// </summary>
    public DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// DbSet for Office entities - represents branch locations
    /// </summary>
    public DbSet<Office> Offices { get; set; }

    /// <summary>
    /// DbSet for Rental entities - represents rental transactions
    /// </summary>
    public DbSet<Rental> Rentals { get; set; }

    /// <summary>
    /// DbSet for Series entities - represents vehicle model series
    /// </summary>
    public DbSet<Series> Series { get; set; }

    /// <summary>
    /// DbSet for Vehicle entities - represents individual cars
    /// </summary>
    public DbSet<Vehicle> Vehicles { get; set; }

    #endregion

    /// <summary>
    /// Configures the model for Entity Framework
    /// Applies all configurations from the current assembly
    /// </summary>
    /// <param name="modelBuilder">Model builder instance</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all entity configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
