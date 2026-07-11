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
    }

    private void ConfigureForeignKeys(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasOne(p => p.Patient)
            .WithMany(p => p.Prescriptions)
            .HasForeignKey(p => p.PatientId);

        builder.HasOne(p => p.Visit)
            .WithMany(v => v.Prescriptions)
            .HasForeignKey(p => p.VisitId);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Prescription> builder)
    {
        builder.Property(p => p.PatientId)
            .HasConversion(
                value => value.Value,
                value => Id.FromDatabase(value))
            .HasColumnName(nameof(Prescription.PatientId))
            .IsRequired();

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