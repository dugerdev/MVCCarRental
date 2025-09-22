using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CarRental.Models;

namespace MVC_CarRental.Mappings;

public class VehicleConfiguration
    : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles", "app");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.IsDeleted)
               .IsRequired();

        builder.Property(x => x.CreatedOn)
               .IsRequired()
               .ValueGeneratedOnAdd();

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.Property(x => x.Plate)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(x => x.Plate)
               .IsUnique();

        builder.Property(x => x.SeriesYear)
               .IsRequired()
               .HasMaxLength(4)
               .HasColumnType("char");

        builder.Property(x => x.FuelType)
               .IsRequired();

        builder.Property(x => x.GearType)
               .IsRequired();

        builder.Ignore(x => x.GearTypeName);

        builder.Property(x => x.DailyPrice)
               .IsRequired();

        builder.HasOne(v => v.Series)
               .WithMany(s => s.Vehicles)
               .HasForeignKey(v => v.SeriesId);
    }
}
