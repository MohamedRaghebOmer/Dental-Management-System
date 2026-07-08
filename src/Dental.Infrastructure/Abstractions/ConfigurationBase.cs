using Dental.Domain.Entities;
using Dental.Domain.Primitives;
using Dental.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.Abstractions;

public abstract class ConfigurationBase<TEntity>
    where TEntity : Entity
{
    protected void ConfigureTable(EntityTypeBuilder<TEntity> builder) =>
        builder.ToTable(string.Concat(typeof(TEntity).Name, 's'));

    private void ConfigureKey(EntityTypeBuilder<Patient> builder) =>
        builder.ConfigurePrimaryKey();

    protected abstract void ConfigureProperties(EntityTypeBuilder<TEntity> builder);
}