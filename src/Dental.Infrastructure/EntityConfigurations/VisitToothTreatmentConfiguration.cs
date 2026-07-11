using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class VisitToothTreatmentConfiguration
    : BaseEntityConfiguration<VisitToothTreatment>
    , IEntityTypeConfiguration<VisitToothTreatment>
{
    public new void Configure(EntityTypeBuilder<VisitToothTreatment> builder)
    {
        base.Configure(builder); // Configures (Table Name, Primary Key, Properties)

        ConfigureForeignKeys(builder);
        ConfigureCheckConstraints(builder);
        ConfigureIndexes(builder);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<VisitToothTreatment> builder)
    {
        // Create a unique index on the combination of VisitId and TreatmentId
        // to ensure that a treatment can only be applied once per visit
        builder.HasIndex(x => new { x.ToothNumber, x.VisitId,  x.TreatmentId })
            .HasDatabaseName("UX_VisitToothTreatments_ToothNumber_VisitId_TreatmentId")
            .IsUnique(true);

        builder.HasIndex(x => x.ToothNumber)
            .HasDatabaseName("IX_VisitToothTreatments_ToothNumber")
            .IsUnique(false);
    }

    private static void ConfigureCheckConstraints(EntityTypeBuilder<VisitToothTreatment> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_VisitToothTreatments_ToothNumber_Range",
                "[ToothNumber] >= 1 AND [ToothNumber] <= 32");

            table.HasCheckConstraint(
                "CK_VisitToothTreatments_Price_NonNegative",
                "[Price] >= 0");
        });
    }

    private static void ConfigureForeignKeys(EntityTypeBuilder<VisitToothTreatment> builder)
    {
        builder.HasOne(x => x.Visit)
            .WithMany(x => x.VisitToothTreatments)
            .HasForeignKey(x => x.VisitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Treatment)
            .WithMany(x => x.VisitToothTreatments)
            .HasForeignKey(x => x.TreatmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<VisitToothTreatment> builder)
    {
        builder.Property(x => x.ToothNumber)
            .HasConversion(
                value => value.Value,
                value => ToothNumber.FromDatabase(value))
            .HasColumnName(nameof(VisitToothTreatment.ToothNumber))
            .IsRequired();

        builder.Property(x => x.VisitId)
            .HasConversion(
                value => value.Value,
                value => Id.FromDatabase(value))
            .HasColumnName(nameof(VisitToothTreatment.VisitId))
            .IsRequired();

        builder.Property(x => x.TreatmentId)
            .HasConversion(
                value => value.Value,
                value => Id.FromDatabase(value))
            .HasColumnName(nameof(VisitToothTreatment.TreatmentId))
            .IsRequired();

        builder.Property(x => x.Price)
            .HasConversion(
                value => value.Value,
                value => Money.FromDatabase(value))
            .HasColumnName(nameof(VisitToothTreatment.Price))
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Notes)
            .HasColumnName(nameof(VisitToothTreatment.Notes))
            .HasMaxLength(VisitToothTreatment.Constants.NotesMaxLength)
            .IsRequired(false);
    }
}
