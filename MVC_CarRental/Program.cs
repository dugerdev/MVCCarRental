using Microsoft.EntityFrameworkCore;
using MVC_CarRental.Data;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddControllersWithViews();



var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Customers}/{action=Index}/{id?}"
    );




app.Run();
