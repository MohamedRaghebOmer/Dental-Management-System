using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class PrescriptionItemsConfiguration
    : BaseEntityConfiguration<PrescriptionItem>
    , IEntityTypeConfiguration<PrescriptionItem>
{
    public new void Configure(EntityTypeBuilder<PrescriptionItem> builder)
    {
        base.Configure(builder); // Configures (Table Name, Primary Key, Properties)

        ConfigureForeignKeys(builder);
        ConfigureCheckConstraints(builder);
        ConfigureIndexes(builder);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<PrescriptionItem> builder)
    {
        builder.HasIndex(p => p.PrescriptionId)
            .HasDatabaseName("IX_PrescriptionItems_PrescriptionId")
            .IsUnique(false);
    }

    private static void ConfigureCheckConstraints(EntityTypeBuilder<PrescriptionItem> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_PrescriptionItems_Dosage",
                "[Dosage] > 0");

            table.HasCheckConstraint(
                "CK_PrescriptionItems_Period",
                "[Period] BETWEEN 1 AND 3");
        });
    }

    private static void ConfigureForeignKeys(EntityTypeBuilder<PrescriptionItem> builder)
    {
        builder.HasOne(p => p.Prescription)
            .WithMany(pr => pr.PrescriptionItems)
            .HasForeignKey(p => p.PrescriptionId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<PrescriptionItem> builder)
    {
        builder.Property(p => p.PrescriptionId)
            .HasConversion(
                value => value.Value,
                value => Id.FromDatabase(value))
            .HasColumnName(nameof(PrescriptionItem.PrescriptionId))
            .IsRequired();

        builder.Property(p => p.MedicineName)
            .HasColumnName(nameof(PrescriptionItem.MedicineName))
            .HasMaxLength(PrescriptionItem.Constants.MedicineNameMaxLength)
            .IsRequired();

        builder.Property(p => p.Dosage)
            .HasColumnName(nameof(PrescriptionItem.Dosage))
            .IsRequired();

        builder.OwnsOne(p => p.MedicineFrequency, frequencyBuilder =>
        {
            frequencyBuilder.Property(f => f.Value)
                .HasColumnName(nameof(PrescriptionItem.MedicineFrequency))
                .IsRequired();

            frequencyBuilder.Property(p => p.Period)
                .HasColumnName(nameof(PrescriptionItem.MedicineFrequency.Period))
                .HasConversion<byte>()
                .IsRequired();
        });

        builder.Property(p => p.Instructions)
            .HasColumnName(nameof(PrescriptionItem.Instructions))
            .HasMaxLength(PrescriptionItem.Constants.InstructionsMaxLength)
            .IsRequired(false);
    }
}