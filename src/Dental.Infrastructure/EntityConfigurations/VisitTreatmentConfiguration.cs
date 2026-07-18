using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class VisitTreatmentConfiguration
    : BaseEntityConfiguration<VisitTreatment>
    , IEntityTypeConfiguration<VisitTreatment>
{
    public new void Configure(EntityTypeBuilder<VisitTreatment> builder)
    {
        base.Configure(builder); // Configures (Table Name, Primary Key, Properties)

        ConfigureForeignKeys(builder);
        ConfigureCheckConstraints(builder);
        ConfigureIndexes(builder);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<VisitTreatment> builder)
    {
        // Create a unique index on the combination of VisitId and TreatmentId
        // to ensure that a treatment can only be applied once per visit
        builder.HasIndex(vt => new { vt.ToothNumber, vt.VisitId, vt.TreatmentId })
            .HasDatabaseName("UX_VisitTreatments_ToothNumber_VisitId_TreatmentId")
            .IsUnique(true);

        builder.HasIndex(vt => vt.VisitId)
            .HasDatabaseName("IX_VisitTreatments_VisitId");
    }

    private static void ConfigureCheckConstraints(EntityTypeBuilder<VisitTreatment> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_VisitTreatments_ToothNumber_Range",
                "[ToothNumber] >= 1 AND [ToothNumber] <= 32");

            table.HasCheckConstraint(
                "CK_VisitTreatments_Price_NonNegative",
                "[Price] >= 0");
        });
    }

    private static void ConfigureForeignKeys(EntityTypeBuilder<VisitTreatment> builder)
    {
        builder.HasOne(vt => vt.Visit)
            .WithMany(v => v.VisitTreatments)
            .HasForeignKey(vt => vt.VisitId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(vt => vt.Treatment)
            .WithMany(t => t.VisitTreatments)
            .HasForeignKey(vt => vt.TreatmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<VisitTreatment> builder)
    {
        builder.Property(vt => vt.ToothNumber)
            .HasConversion(
                value => value.Value,
                value => ToothNumber.FromDatabase(value))
            .HasColumnName(nameof(VisitTreatment.ToothNumber))
            .IsRequired();

        builder.Property(vt => vt.VisitId)
            .HasConversion(
                value => value.Value,
                value => Id.FromDatabase(value))
            .HasColumnName(nameof(VisitTreatment.VisitId))
            .IsRequired();

        builder.Property(vt => vt.TreatmentId)
            .HasConversion(
                value => value.Value,
                value => Id.FromDatabase(value))
            .HasColumnName(nameof(VisitTreatment.TreatmentId))
            .IsRequired();

        builder.Property(vt => vt.Price)
            .HasConversion(
                value => value.Value,
                value => Money.FromDatabase(value))
            .HasColumnName(nameof(VisitTreatment.Price))
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(vt => vt.Notes)
            .HasColumnName(nameof(VisitTreatment.Notes))
            .HasMaxLength(VisitTreatment.Constants.NotesMaxLength)
            .IsRequired(false);
    }
}
