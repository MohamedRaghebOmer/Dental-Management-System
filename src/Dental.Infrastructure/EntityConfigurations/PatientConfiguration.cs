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
        ConfigureIgnoredFields(builder);
    }

    private static void ConfigureIgnoredFields(EntityTypeBuilder<Patient> builder)
    {
        builder.Ignore(x => x.FullName);
        builder.Ignore(x => x.Age);
    }

    private static void AddComments(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(x => x.Gender)
            .HasComment("Male = 1, Female = 2");
    }

    private static void AddConstraints(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Patient_Gender",
                @"Gender IN (1, 2)"
            );

            table.HasCheckConstraint(
                "CK_Patient_PhoneNumberLengthEqualTo11",
                "length(PhoneNumber) = 11");
        });
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(x => x.FirstName)
            .HasConversion(
                value => value.Value,
                value => FirstName.FromDatabase(value))
            .HasColumnName(nameof(Patient.FirstName))
            .HasMaxLength(Patient.Constants.FirstNameMaxLength)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasConversion(
                value => value.Value,
                value => LastName.FromDatabase(value))
            .HasColumnName(nameof(Patient.LastName))
            .HasMaxLength(Patient.Constants.LastNameMaxLength)
            .IsRequired();

        builder.Property(x => x.DateOfBirth)
            .HasConversion(
                value => value == null ? (DateOnly?)null : value.Value,
                value => value == null ? null : DateOfBirth.FromDatabase(value.Value))
            .HasColumnName(nameof(Patient.DateOfBirth))
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

        builder.Property(x => x.Address)
            .HasColumnName(nameof(Patient.Address))
            .HasMaxLength(Patient.Constants.AddressMaxLength)
            .IsRequired(false);
    }
}