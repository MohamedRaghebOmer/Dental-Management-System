using Dental.Domain.Entities;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class LabTransactionConfiguration
    : BaseEntityConfiguration<LabTransaction>
    , IEntityTypeConfiguration<LabTransaction>
{
    public new void Configure(EntityTypeBuilder<LabTransaction> builder)
    {
        base.Configure(builder);
        ConfigureProperties(builder);
        ConfigureCheckConstraints(builder);
        ConfigureIndexes(builder);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<LabTransaction> builder)
    {
        builder.HasIndex(l => l.LabName)
            .HasDatabaseName("IX_LabTransaction_LabName");

        builder.HasIndex(l => l.TranDateTime)
            .HasDatabaseName("IX_LabTransaction_TransactionDateTime");
    }

    private static void ConfigureCheckConstraints(EntityTypeBuilder<LabTransaction> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_LabTransaction_PaidAmount",
                "[PaidAmount] >= 0");

            table.HasCheckConstraint(
                "CK_LabTransaction_TotalAmount",
                "[TotalAmount] >= 0");
        });
    }

    protected override void ConfigureProperties(EntityTypeBuilder<LabTransaction> builder)
    {
        builder.Property(l => l.LabName)
            .HasColumnName(nameof(LabTransaction.LabName))
            .HasMaxLength(LabTransaction.Constants.LabNameMaxLength)
            .IsRequired();

        builder.Property(l => l.TranDateTime)
            .HasColumnName(nameof(LabTransaction.TranDateTime))
            .IsRequired();

        builder.OwnsOne(x => x.TotalAmount, b =>
        {
            b.Property(x => x.Value)
                .HasColumnName(nameof(LabTransaction.TotalAmount))
                .IsRequired();
        });

        builder.OwnsOne(x => x.PaidAmount, b =>
        {
            b.Property(x => x.Value)
                .HasColumnName(nameof(LabTransaction.PaidAmount))
                .IsRequired();
        });

        builder.Ignore(l => l.RemainingAmount);

        builder.Property(l => l.Treatments)
            .HasColumnName(nameof(LabTransaction.Treatments))
            .HasMaxLength(LabTransaction.Constants.TreatmentsMaxLength)
            .IsRequired(false);
    }
}