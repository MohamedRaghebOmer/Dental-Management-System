using Dental.Domain.Entities;
using Dental.Domain.Errors;
using Dental.Domain.ValueObjects;
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

        ConfigureForeignKeys(builder);
        ConfigureCheckConstraints(builder);
        ConfigureIndexes(builder);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Material> builder)
    {
        builder.HasIndex(m => m.SupplierId)
            .IsUnique(false);

        builder.HasIndex(m => m.Name)
            .IsUnique(true);

        builder.HasIndex(m => m.Quantity)
            .IsUnique(false);
    }

    private static void ConfigureCheckConstraints(EntityTypeBuilder<Material> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Material_ReorderLevel",
                "[ReorderLevel] >= 0");

            table.HasCheckConstraint(
                "CK_Material_Quantity",
                "[Quantity] >= 0");

            table.HasCheckConstraint(
                "CK_Material_BuyingPrice",
                "[BuyingPrice] >= 0");
        });
    }

    private static void ConfigureForeignKeys(EntityTypeBuilder<Material> builder)
    {
        builder.HasOne(m => m.Supplier)
            .WithMany(s => s.Materials)
            .HasForeignKey(m => m.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Material> builder)
    {
        builder.Property(m => m.Name)
            .HasColumnName(nameof(Material.Name))
            .HasMaxLength(Material.Constants.NameMaxLength)
            .IsRequired();

        builder.Property(m => m.SupplierId)
            .HasConversion(
                value => value == null? (int?)null : value.Value,
                value => value == null? null : Id.FromDatabase(value.Value))
            .HasColumnName(nameof(Material.SupplierId))
            .IsRequired(false);

        builder.Property(m => m.ReorderLevel)
            .HasColumnName(nameof(Material.ReorderLevel))
            .IsRequired();

        builder.Property(m => m.Description)
            .HasColumnName(nameof(Material.Description))
            .HasMaxLength(Material.Constants.DescriptionMaxLength)
            .IsRequired(false);

        builder.Property(m => m.Quantity)
            .HasColumnName(nameof(Material.Quantity))
            .IsRequired();

        builder.Property(m => m.BuyingPrice)
            .HasColumnName(nameof(Material.BuyingPrice))
            .HasPrecision(18, 2)
            .IsRequired();
    }
}