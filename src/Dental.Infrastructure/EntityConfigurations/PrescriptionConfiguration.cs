using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class PrescriptionConfiguration
    : BaseEntityConfiguration<Prescription>
    , IEntityTypeConfiguration<Prescription>
{
    public new void Configure(EntityTypeBuilder<Prescription> builder)
    {
        base.Configure(builder); // Configures (Table Name, Primary Key, Properties)
        ConfigureForeignKeys(builder);
        ConfigureIndexes(builder);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasIndex(p => p.VisitId)
            .HasDatabaseName("UX_Prescriptions_VisitId")
            .IsUnique();

        builder.HasIndex(p => p.PatientId)
            .HasDatabaseName("IX_Prescriptions_PatientId")
            .IsUnique(false);
    }

    private void ConfigureForeignKeys(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasOne(pr => pr.Patient)
             .WithMany(p => p.Prescriptions)
             .HasForeignKey(pr => pr.PatientId)
             .IsRequired(false)
             .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pr => pr.Visit)
             .WithOne(p => p.Prescription)
             .HasForeignKey<Prescription>(pr => pr.VisitId)
             .IsRequired()
             .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Prescription> builder)
    {
        builder.Property(p => p.PatientId)
            .HasConversion(
                value => value == null ? (int?)null : value.Value,
                value => value == null ? null : Id.FromDatabase(value.Value))
            .HasColumnName(nameof(Prescription.PatientId))
            .IsRequired(false);

        builder.Property(p => p.VisitId)
            .HasConversion(
                value => value.Value,
                value => Id.FromDatabase(value))
            .HasColumnName(nameof(Prescription.VisitId))
            .IsRequired();

        builder.Property(p => p.Notes)
            .HasColumnName(nameof(Prescription.Notes))
            .HasMaxLength(Prescription.Constants.NotesMaxLength)
            .IsRequired(false);
    }
}