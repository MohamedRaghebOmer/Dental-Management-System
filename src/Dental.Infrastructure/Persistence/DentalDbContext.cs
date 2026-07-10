using Dental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Persistence;

public sealed class DentalDbContext(
    DbContextOptions<DentalDbContext> options)
    : DbContext(options)
{
    public DbSet<Treatment> Treatments => Set<Treatment>();
    public DbSet<Visit> Visits => Set<Visit>();
    public DbSet<VisitToothTreatment> VisitToothTreatments => Set<VisitToothTreatment>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Prescription> Prescriptions => Set<Prescription>();
    public DbSet<PrescriptionItem> PrescriptionsItems => Set<PrescriptionItem>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Material> Materials => Set<Material>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DentalDbContext).Assembly);
    }
}