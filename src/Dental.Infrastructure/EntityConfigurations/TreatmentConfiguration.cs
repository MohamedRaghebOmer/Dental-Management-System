using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class TreatmentConfiguration
    : BaseEntityConfiguration<Treatment>
    , IEntityTypeConfiguration<Treatment>

{
    public new void Configure(EntityTypeBuilder<Treatment> builder)
    {
        base.Configure(builder); // Configures (Table Name, Primary Key, Properties)

        AddCheckConstraints(builder);
        ConfigureIndexes(builder);
        AddInitialData(builder);
    }

    private void AddInitialData(EntityTypeBuilder<Treatment> builder)
    {
        builder.HasData(Treatment.InitialData());
    }

    private void AddCheckConstraints(EntityTypeBuilder<Treatment> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Treatments_Price",
                @"Price >= 0"
            );
        });
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Treatment> builder)
    {
        builder.Property(x => x.Name)
            .HasColumnName(nameof(Treatment.Name))
            .HasMaxLength(Treatment.Constants.NameMaxLength)
            .IsRequired();

        builder.Property(x => x.Price)
            .HasConversion(
                x => x.Value,
                x => Money.FromDatabase(x))
            .HasColumnName(nameof(Treatment.Price))
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName(nameof(Treatment.Description))
            .HasMaxLength(Treatment.Constants.DescriptionMaxLength)
            .IsRequired(false);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Treatment> builder)
    {
        builder.HasIndex(x => x.Name)
            .HasDatabaseName("UX_Treatments_Name")
            .IsUnique();
    }
}