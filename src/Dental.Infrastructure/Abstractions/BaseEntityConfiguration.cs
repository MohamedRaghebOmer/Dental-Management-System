using Dental.Domain.Primitives;
using Dental.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.Abstractions;

public abstract class BaseEntityConfiguration<TEntity>
    where TEntity : Entity
{
    protected void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ConfigureTable(builder);
        ConfigureKey(builder);
        ConfigureProperties(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<TEntity> builder) =>
        builder.ToTable(string.Concat(typeof(TEntity).Name, 's'));

    private static void ConfigureKey(EntityTypeBuilder<TEntity> builder) =>
        builder.ConfigurePrimaryKey();

    protected abstract void ConfigureProperties(EntityTypeBuilder<TEntity> builder);
}