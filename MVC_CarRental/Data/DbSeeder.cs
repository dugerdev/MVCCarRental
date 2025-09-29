using Microsoft.EntityFrameworkCore;
using MVC_CarRental.Models;
using MVC_CarRental.Models.Enums;

namespace MVC_CarRental.Data;

/// <summary>
/// Database seeder for populating initial data
/// </summary>
public static class DbSeeder
{
    /// <summary>
    /// Seeds the database with initial data if it's empty
    /// </summary>
    /// <param name="context">The database context</param>
    /// <returns>Task representing the seeding operation</returns>
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // Check if data already exists
        if (context.Customers.Any())
        {
            return; // Database has been seeded
        }

        // Seed data in dependency order
        await SeedBrandsAsync(context);
        await SeedSeriesAsync(context);
        await SeedVehiclesAsync(context);
        await SeedCustomersAsync(context);
        await SeedEmployeesAsync(context);
        await SeedOfficesAsync(context);
        await SeedRentalsAsync(context);
    }

    /// <summary>
    /// Seeds brand data
    /// </summary>
    private static async Task SeedBrandsAsync(ApplicationDbContext context)
    {
        var brands = GetBrandData();
        context.Brands.AddRange(brands);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Gets brand seed data
    /// </summary>
    private static List<Brand> GetBrandData()
    {
        var currentTime = DateTimeOffset.UtcNow;
        
        return new List<Brand>
        {
            new() { Id = Guid.NewGuid(), Name = "BMW", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), Name = "Mercedes-Benz", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), Name = "Audi", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), Name = "Toyota", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), Name = "Honda", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), Name = "Ford", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), Name = "Volkswagen", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), Name = "Hyundai", CreatedOn = currentTime }
        };
    }

    /// <summary>
    /// Seeds series data
    /// </summary>
    private static async Task SeedSeriesAsync(ApplicationDbContext context)
    {
        var brands = await context.Brands.ToListAsync();
        var series = GetSeriesData(brands);
        
        context.Series.AddRange(series);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Gets series seed data
    /// </summary>
    private static List<Series> GetSeriesData(List<Brand> brands)
    {
        var currentTime = DateTimeOffset.UtcNow;
        var bmw = brands.First(b => b.Name == "BMW");
        var mercedes = brands.First(b => b.Name == "Mercedes-Benz");
        var audi = brands.First(b => b.Name == "Audi");
        var toyota = brands.First(b => b.Name == "Toyota");
        var honda = brands.First(b => b.Name == "Honda");
        var ford = brands.First(b => b.Name == "Ford");
        var volkswagen = brands.First(b => b.Name == "Volkswagen");
        var hyundai = brands.First(b => b.Name == "Hyundai");
        
        return new List<Series>
        {
            // BMW Series
            new() { Id = Guid.NewGuid(), BrandId = bmw.Id, Name = "X5", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), BrandId = bmw.Id, Name = "3 Series", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), BrandId = bmw.Id, Name = "5 Series", CreatedOn = currentTime },
            
            // Mercedes-Benz Series
            new() { Id = Guid.NewGuid(), BrandId = mercedes.Id, Name = "C-Class", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), BrandId = mercedes.Id, Name = "E-Class", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), BrandId = mercedes.Id, Name = "GLC", CreatedOn = currentTime },
            
            // Audi Series
            new() { Id = Guid.NewGuid(), BrandId = audi.Id, Name = "A4", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), BrandId = audi.Id, Name = "Q5", CreatedOn = currentTime },
            
            // Toyota Series
            new() { Id = Guid.NewGuid(), BrandId = toyota.Id, Name = "Camry", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), BrandId = toyota.Id, Name = "RAV4", CreatedOn = currentTime },
            
            // Honda Series
            new() { Id = Guid.NewGuid(), BrandId = honda.Id, Name = "Civic", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), BrandId = honda.Id, Name = "CR-V", CreatedOn = currentTime },
            
            // Ford Series
            new() { Id = Guid.NewGuid(), BrandId = ford.Id, Name = "Focus", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), BrandId = ford.Id, Name = "Explorer", CreatedOn = currentTime },
            
            // Volkswagen Series
            new() { Id = Guid.NewGuid(), BrandId = volkswagen.Id, Name = "Golf", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), BrandId = volkswagen.Id, Name = "Passat", CreatedOn = currentTime },
            
            // Hyundai Series
            new() { Id = Guid.NewGuid(), BrandId = hyundai.Id, Name = "Elantra", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), BrandId = hyundai.Id, Name = "Tucson", CreatedOn = currentTime }
        };
    }

    /// <summary>
    /// Seeds vehicle data
    /// </summary>
    private static async Task SeedVehiclesAsync(ApplicationDbContext context)
    {
        var series = await context.Series.ToListAsync();
        var vehicles = GetVehicleData(series);
        
        context.Vehicles.AddRange(vehicles);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Gets vehicle seed data
    /// </summary>
    private static List<Vehicle> GetVehicleData(List<Series> series)
    {
        var currentTime = DateTimeOffset.UtcNow;
        
        return new List<Vehicle>
        {
            // BMW Vehicles
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "X5").Id, Plate = "34 ABC 123", SeriesYear = "2023", FuelType = FuelType.Gas, GearType = true, DailyPrice = 800, CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "3 Series").Id, Plate = "06 XYZ 456", SeriesYear = "2022", FuelType = FuelType.Diesel, GearType = true, DailyPrice = 600, CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "5 Series").Id, Plate = "35 DEF 789", SeriesYear = "2023", FuelType = FuelType.Gas, GearType = false, DailyPrice = 700, CreatedOn = currentTime },
            
            // Mercedes-Benz Vehicles
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "C-Class").Id, Plate = "41 GHI 012", SeriesYear = "2022", FuelType = FuelType.Diesel, GearType = true, DailyPrice = 650, CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "E-Class").Id, Plate = "07 JKL 345", SeriesYear = "2023", FuelType = FuelType.Gas, GearType = true, DailyPrice = 750, CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "GLC").Id, Plate = "16 MNO 678", SeriesYear = "2022", FuelType = FuelType.Diesel, GearType = true, DailyPrice = 900, CreatedOn = currentTime },
            
            // Audi Vehicles
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "A4").Id, Plate = "01 PQR 901", SeriesYear = "2023", FuelType = FuelType.Gas, GearType = false, DailyPrice = 550, CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "Q5").Id, Plate = "32 STU 234", SeriesYear = "2022", FuelType = FuelType.Diesel, GearType = true, DailyPrice = 850, CreatedOn = currentTime },
            
            // Toyota Vehicles
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "Camry").Id, Plate = "06 VWX 567", SeriesYear = "2023", FuelType = FuelType.Gas, GearType = true, DailyPrice = 450, CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "RAV4").Id, Plate = "34 YZA 890", SeriesYear = "2022", FuelType = FuelType.Diesel, GearType = true, DailyPrice = 500, CreatedOn = currentTime },
            
            // Honda Vehicles
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "Civic").Id, Plate = "07 BCD 123", SeriesYear = "2023", FuelType = FuelType.Gas, GearType = false, DailyPrice = 400, CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "CR-V").Id, Plate = "16 EFG 456", SeriesYear = "2022", FuelType = FuelType.Diesel, GearType = true, DailyPrice = 480, CreatedOn = currentTime },
            
            // Ford Vehicles
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "Focus").Id, Plate = "41 HIJ 789", SeriesYear = "2023", FuelType = FuelType.Gas, GearType = false, DailyPrice = 380, CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "Explorer").Id, Plate = "01 KLM 012", SeriesYear = "2022", FuelType = FuelType.Diesel, GearType = true, DailyPrice = 520, CreatedOn = currentTime },
            
            // Volkswagen Vehicles
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "Golf").Id, Plate = "32 NOP 345", SeriesYear = "2023", FuelType = FuelType.Gas, GearType = false, DailyPrice = 420, CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "Passat").Id, Plate = "06 QRS 678", SeriesYear = "2022", FuelType = FuelType.Diesel, GearType = true, DailyPrice = 580, CreatedOn = currentTime },
            
            // Hyundai Vehicles
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "Elantra").Id, Plate = "34 TUV 901", SeriesYear = "2023", FuelType = FuelType.Gas, GearType = true, DailyPrice = 350, CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), SeriesId = series.First(s => s.Name == "Tucson").Id, Plate = "07 WXY 234", SeriesYear = "2022", FuelType = FuelType.Diesel, GearType = true, DailyPrice = 460, CreatedOn = currentTime }
        };
    }

    /// <summary>
    /// Seeds customer data
    /// </summary>
    private static async Task SeedCustomersAsync(ApplicationDbContext context)
    {
        var customers = GetCustomerData();
        context.Customers.AddRange(customers);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Gets customer seed data
    /// </summary>
    private static List<Customer> GetCustomerData()
    {
        var currentTime = DateTimeOffset.UtcNow;
        
        return new List<Customer>
        {
            new() { Id = Guid.NewGuid(), FirstName = "Ahmet", LastName = "Yılmaz", NationalId = "12345678901", Email = "ahmet.yilmaz@email.com", Phone = "+90 532 123 4567", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Fatma", LastName = "Demir", NationalId = "12345678902", Email = "fatma.demir@email.com", Phone = "+90 533 234 5678", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Mehmet", LastName = "Kaya", NationalId = "12345678903", Email = "mehmet.kaya@email.com", Phone = "+90 534 345 6789", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Ayşe", LastName = "Çelik", NationalId = "12345678904", Email = "ayse.celik@email.com", Phone = "+90 535 456 7890", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Ali", LastName = "Öztürk", NationalId = "12345678905", Email = "ali.ozturk@email.com", Phone = "+90 536 567 8901", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Zeynep", LastName = "Şahin", NationalId = "12345678906", Email = "zeynep.sahin@email.com", Phone = "+90 537 678 9012", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Mustafa", LastName = "Arslan", NationalId = "12345678907", Email = "mustafa.arslan@email.com", Phone = "+90 538 789 0123", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Elif", LastName = "Doğan", NationalId = "12345678908", Email = "elif.dogan@email.com", Phone = "+90 539 890 1234", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Okan", LastName = "Polat", NationalId = "12345678909", Email = "okan.polat@email.com", Phone = "+90 540 901 2345", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Selin", LastName = "Yıldız", NationalId = "12345678910", Email = "selin.yildiz@email.com", Phone = "+90 541 012 3456", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Burak", LastName = "Koç", NationalId = "12345678911", Email = "burak.koc@email.com", Phone = "+90 542 123 4567", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Ceren", LastName = "Aydın", NationalId = "12345678912", Email = "ceren.aydin@email.com", Phone = "+90 543 234 5678", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Emre", LastName = "Taş", NationalId = "12345678913", Email = "emre.tas@email.com", Phone = "+90 544 345 6789", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Gizem", LastName = "Kurt", NationalId = "12345678914", Email = "gizem.kurt@email.com", Phone = "+90 545 456 7890", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Deniz", LastName = "Akar", NationalId = "12345678915", Email = "deniz.akar@email.com", Phone = "+90 546 567 8901", CreatedOn = currentTime }
        };
    }

    /// <summary>
    /// Seeds employee data
    /// </summary>
    private static async Task SeedEmployeesAsync(ApplicationDbContext context)
    {
        var employees = GetEmployeeData();
        context.Employees.AddRange(employees);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Gets employee seed data
    /// </summary>
    private static List<Employee> GetEmployeeData()
    {
        var currentTime = DateTimeOffset.UtcNow;
        
        return new List<Employee>
        {
            new() { Id = Guid.NewGuid(), FirstName = "Murat", LastName = "Güneş", NationalId = "98765432101", Email = "murat.gunes@carrental.com", Phone = "+90 532 111 2233", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Serap", LastName = "Bulut", NationalId = "98765432102", Email = "serap.bulut@carrental.com", Phone = "+90 533 222 3344", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Kemal", LastName = "Özkan", NationalId = "98765432103", Email = "kemal.ozkan@carrental.com", Phone = "+90 534 333 4455", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Leyla", LastName = "Aktaş", NationalId = "98765432104", Email = "leyla.aktas@carrental.com", Phone = "+90 535 444 5566", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), FirstName = "Tolga", LastName = "Yılmaz", NationalId = "98765432105", Email = "tolga.yilmaz@carrental.com", Phone = "+90 536 555 6677", CreatedOn = currentTime }
        };
    }

    /// <summary>
    /// Seeds office data
    /// </summary>
    private static async Task SeedOfficesAsync(ApplicationDbContext context)
    {
        var employees = await context.Employees.ToListAsync();
        var offices = GetOfficeData(employees);
        
        context.Offices.AddRange(offices);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Gets office seed data
    /// </summary>
    private static List<Office> GetOfficeData(List<Employee> employees)
    {
        var currentTime = DateTimeOffset.UtcNow;
        
        return new List<Office>
        {
            new() { Id = Guid.NewGuid(), EmployeeId = employees[0].Id, Name = "İstanbul Merkez Şube", Email = "istanbul@carrental.com", Phone = "+90 212 123 4567", Address = "Beşiktaş, İstanbul", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), EmployeeId = employees[1].Id, Name = "Ankara Şubesi", Email = "ankara@carrental.com", Phone = "+90 312 234 5678", Address = "Çankaya, Ankara", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), EmployeeId = employees[2].Id, Name = "İzmir Şubesi", Email = "izmir@carrental.com", Phone = "+90 232 345 6789", Address = "Konak, İzmir", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), EmployeeId = employees[3].Id, Name = "Bursa Şubesi", Email = "bursa@carrental.com", Phone = "+90 224 456 7890", Address = "Osmangazi, Bursa", CreatedOn = currentTime },
            new() { Id = Guid.NewGuid(), EmployeeId = employees[4].Id, Name = "Antalya Şubesi", Email = "antalya@carrental.com", Phone = "+90 242 567 8901", Address = "Muratpaşa, Antalya", CreatedOn = currentTime }
        };
    }

    /// <summary>
    /// Seeds rental data
    /// </summary>
    private static async Task SeedRentalsAsync(ApplicationDbContext context)
    {
        var customers = await context.Customers.Take(8).ToListAsync();
        var vehicles = await context.Vehicles.Take(8).ToListAsync();
        var offices = await context.Offices.ToListAsync();
        
        var rentals = GetRentalData(customers, vehicles, offices);
        
        context.Rentals.AddRange(rentals);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Gets rental seed data
    /// </summary>
    private static List<Rental> GetRentalData(List<Customer> customers, List<Vehicle> vehicles, List<Office> offices)
    {
        var currentTime = DateTimeOffset.UtcNow;
        
        return new List<Rental>
        {
            new() 
            { 
                Id = Guid.NewGuid(), 
                CustomerId = customers[0].Id, 
                VehicleId = vehicles[0].Id, 
                StartsDate = currentTime.AddDays(-10), 
                EndsDate = currentTime.AddDays(-5), 
                TotalPrice = 4000, 
                PickupLocationId = offices[0].Id, 
                ReturnLocationId = offices[0].Id,
                CreatedOn = currentTime 
            },
            new() 
            { 
                Id = Guid.NewGuid(), 
                CustomerId = customers[1].Id, 
                VehicleId = vehicles[1].Id, 
                StartsDate = currentTime.AddDays(-7), 
                EndsDate = currentTime.AddDays(-2), 
                TotalPrice = 3000, 
                PickupLocationId = offices[1].Id, 
                ReturnLocationId = offices[1].Id,
                CreatedOn = currentTime 
            },
            new() 
            { 
                Id = Guid.NewGuid(), 
                CustomerId = customers[2].Id, 
                VehicleId = vehicles[2].Id, 
                StartsDate = currentTime.AddDays(-3), 
                EndsDate = currentTime.AddDays(2), 
                TotalPrice = 3500, 
                PickupLocationId = offices[2].Id, 
                ReturnLocationId = offices[2].Id,
                CreatedOn = currentTime 
            },
            new() 
            { 
                Id = Guid.NewGuid(), 
                CustomerId = customers[3].Id, 
                VehicleId = vehicles[3].Id, 
                StartsDate = currentTime.AddDays(-1), 
                EndsDate = currentTime.AddDays(4), 
                TotalPrice = 3250, 
                PickupLocationId = offices[3].Id, 
                ReturnLocationId = offices[4].Id,
                CreatedOn = currentTime 
            },
            new() 
            { 
                Id = Guid.NewGuid(), 
                CustomerId = customers[4].Id, 
                VehicleId = vehicles[4].Id, 
                StartsDate = currentTime.AddDays(1), 
                EndsDate = currentTime.AddDays(6), 
                TotalPrice = 3750, 
                PickupLocationId = offices[0].Id, 
                ReturnLocationId = offices[1].Id,
                CreatedOn = currentTime 
            },
            new() 
            { 
                Id = Guid.NewGuid(), 
                CustomerId = customers[5].Id, 
                VehicleId = vehicles[5].Id, 
                StartsDate = currentTime.AddDays(2), 
                EndsDate = currentTime.AddDays(7), 
                TotalPrice = 4500, 
                PickupLocationId = offices[1].Id, 
                ReturnLocationId = offices[2].Id,
                CreatedOn = currentTime 
            },
            new() 
            { 
                Id = Guid.NewGuid(), 
                CustomerId = customers[6].Id, 
                VehicleId = vehicles[6].Id, 
                StartsDate = currentTime.AddDays(3), 
                EndsDate = currentTime.AddDays(8), 
                TotalPrice = 2750, 
                PickupLocationId = offices[2].Id, 
                ReturnLocationId = offices[3].Id,
                CreatedOn = currentTime 
            },
            new() 
            { 
                Id = Guid.NewGuid(), 
                CustomerId = customers[7].Id, 
                VehicleId = vehicles[7].Id, 
                StartsDate = currentTime.AddDays(5), 
                EndsDate = currentTime.AddDays(10), 
                TotalPrice = 4250, 
                PickupLocationId = offices[3].Id, 
                ReturnLocationId = offices[4].Id,
                CreatedOn = currentTime 
            }
        };
    }
}