using Dental.Domain.Entities;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class MaterialConfiguration
    : BaseEntityConfiguration<Material>
    , IEntityTypeConfiguration<Material>
{
    public new void Configure(EntityTypeBuilder<Material> builder)
    {
        base.Configure(builder); // Configures (Table Name, Primary Key, Properties)

        ConfigureCheckConstraints(builder);
        ConfigureIndexes(builder);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Material> builder)
    {
        builder.HasIndex(m => m.Name)
            .HasDatabaseName("IX_Materials_Name")
            .IsUnique(true);

        builder.HasIndex(m => m.Quantity)
            .HasDatabaseName("IX_Materials_Quantity")
            .IsUnique(false);

        builder.HasIndex(m => m.ReorderLevel)
            .HasDatabaseName("IX_Materials_ReorderLevel")
            .IsUnique(false);
    }

    private static void ConfigureCheckConstraints(EntityTypeBuilder<Material> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Materials_ReorderLevel",
                "[ReorderLevel] >= 0");

            table.HasCheckConstraint(
                "CK_Materials_Quantity",
                "[Quantity] >= 0");

            table.HasCheckConstraint(
                "CK_Materials_Price",
                "[Price] >= 0");
        });
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Material> builder)
    {
        builder.Property(m => m.Name)
            .HasColumnName(nameof(Material.Name))
            .HasMaxLength(Material.Constants.NameMaxLength)
            .IsRequired();

        builder.Property(m => m.Quantity)
            .HasColumnName(nameof(Material.Quantity))
            .IsRequired();

        builder.Property(m => m.ReorderLevel)
            .HasColumnName(nameof(Material.ReorderLevel))
            .IsRequired();

        builder.Ignore(m => m.Status);

        builder.Property(m => m.Price)
            .HasColumnName(nameof(Material.Price))
            .HasPrecision(18, 2)
            .IsRequired();
    }
}