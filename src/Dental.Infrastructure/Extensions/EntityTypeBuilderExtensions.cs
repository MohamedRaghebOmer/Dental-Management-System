using Dental.Domain.Primitives;
using Dental.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<TEntity> ConfigurePrimaryKey<TEntity>(
        this EntityTypeBuilder<TEntity> builder)
        where TEntity : Entity
    {
        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => Id.FromDatabase(value))
            .ValueGeneratedOnAdd();

        builder.HasKey(x => x.Id);

        return builder;
    }
}