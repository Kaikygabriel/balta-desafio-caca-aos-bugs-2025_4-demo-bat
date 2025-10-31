using BugStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugStore.Infrastructure.Data.Mapping;

public class MappingProduct:  IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Price)
            .HasColumnType("Money")
            .IsRequired();
        
        builder.Property(x => x.Description)
            .HasColumnType("nvarchar(120)")
            .IsRequired();
        
        builder.Property(x => x.Title)
            .HasColumnType("nvarchar(120)")
            .IsRequired();
    }
}