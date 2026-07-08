using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.Persistence.Configurations;

public sealed class AppointmentConfiguration
        : ConfigurationBase<Appointment>
        , IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        ConfigureProperties(builder);
        ConfigureForeignKeys(builder);
        ConfigureIndexes(builder);
        AddColumnsComments(builder);
    }

    private void ConfigureIndexes(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasIndex(p => p.PatientId)
            .HasDatabaseName("IX_Appointment_PatientId")
            .IsUnique(false);
    }

    private static void AddColumnsComments(EntityTypeBuilder<Appointment> builder)
    {
        builder.Property(p => p.Status)
            .HasComment("Pending = 1, Canceled = 2, Completed = 3, Missed = 4");
    }

    private static void ConfigureForeignKeys(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Appointment> builder)
    {
        builder.Property(p => p.PatientId)
            .HasConversion(
                value => value.Value,
                value => Id.FromDatabase(value))
            .HasColumnName(nameof(Appointment.PatientId))
            .IsRequired();

        builder.Property(p => p.AppointmentDate)
            .HasColumnName(nameof(Appointment.AppointmentDate))
            .IsRequired();

        builder.Property(p => p.CompletedAt)
            .HasColumnName(nameof(Appointment.CompletedAt))
            .IsRequired(false)
            .HasDefaultValue(null);

        builder.Property(p => p.Status)
            .HasConversion<byte>()
            .HasColumnType("TINYINT")
            .HasColumnName(nameof(Appointment.Status));

        builder.Property(p => p.Notes)
            .HasColumnName(nameof(Appointment.Notes))
            .HasMaxLength(Appointment.Constants.NotesMaxLength)
            .IsRequired(false);
    }
}