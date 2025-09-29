using Microsoft.EntityFrameworkCore;
using MVC_CarRental.Data;
using FluentValidation;
using System.Reflection;

// Create the web application builder
var builder = WebApplication.CreateBuilder(args);

// Configure Entity Framework with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));

// Register FluentValidation validators from the current assembly
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Add MVC services with views
builder.Services.AddControllersWithViews();

// Build the application
var app = builder.Build();

// Seed the database with initial data if it's empty
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await DbSeeder.SeedAsync(context);
}

// Configure the HTTP request pipeline
app.UseRouting();
app.UseStaticFiles();

// Configure default routing for MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customers}/{action=Index}/{id?}");

// Start the application
app.Run();
