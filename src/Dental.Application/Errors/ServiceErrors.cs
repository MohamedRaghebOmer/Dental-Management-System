using Dental.Domain.Shared;

namespace Dental.Application.Errors;

public static class ServiceErrors
{
    public static readonly Error NotFound =
        new("NotFound", "The requested entity not found.");

    public static readonly Error InvalidId =
        new("InvalidId", "ID must be greater than zero.");

    public static class Visit
    {
        public static readonly Error PrescriptionNotFound = new(
            "Visit.PrescriptionNotFound",
            "Prescription not found.");

        public static readonly Error InvalidToothNumber = new(
            "Visit.InvalidToothNumber",
            "Invalid tooth number");
        
        public static readonly Error InvalidTreatmentId = new(
            "Visit.InvalidTreatmentId",
            "Invalid treatment Id.");

        public static readonly Error TreatmentNotFound = new(
            "Visit.TreatmentNotFound",
            "Treatment not found.");

        public static readonly Error DuplicatedAppointmentId = new(
            "Visit.DuplicatedAppointmentId",
            "There is already a visit with the same appointment ID.");
    }

    public static class VisitTreatment
    {
        public static readonly Error VisitNotFound =
            new("VisitTreatment.VisitNotFound", "Visit not found.");

        public static readonly Error TreatmentNotFound =
            new("VisitTreatment.TreatmentNotFound", "Treatment not found.");

        public static readonly Error AlreadyExists = new(
            "VisitTreatment.AlreadyExists",
            "Visit tooth treatment already exists for the given service and visit IDs."
        );
    }

    public static class Appointment
    {
        public static readonly Error PatientNotFound =
            new("Appointment.PatientNotFound", "Patient not found.");

        public static readonly Error DateIsTaken =
            new("Appointment.DateIsTaken", 
                "There is already an appointment for the given date.");
    }

    public static class Prescription
    {
        public static readonly Error PatientNotFound =
            new("Prescription.PatientNotFound", "Patient not found.");

        public static readonly Error VisitNotFound =
            new("Prescription.VisitNotFound", "Visit not found.");
    }

    public static class PrescriptionItem
    {
        public static readonly Error PrescriptionNotFound = new(
            "PrescriptionItem.PrescriptionNotFound", 
            "Prescription not found.");

        public static readonly Error PrescriptionItemNotFound = new(
            "PrescriptionItem.PrescriptionItemNotFound",
            "Prescription item not found."
        );

        public static readonly Error VisitNotFound = new(
            "PrescriptionItem.VisitNotFound",
            "Visit not found."
        );
    }

    public static class Supplier
    {
        public static readonly Error PhoneNumberAlreadyExists =
            new("Supplier.PhoneNumberExists", "Phone number already exists.");
    }

    public static class Treatment
    {
        public static readonly Error DuplicateName =
            new("Treatment.DuplicateName", "A treatment with the same name already exists.");
    }

    public static class Material
    {
        public static readonly Error InvalidSupplierId =
            new("Material.InvalidSupplierId", "Invalid supplier ID.");

        public static readonly Error DuplicateName =
            new("Material.DuplicateName", "A material with the same name already exists.");
    }
}