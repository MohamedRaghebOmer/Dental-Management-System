using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Repositories;

public interface IVisitRepository
    : IRepository<Visit>
{
    // Child Entities: VisitTreatment, Prescription, PrescriptionItem

    // ============== Create ❌ ============== 
    // Fetch the Visit entity and create throw it

    // ============== Read ============== 
    // Get by Id: ❌ (Get the visit entity then return the child throw it)
    // Exists: Do a method when needed 🙄

    // ============== Update ❌ ============== 
    // Fetch the Visit entity and then update throw it

    // ============== Delete ❌ ============== 
    // Fetch the Visit entity and then delete throw it

    // ============== Read (Visit) ============== 
    // - Get By (Visit Treatment Id) ✅
    // - Get By (Prescription Id) ✅
    // - Get By (Prescription Item Id) ✅


    // ==========================================================================
    // ============================ Get =========================================
    // ==========================================================================

    Task<Visit?> GetByTreatmentIdAsync(
        Id id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    Task<Visit?> GetByPrescriptionIdAsync(
        Id id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);

    Task<Visit?> GetByPrescriptionItemIdAsync(
        Id id,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default);



    // ==========================================================================
    // ============================ Exists ======================================
    // ==========================================================================

    Task<bool> TreatmentExistsAsync(
        Id id,
        CancellationToken cancellationToken = default);

    Task<bool> PrescriptionExistsAsync(
        Id id,
        CancellationToken cancellationToken = default);
    Task<bool> PrescriptionItemExistsAsync(
         Id id,
         CancellationToken cancellationToken = default);



    // ==========================================================================
    // ============================ Other ======================================
    // ==========================================================================

    Task<bool> ExistsByAppointmentIdAsync(
        Id appointmentId,
        Id? excludedId,
        CancellationToken cancellationToken = default);

    Task DeleteAllVisitTreatmentsBelongToVisitAsync(
        Id visitId,
        CancellationToken cancellationToken = default);

    Task<Dictionary<int, Visit>> GetByIdsAsync(
    IEnumerable<Id> ids,
    CancellationToken cancellationToken = default);

}