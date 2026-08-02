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

    private static void ConfigureCheckConstraints(EntityTypeBuilder<Visit> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Visits_DiscountAmount_NotNegative",
                "[DiscountAmount] >= 0");
        });
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Visit> builder)
    {
        builder.HasIndex(p => p.VisitDateTime)
            .HasDatabaseName("IX_Visits_VisitDateTime");

        builder.HasIndex(p => p.PatientId)
            .HasDatabaseName("IX_Visits_PatientId");
    }

    private static void ConfigureForeignKeys(EntityTypeBuilder<Visit> builder)
    {
        builder.HasOne(v => v.Appointment)
            .WithOne(a => a.Visit)
            .HasForeignKey<Visit>(v => v.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);

        builder.HasOne(v => v.Patient)
            .WithMany(p => p.Visits)
            .HasForeignKey(v => v.PatientId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Metadata
            .FindNavigation(nameof(Visit.VisitTreatments))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata
            .FindNavigation(nameof(Visit.VisitPayments))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);


        builder.HasOne(v => v.Appointment)
            .WithOne(a => a.Visit)
            .HasForeignKey<Visit>(v => new
            {
                v.AppointmentId,
                v.PatientId
            })
            .HasPrincipalKey<Appointment>(a => new
            {
                a.Id,
                a.PatientId
            })
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Visit> builder)
    {
        builder.Property(p => p.AppointmentId)
            .HasConversion(
                value => value == null ? (int?)null : value.Value,
                value => value == null ? null : Id.FromDatabase(value.Value))
            .HasColumnName(nameof(Visit.AppointmentId))
            .IsRequired(false);

        builder.Property(p => p.PatientId)
            .HasConversion(
                value => value.Value,
                value => Id.FromDatabase(value))
            .HasColumnName(nameof(Visit.PatientId))
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