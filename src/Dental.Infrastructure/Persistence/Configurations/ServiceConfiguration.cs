using Dental.Domain.Entities;
using Dental.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.Persistence.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        ConfigureTable(builder);
        ConfigureKey(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("Services");
    }

    private static void ConfigureKey(EntityTypeBuilder<Service> builder)
    {
        builder.ConfigurePrimaryKey();
    }

    private static void ConfigureProperties(EntityTypeBuilder<Service> builder)
    {
        builder.OwnsOne(
            x => x.Name,
            navigationBuilder =>
            {
                navigationBuilder.Property(x => x.Value)
                    .HasColumnName(nameof(Service.Name))
                    .HasMaxLength(Service.NameMaxLength)
                    .IsRequired();
            });

        builder.OwnsOne(
            x => x.Price,
            navigationBuilder =>
            {
                navigationBuilder.Property(x => x.Value)
                    .HasColumnName(nameof(Service.Price))
                    .HasPrecision(18, 2)
                    .IsRequired();
            });

        builder.Property(x => x.Description)
            .HasColumnName(nameof(Service.Description))
            .HasMaxLength(Service.DescriptionMaxLength)
            .IsRequired(false);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Service> builder)
    {
        builder.HasIndex(x => x.Name)
            .HasDatabaseName("UX_Services_Name")
            .IsUnique();
    }
}