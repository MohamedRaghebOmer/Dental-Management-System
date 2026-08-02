using Dental.Domain.Entities;
using Dental.Domain.Errors;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class VisitRadiographConfiguration
    : BaseEntityConfiguration<VisitRadiograph>
    , IEntityTypeConfiguration<VisitRadiograph>
{
    public new void Configure(EntityTypeBuilder<VisitRadiograph> builder)
    {
        base.Configure(builder); // Configures the (Table name, PK, and calls ConfigureProperties)
        ConfigureForeignKeys(builder);
        ConfigureIndexes(builder);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<VisitRadiograph> builder)
    {
        builder.HasIndex(vr => vr.VisitId)
            .HasDatabaseName($"IX_{nameof(VisitRadiograph)}_{nameof(VisitRadiograph.VisitId)}");
    }

    private static void ConfigureForeignKeys(EntityTypeBuilder<VisitRadiograph> builder)
    {
        builder.HasOne(vr => vr.Visit)
            .WithMany(v => v.VisitRadiographs)
            .HasForeignKey(vr => vr.VisitId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<VisitRadiograph> builder)
    {
        builder.Property(vr => vr.VisitId)
            .HasConversion(
                value => value.Value,
                value => Id.FromDatabase(value))
            .HasColumnName(nameof(VisitRadiograph.VisitId))
            .IsRequired();

        builder.Property(vr => vr.ImagePath)
            .HasMaxLength(VisitRadiograph.Constants.ImagePathMaxLength)
            .IsRequired();

        builder.Property(vr => vr.CreatedAt)
            .HasColumnName(nameof(VisitRadiograph.CreatedAt))
            .IsRequired();
    }
}