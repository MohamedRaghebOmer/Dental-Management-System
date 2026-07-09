using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.Configurations;

public sealed class ServiceConfiguration
    : BaseEntityConfiguration<Service>
    , IEntityTypeConfiguration<Service>

{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        ConfigureProperties(builder);
        AddCheckConstraints(builder);
        ConfigureIndexes(builder);
    }

    private void AddCheckConstraints(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Services_Price",
                @"Price >= 0"
            );
        });
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Service> builder)
    {
        builder.Property(x => x.Name)
            .HasColumnName(nameof(Service.Name))
            .HasMaxLength(Service.Constants.NameMaxLength)
            .IsRequired();

        builder.Property(x => x.Price)
            .HasConversion(
                x => x.Value,
                x => Money.FromDatabase(x))
            .HasColumnName(nameof(Service.Price))
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName(nameof(Service.Description))
            .HasMaxLength(Service.Constants.DescriptionMaxLength)
            .IsRequired(false);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Service> builder)
    {
        builder.HasIndex(x => x.Name)
            .HasDatabaseName("UX_Services_Name")
            .IsUnique();
    }
}