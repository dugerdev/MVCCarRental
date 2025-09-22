using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CarRental.Models;

namespace MVC_CarRental.Mappings;

public class SeriesConfiguration
    : IEntityTypeConfiguration<Series>
{
    public void Configure(EntityTypeBuilder<Series> builder)
    {
        builder.ToTable("Series", "app");

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

        builder.HasOne(s => s.Brand)
               .WithMany(b => b.Series)
               .HasForeignKey(s => s.BrandId);
    }
}
