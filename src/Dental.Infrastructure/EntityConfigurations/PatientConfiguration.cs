using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class PatientConfiguration
    : BaseEntityConfiguration<Patient>
    , IEntityTypeConfiguration<Patient>
{
    public new void Configure(EntityTypeBuilder<Patient> builder)
    {
        base.Configure(builder); // Configures (Table Name, Primary Key, Properties)

        AddConstraints(builder);
        AddComments(builder);
        ConfigureIndexes(builder);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Patient> builder)
    {
        builder.HasIndex(p => p.Name)
            .HasDatabaseName("UX_Patients_Name")
            .IsUnique();
    }

    private static void AddComments(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(x => x.Gender)
            .HasComment("Male = 0, Female = 1");
    }

    private static void AddConstraints(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Patients_Gender",
                @"Gender IN (0, 1)"
            );

            table.HasCheckConstraint(
                "CK_Patients_PhoneNumberLength",
                $"length(PhoneNumber) = {Patient.Constants.PhoneNumberLength}");

            table.HasCheckConstraint(
                "CK_Patients_AgeRange",
                $"[Age] IS NULL OR [Age] BETWEEN {Patient.Constants.MinimumAllowedAge} AND {Patient.Constants.MaximumAllowedAge}"
            );
        });
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(p => p.Name)
            .HasColumnName(nameof(Patient.Name))
            .HasMaxLength(Patient.Constants.NameMaxLength)
            .IsRequired();

        builder.Property(p => p.Age)
            .HasColumnName(nameof(Patient.Age))
            .HasDefaultValue(null)
            .IsRequired(false);

        builder.Property(x => x.Gender)
            .HasConversion<byte>()
            .HasColumnType("TINYINT")
            .HasColumnName(nameof(Patient.Gender))
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasConversion(
                value => value == null ? null : value.Value,
                value => value == null ? null : PhoneNumber.FromDatabase(value))
            .HasColumnName(nameof(Patient.PhoneNumber))
            .HasMaxLength(Patient.Constants.PhoneNumberLength)
            .IsRequired(false);
    }
}