using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.Configurations;

public sealed class VisitConfiguration
    : BaseEntityConfiguration<Visit>
    , IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        ConfigureProperties(builder);
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

        builder.HasIndex(p => p.Date)
            .HasDatabaseName("UX_Visits_Date")
            .IsUnique(true);
    }

    private void ConfigureForeignKeys(EntityTypeBuilder<Visit> builder)
    {
        builder.HasOne(v => v.Appointment)
            .WithOne(a => a.Visit)
            .HasForeignKey<Visit>(v => v.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Visit> builder)
    {
        builder.Property(p => p.AppointmentId)
            .HasConversion(
                value => value == null ? (int?)null : value.Value,
                value => value == null ? null : Id.FromDatabase(value.Value))
            .HasColumnName(nameof(Visit.AppointmentId))
            .IsRequired(false);

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

        builder.Property(p => p.Date)
            .HasColumnName(nameof(Visit.Date))
            .IsRequired();

        builder.Property(p => p.Notes)
            .HasColumnName(nameof(Visit.Notes))
            .HasMaxLength(Visit.Constants.NotesMaxLength)
            .IsRequired(false);
    }
}