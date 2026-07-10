using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class SupplierConfiguration
    : BaseEntityConfiguration<Supplier>
    , IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Supplier> builder)
    {
        builder.Property(s => s.Name)
            .HasColumnName(nameof(Supplier.Name))
            .HasMaxLength(Supplier.Constants.NameMaxLength)
            .IsRequired();

        builder.Property(s => s.PhoneNumber)
            .HasConversion(
                value => value == null ? null : value.Value,
                value => value == null ? null : PhoneNumber.FromDatabase(value))
            .HasColumnName(nameof(Supplier.PhoneNumber))
            .HasMaxLength(Supplier.Constants.PhoneNumberMaxLength)
            .IsRequired(false);

        builder.Property(s => s.Address)
            .HasColumnName(nameof(Supplier.Address))
            .HasMaxLength(Supplier.Constants.AddressMaxLength)
            .IsRequired(false);

        builder.Property(s => s.Description)
            .HasColumnName(nameof(Supplier.Description))
            .HasMaxLength(Supplier.Constants.DescriptionMaxLength)
            .IsRequired(false);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasIndex(s => s.Name)
            .HasDatabaseName("UX_Supplier_Name")
            .IsUnique();

        builder.HasIndex(s => s.PhoneNumber)
            .HasDatabaseName("UX_Supplier_PhoneNumber")
            .HasFilter("[PhoneNumber] IS NOT NULL")
            .IsUnique();
    }
}