using Dental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Persistence;

public sealed class DentalDbContext(
    DbContextOptions<DentalDbContext> options)
    : DbContext(options)
{
    public DbSet<Service> Services => Set<Service>();
    public DbSet<Visit> Visits => Set<Visit>();
    public DbSet<VisitToothTreatment> VisitToothTreatments => Set<VisitToothTreatment>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<Patient> Patients => Set<Patient>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DentalDbContext).Assembly);
    }
}