using BugStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugStore.Infrastructure.Data.Mapping;

public class MappingCustomer  :  IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("nvarchar(120)")
            .IsRequired();
        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasColumnType("nvarchar(200)")
            .IsRequired();
        
        builder.Property(x => x.Phone)
            .HasColumnName("phone")
            .HasColumnType("nvarchar(10)")
            .IsRequired();
    }
}