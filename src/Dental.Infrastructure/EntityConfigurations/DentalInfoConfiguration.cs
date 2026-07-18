using Dental.Domain.Entities;
using Dental.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class DentalInfoConfiguration
    : IEntityTypeConfiguration<DentalInfo>
{
    public void Configure(EntityTypeBuilder<DentalInfo> builder)
    {
        builder.ToTable(nameof(DentalInfo));
        builder.ConfigurePrimaryKey();

        ConfigureProperties(builder);
        InsertInitialData(builder);
        AddCheckConstraint(builder);
    }

    private static void AddCheckConstraint(EntityTypeBuilder<DentalInfo> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_DentalInfo_OnlyOneRecord",
                "[Id] = 1");
        });
    }

    private static void InsertInitialData(EntityTypeBuilder<DentalInfo> builder)
    {
        builder.HasData(DentalInfo.CreateDefault());
    }

    private static void ConfigureProperties(EntityTypeBuilder<DentalInfo> builder)
    {
        builder.Property(d => d.DoctorName)
            .HasColumnName(nameof(DentalInfo.DoctorName))
            .HasMaxLength(DentalInfo.Constants.DoctorNameMaxLength);

        builder.Property(d => d.DentalDescription)
            .HasColumnName(nameof(DentalInfo.DentalDescription))
            .HasMaxLength(DentalInfo.Constants.DentalDescriptionMaxLength);

        builder.Property(d => d.PhoneNumber)
            .HasColumnName(nameof(DentalInfo.PhoneNumber))
            .HasMaxLength(DentalInfo.Constants.PhoneNumberMaxLength);

        builder.Property(d => d.PicturePath)
            .HasColumnName(nameof(DentalInfo.PicturePath))
            .HasMaxLength(DentalInfo.Constants.PicturePathMaxLength);
    }
}