using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dental.Infrastructure.EntityConfigurations;

public sealed class VisitPaymentConfiguration
    : BaseEntityConfiguration<VisitPayment>
    , IEntityTypeConfiguration<VisitPayment>
{
    public new void Configure(EntityTypeBuilder<VisitPayment> builder)
    {
        base.Configure(builder); // Configures (Table, PK, Properties)
        ConfigureForientKeys(builder);
        ConfigureCheckConstraints(builder);
        ConfigureIndexes(builder);
    }

    private static void ConfigureForientKeys(EntityTypeBuilder<VisitPayment> builder)
    {
        builder.HasOne(vp => vp.Visit)
            .WithMany(vp => vp.VisitPayments)
            .HasForeignKey(vp => vp.VisitId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }

    private static void ConfigureIndexes(EntityTypeBuilder<VisitPayment> builder)
    {
        builder.HasIndex(vp => vp.VisitId)
            .HasDatabaseName("IX_VisitPayments_VisitId");
    }

    private static void ConfigureCheckConstraints(EntityTypeBuilder<VisitPayment> builder)
    {
        builder.ToTable(tabel =>
        {
            tabel.HasCheckConstraint(
                "CK_VisitPayments_PaidAmount_GreaterThanZero",
                "[PaidAmount] > 0");
        });
    }

    protected override void ConfigureProperties(EntityTypeBuilder<VisitPayment> builder)
    {
        builder.Property(vp => vp.VisitId)
            .HasConversion(
                value => value.Value,
                value => Id.FromDatabase(value))
            .HasColumnName(nameof(VisitPayment.VisitId))
            .IsRequired();

        builder.Property(vp => vp.PaidAmount)
            .HasConversion(
                value => value.Value,
                value => Money.FromDatabase(value))
            .HasColumnName(nameof(VisitPayment.PaidAmount))
            .IsRequired();

        builder.Property(vp => vp.PaymentDateTime)
            .HasColumnName(nameof(VisitPayment.PaymentDateTime))
            .IsRequired();
    }
}