using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CarRental.Models;

namespace MVC_CarRental.Mappings;

public class OfficeConfiguration
    : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        builder.ToTable("Offices", "app");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.IsDeleted)
               .IsRequired();

        builder.Property(x => x.CreatedOn)
               .IsRequired()
               .ValueGeneratedOnAdd();

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(255);

        builder.HasIndex(x => x.Name)
               .IsUnique();

        builder.Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(255);

        builder.HasIndex(x => x.Email)
               .IsUnique();

        builder.Property(x => x.Phone)
               .IsRequired()
               .HasMaxLength(20);

        builder.HasIndex(x => x.Phone)
               .IsUnique();

        builder.Property(x => x.Address)
               .IsRequired()
               .HasMaxLength(500);

        builder.HasOne(o => o.Employee)
               .WithMany(e => e.Offices)
               .HasForeignKey(o => o.EmployeeId);
    }
}
