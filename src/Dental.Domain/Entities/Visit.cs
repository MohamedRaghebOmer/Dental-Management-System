using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class Visit : Entity
{
    public static class Constants
    {
        public const int NotesMaxLength = 500;
        public const int PatientNameMaxLength = 50;
    }

    public Id? AppointmentId { get; private set; } = default;
    public Id PatientId { get; private set; } = default!;
    public Money DiscountAmount { get; private set; } = default!;
    public DateTime VisitDateTime { get; private set; }
    public string? Notes { get; private set; }

    public Appointment? Appointment { get; private set; } = default;
    public Patient Patient { get; private set; } = default!;
    public Prescription? Prescription { get; private set; } = default;


    public IReadOnlyCollection<VisitTreatment> VisitTreatments => _visitTreatments.AsReadOnly();
    private readonly List<VisitTreatment> _visitTreatments = [];

    public IReadOnlyCollection<VisitPayment> VisitPayments => _visitPayments.AsReadOnly();
    private readonly List<VisitPayment> _visitPayments = [];

    public IReadOnlyCollection<VisitRadiograph> VisitRadiographs => _visitRadiographs.AsReadOnly();
    private readonly List<VisitRadiograph> _visitRadiographs = [];


    private Visit() { } // EF Core

    private Visit(
        Id? appointmentId,
        Id patientId,
        Money discountAmount,
        string? notes)
    {
        AppointmentId = appointmentId;
        PatientId = patientId;
        DiscountAmount = discountAmount;
        VisitDateTime = DateTime.Now;
        Notes = notes;
    }



    public static Result<Visit> Create(
        Id? appointmentId,
        Id patientId,
        Money discountAmount,
        string? notes)
    {
        notes = notes?.Trim();

        var validateResult = Validate(notes);
        if (validateResult.IsFailure)
        {
            return Result.Failure<Visit>(validateResult.Error);
        }

        return new Visit(appointmentId, patientId, discountAmount, notes);
    }

    public Result Update(
        Money discountAmount,
        string? notes)
    {
        notes = notes?.Trim();

        var validateResult = Validate(notes);
        if (validateResult.IsFailure)
        {
            return Result.Failure(validateResult.Error);
        }

        DiscountAmount = discountAmount;
        Notes = notes;

        return Result.Success();
    }

    private static Result Validate(string? notes)
    {
        if (notes?.Length > Constants.NotesMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.Visit.Notes.TooLong);
        }

        return Result.Success();
    }


    public Result<VisitTreatment> AddVisitTreatment(
        Id treatmentId,
        ToothNumber? toothNumber,
        int count,
        Money treatmentPrice,
        string? notes)
    {
        var createTreatmentResult = VisitTreatment.Create(
            toothNumber: toothNumber,
            visitId: this.Id,
            treatmentId: treatmentId,
            count: count,
            treatmentPrice: treatmentPrice,
            notes: notes);

        if (createTreatmentResult.IsFailure)
        {
            return Result.Failure<VisitTreatment>(createTreatmentResult.Error);
        }

        _visitTreatments.Add(createTreatmentResult.Value);

        return Result.Success(createTreatmentResult.Value);
    }

    public Result UpdateVisitTreatment(
        Id visitTreatmentId,
        Id treatmentId,
        ToothNumber? toothNumber,
        int count,
        string? notes)
    {
        var visitTreatment = _visitTreatments.FirstOrDefault(
            vt => vt.Id == visitTreatmentId);
        if (visitTreatment is null)
        {
            return Result.Failure(DomainErrors.Entities.Visit.Treatment.NotFound);
        }

        var updateResult = visitTreatment.Update(
            treatmentId: treatmentId,
            toothNumber: toothNumber,
            count: count,
            notes: notes);

        return updateResult.IsFailure ? Result.Failure(updateResult.Error) : Result.Success();
    }

    public Result RemoveVisitTreatment(Id visitTreatmentId)
    {
        var visitTreatment = _visitTreatments.FirstOrDefault(
            vt => vt.Id == visitTreatmentId);
        if (visitTreatment is null)
        {
            return Result.Failure(DomainErrors.Entities.Visit.Treatment.NotFound);
        }

        _visitTreatments.Remove(visitTreatment);
        return Result.Success();
    }

    public Result<Prescription> AddPrescription(Id patientId, string? notes)
    {
        if (Prescription is not null)
        {
            return Result.Failure<Prescription>(
                DomainErrors.Entities.Visit.Prescription.AlreadyExists);
        }

        var result = Prescription.Create(
            patientId: patientId,
            visitId: Id,
            notes);

        if (result.IsFailure)
        {
            return Result.Failure<Prescription>(result.Error);
        }

        Prescription = result.Value;

        return Result.Success(result.Value);
    }

    public Result UpdatePrescription(string? notes)
    {
        if (Prescription is null)
        {
            return Result.Failure(
                DomainErrors.Entities.Visit.Prescription.VisitDoesNotHavePrescription);
        }

        return Prescription.Update(notes);
    }

    public Result RemovePrescription()
    {
        if (Prescription is null)
        {
            return Result.Failure(
                DomainErrors.Entities.Visit.Prescription.VisitDoesNotHavePrescription);
        }

        Prescription = null;

        return Result.Success();
    }


    public Result<PrescriptionItem> AddPrescriptionItem(
        string medicineName,
        decimal dosage,
        MedicineFrequency frequency,
        string? instructions)
    {
        if (Prescription == null)
        {
            return Result.Failure<PrescriptionItem>(DomainErrors.Entities.Visit.Prescription.VisitDoesNotHavePrescription);
        }

        var addItemResult = Prescription.AddItem(
            medicineName,
            dosage,
            frequency,
            instructions);
        if (addItemResult.IsFailure)
        {
            return Result.Failure<PrescriptionItem>(addItemResult.Error);
        }

        return Result.Success(addItemResult.Value);
    }

    public Result UpdatePrescriptionItem(
        Id itemId,
        string medicineName,
        decimal dosage,
        MedicineFrequency frequency,
        string? instructions)
    {
        if (Prescription == null)
        {
            return Result.Failure(DomainErrors.Entities.Visit.Prescription.VisitDoesNotHavePrescription);
        }

        var updateItemResult = Prescription.UpdateItem(
            itemId,
            medicineName,
            dosage,
            frequency,
            instructions);
        if (updateItemResult.IsFailure)
        {
            return Result.Failure(updateItemResult.Error);
        }

        return Result.Success();
    }

    public Result RemovePrescriptionItem(Id itemId)
    {
        if (Prescription == null)
        {
            return Result.Failure(DomainErrors.Entities.Visit.Prescription.VisitDoesNotHavePrescription);
        }

        var removeItemResult = Prescription.RemoveItem(itemId);
        if (removeItemResult.IsFailure)
        {
            return Result.Failure(removeItemResult.Error);
        }

        return Result.Success();
    }


    public Result<VisitPayment> AddVisitPayment(
        Money paidAmount)
    {
        var createResult = VisitPayment.Create(Id, paidAmount);
        if (createResult.IsFailure)
            return Result.Failure<VisitPayment>(createResult.Error);

        _visitPayments.Add(createResult.Value);

        return createResult.Value;
    }

    public Result UpdateVisitPayment(
        Id visitPaymentId,
        Money paidAmount)
    {
        var entity = _visitPayments.FirstOrDefault(vp => vp.Id == visitPaymentId);
        if (entity is null)
            return Result.Failure(DomainErrors.Entities.Visit.VisitPayment.NotFound);

        var updateResult = entity.Udpate(paidAmount);
        if (updateResult.IsFailure)
            return Result.Failure(updateResult.Error);

        return Result.Success();
    }

    public Result RemoveVisitPayment(
        Id visitPaymentId)
    {
        var entity = _visitPayments.FirstOrDefault(vp => vp.Id == visitPaymentId);
        if (entity is null)
            return Result.Failure(DomainErrors.Entities.Visit.VisitPayment.NotFound);

        _visitPayments.Remove(entity);
        return Result.Success();
    }


    // VisitRadiograph methods
    public Result<VisitRadiograph> AddVisitRadiograph(
        string imagePath)
    {
        var createResult = VisitRadiograph.Create(Id, imagePath);
        if (createResult.IsFailure)
            return Result.Failure<VisitRadiograph>(createResult.Error);

        _visitRadiographs.Add(createResult.Value);

        return Result.Success(createResult.Value);
    }

    public Result UpdateVisitRadiograph(
        Id visitRadiographId,
        string imagePath)
    {
        var entity =
            _visitRadiographs.FirstOrDefault(vr => vr.Id == visitRadiographId);
        if (entity is null)
            return Result.Failure(DomainErrors.Entities.Visit.VisitRadiograph.NotFound);

        var updateResult = entity.Update(imagePath);
        if (updateResult.IsFailure)
            return Result.Failure(updateResult.Error);

        return Result.Success();
    }

    public Result RemoveVisitRadiograph(
        Id visitRadiographId)
    {
        var entity = _visitRadiographs.FirstOrDefault(vr => vr.Id == visitRadiographId);
        if (entity is null)
            return Result.Failure(DomainErrors.Entities.Visit.VisitRadiograph.NotFound);
        _visitRadiographs.Remove(entity);
        return Result.Success();
    }
}