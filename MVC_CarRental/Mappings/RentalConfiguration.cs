using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CarRental.Models;

namespace MVC_CarRental.Mappings;

public class RentalConfiguration
    : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable("Rentals", "app");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.IsDeleted)
               .IsRequired();

        builder.Property(x => x.CreatedOn)
               .IsRequired()
               .ValueGeneratedOnAdd();

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.Property(x => x.StartsDate)
               .IsRequired();

        builder.Property(x => x.EndsDate)
               .IsRequired();

        builder.Property(x => x.TotalPrice)
               .IsRequired();

        builder.HasOne(r => r.Customer)
               .WithMany(c => c.Rentals)
               .HasForeignKey(r => r.CustomerId);

        builder.HasOne(r => r.Vehicle)
               .WithMany(v => v.Rentals)
               .HasForeignKey(r => r.VehicleId);

        builder.HasOne(r => r.PickupOffice)
               .WithMany(o => o.PickupRentals)
               .HasForeignKey(r => r.PickupLocationId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(r => r.ReturnOffice)
               .WithMany(o => o.ReturnRentals)
               .HasForeignKey(r => r.ReturnLocationId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
