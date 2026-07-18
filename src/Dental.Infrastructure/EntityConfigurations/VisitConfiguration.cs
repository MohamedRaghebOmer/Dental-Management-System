using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class VisitConfiguration
    : BaseEntityConfiguration<Visit>
    , IEntityTypeConfiguration<Visit>
{
    public new void Configure(EntityTypeBuilder<Visit> builder)
    {
        base.Configure(builder); // Configures (Table Name, Primary Key, Properties)

        ConfigureForeignKeys(builder);
        ConfigureCheckConstraints(builder);
        ConfigureIndexes(builder);
    }

    private void ConfigureCheckConstraints(EntityTypeBuilder<Visit> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Visits_DiscountAmount_NotNegative",
                "[DiscountAmount] >= 0");

            table.HasCheckConstraint(
                "CK_Visits_PaidAmount_NotNegative",
                "[PaidAmount] >= 0");
        });
    }

    private void ConfigureIndexes(EntityTypeBuilder<Visit> builder)
    {
        builder.HasIndex(p => p.AppointmentId)
            .HasDatabaseName("UX_Visits_AppointmentId")
            .HasFilter("[AppointmentId] IS NOT NULL")
            .IsUnique(true);

        builder.HasIndex(p => p.VisitDateTime)
            .HasDatabaseName("UX_Visits_VisitDateTime")
            .IsUnique(true);

        builder.HasIndex(p => p.PatientName)
            .HasDatabaseName("UX_Visits_PatientName");
    }

    private void ConfigureForeignKeys(EntityTypeBuilder<Visit> builder)
    {
        builder.HasOne(v => v.Appointment)
            .WithOne(a => a.Visit)
            .HasForeignKey<Visit>(v => v.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        builder.Metadata
            .FindNavigation(nameof(Visit.VisitTreatments))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Visit> builder)
    {
        builder.Property(p => p.AppointmentId)
            .HasConversion(
                value => value == null ? (int?)null : value.Value,
                value => value == null ? null : Id.FromDatabase(value.Value))
            .HasColumnName(nameof(Visit.AppointmentId))
            .IsRequired(false);

        builder.Property(p => p.PatientName)
            .HasColumnName(nameof(Visit.PatientName))
            .HasMaxLength(Visit.Constants.PatientNameMaxLength);

        builder.Property((p => p.PaidAmount))
            .HasConversion(
                value => value.Value,
                value => Money.FromDatabase(value))
            .HasColumnName(nameof(Visit.PaidAmount))
            .IsRequired();

        builder.Property((p => p.DiscountAmount))
            .HasConversion(
                value => value.Value,
                value => Money.FromDatabase(value))
            .HasColumnName(nameof(Visit.DiscountAmount))
            .IsRequired();

        builder.Property(p => p.VisitDateTime)
            .HasColumnName(nameof(Visit.VisitDateTime))
            .IsRequired();

        builder.Property(p => p.Notes)
            .HasColumnName(nameof(Visit.Notes))
            .HasMaxLength(Visit.Constants.NotesMaxLength)
            .IsRequired(false);
    }
}