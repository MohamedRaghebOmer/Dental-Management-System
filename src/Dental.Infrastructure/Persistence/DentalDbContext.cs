using Dental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Persistence;

public sealed class DentalDbContext(
    DbContextOptions<DentalDbContext> options)
    : DbContext(options)
{
    public DbSet<Treatment> Treatments => Set<Treatment>();
    public DbSet<Visit> Visits => Set<Visit>();
    public DbSet<VisitTreatment> VisitTreatments => Set<VisitTreatment>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Prescription> Prescriptions => Set<Prescription>();
    public DbSet<PrescriptionItem> PrescriptionsItems => Set<PrescriptionItem>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Material> Materials => Set<Material>();
    public DbSet<DentalInfo> DentalInfo => Set<DentalInfo>();
    public DbSet<LabTransaction> LabTransactions => Set<LabTransaction>();
    public DbSet<VisitPayment> VisitPayments => Set<VisitPayment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DentalDbContext).Assembly);
    }
}