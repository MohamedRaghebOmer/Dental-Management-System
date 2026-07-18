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
    public string? PatientName { get; private set; }
    public Money PaidAmount { get; private set; } = default!;
    public Money DiscountAmount { get; private set; } = default!;
    public DateTime VisitDateTime { get; private set; }
    public string? Notes { get; private set; }
    public Appointment? Appointment { get; private set; } = default;
    public Prescription? Prescription { get; private set; } = default;


    public IReadOnlyCollection<VisitTreatment> VisitTreatments => _visitTreatments.AsReadOnly();
    private readonly List<VisitTreatment> _visitTreatments = [];


    private Visit() { } // EF Core

    private Visit(
        Id? appointmentId,
        string? patientName,
        Money paidAmount,
        Money discountAmount,
        DateTime visitDateTime,
        string? notes)
    {
        AppointmentId = appointmentId;
        PatientName = patientName;
        PaidAmount = paidAmount;
        DiscountAmount = discountAmount;
        VisitDateTime = visitDateTime;
        Notes = notes;
    }



    public static Result<Visit> Create(
        Id? appointmentId,
        string? patientName,
        Money paidAmount,
        Money discountAmount,
        DateTime visitDateTime,
        string? notes)
    {
        notes = notes?.Trim();
        patientName = patientName?.Trim();

        var validateResult = Validate(visitDateTime, patientName, notes);
        if (validateResult.IsFailure)
        {
            return Result.Failure<Visit>(validateResult.Error);
        }

        return new Visit(appointmentId, patientName, paidAmount, discountAmount, visitDateTime, notes);
    }

    public Result Update(
        Id? appointmentId,
        string? patientName,
        Money paidAmount,
        Money discountAmount,
        DateTime visitDateTime,
        string? notes)
    {
        notes = notes?.Trim();
        patientName = patientName?.Trim();

        var validateResult = Validate(visitDateTime, patientName, notes);
        if (validateResult.IsFailure)
        {
            return Result.Failure(validateResult.Error);
        }

        if (appointmentId != AppointmentId && Appointment is not null)
        {
            var changeStatusResult = Appointment.ChangeStatusToPending();
            if (changeStatusResult.IsFailure)
            {
                return Result.Failure(changeStatusResult.Error);
            }
        }

        AppointmentId = appointmentId;
        PatientName = patientName;
        PaidAmount = paidAmount;
        DiscountAmount = discountAmount;
        VisitDateTime = visitDateTime;
        Notes = notes;

        return Result.Success();
    }

    private static Result Validate(
        DateTime visitDateTime, string? patientName,
        string? notes)
    {
        if (visitDateTime > DateTime.Now)
        {
            return Result.Failure(DomainErrors.Entities.Visit.Date.InThePast);
        }

        if (notes?.Length > Constants.NotesMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.Visit.Notes.TooLong);
        }

        if (patientName?.Length > Constants.PatientNameMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.Visit.PatientName.TooLong);
        }

        return Result.Success();
    }


    public Result<VisitTreatment> AddVisitTreatment(
        ToothNumber toothNumber,
        Id treatmentId,
        Money price, // Get it from database first and put it in the constructor. In treatments table > price
        string? notes)
    {
        if (_visitTreatments.Any(t => t.TreatmentId == treatmentId && t.ToothNumber == toothNumber))
        {
            return Result.Failure<VisitTreatment>(DomainErrors.Entities.Visit.Treatment.DuplicateTreatmentForTheSameTooth);
        }

        var createTreatmentResult = VisitTreatment.Create(
            toothNumber,
            this.Id,
            treatmentId,
            price,
            notes);

        if (createTreatmentResult.IsFailure)
        {
            return Result.Failure<VisitTreatment>(createTreatmentResult.Error);
        }

        _visitTreatments.Add(createTreatmentResult.Value);

        return Result.Success(createTreatmentResult.Value);
    }

    public Result UpdateVisitTreatment(
        Id visitTreatmentId,
        ToothNumber toothNumber,
        Id treatmentId,
        string? notes)
    {
        if (_visitTreatments.Any(
            t => t.TreatmentId == treatmentId
            && t.ToothNumber == toothNumber
            && t.Id != visitTreatmentId))
        {
            return Result.Failure(DomainErrors.Entities.Visit.Treatment.DuplicateTreatmentForTheSameTooth);
        }

        var treatment = _visitTreatments.FirstOrDefault(t => t.Id == visitTreatmentId);
        if (treatment is null)
        {
            return Result.Failure(DomainErrors.Entities.Visit.Treatment.NotFound);
        }

        var updateResult = treatment.Update(
            toothNumber,
            treatmentId,
            notes);

        if (updateResult.IsFailure)
        {
            return Result.Failure(updateResult.Error);
        }

        return Result.Success();
    }

    public Result RemoveVisitTreatment(Id visitTreatmentId)
    {
        var treatment = _visitTreatments.FirstOrDefault(t => t.Id == visitTreatmentId);
        if (treatment is null)
        {
            return Result.Failure(DomainErrors.Entities.Visit.Treatment.NotFound);
        }

        _visitTreatments.Remove(treatment);
        return Result.Success();
    }

    public void RemoveAllVisitTreatments()
        => _visitTreatments.Clear();

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
}