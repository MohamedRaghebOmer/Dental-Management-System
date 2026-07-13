using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class PrescriptionConfiguration
    : BaseEntityConfiguration<Prescription>
    , IEntityTypeConfiguration<Prescription>
{
    public new void Configure(EntityTypeBuilder<Prescription> builder)
    {
        base.Configure(builder); // Configures (Table Name, Primary Key, Properties)
        ConfigureForeignKeys(builder);
    }

    private void ConfigureForeignKeys(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasMany(p => p.Items)
            .WithOne(i => i.Prescription)
            .HasForeignKey(i => i.PrescriptionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(p => p.Items)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }

    protected override void ConfigureProperties(EntityTypeBuilder<Prescription> builder)
    {
        builder.Property(p => p.Notes)
            .HasColumnName(nameof(Prescription.Notes))
            .HasMaxLength(Prescription.Constants.NotesMaxLength)
            .IsRequired(false);
    }
}