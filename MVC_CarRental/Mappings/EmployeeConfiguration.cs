using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CarRental.Models;

namespace MVC_CarRental.Mappings;

public class EmployeeConfiguration
    : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees", "app");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.IsDeleted)
               .IsRequired();

        builder.Property(x => x.CreatedOn)
               .IsRequired()
               .ValueGeneratedOnAdd();

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.Property(x => x.FirstName)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(x => x.LastName)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(x => x.NationalId)
               .IsRequired()
               .HasMaxLength(11)
               .HasColumnType("char");

        builder.HasIndex(x => x.NationalId)
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
    }
}
