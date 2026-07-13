using Dental.Domain.Shared;

namespace Dental.Application.Errors;

public static class ServiceErrors
{
    public static readonly Error NotFound =
        new("NotFound", "The requested entity not found.");

    public static readonly Error InvalidId =
        new("InvalidId", "ID must be greater than zero.");

    public static class VisitTreatmentErrors
    {
        public static readonly Error VisitNotFound =
            new("VisitNotFound", "Visit not found.");

        public static readonly Error ServiceNotFound =
            new("ServiceNotFound", "Service not found.");

        public static readonly Error AlreadyExists = new(
            "AlreadyExists",
            "Visit tooth treatment already exists for the given service and visit IDs."
        );
    }

    public static class AppointmentErrors
    {
        public static readonly Error PatientNotFound =
            new("PatientNotFound", "Patient not found.");

        public static readonly Error DateIsTaken =
            new("DateIsTaken", "There is already an appointment for the given date.");
    }

    public static class Prescription
    {
        public static readonly Error PatientNotFound =
            new("PatientNotFound", "Patient not found.");
        public static readonly Error VisitNotFound =
            new("VisitNotFound", "Visit not found.");
    }

    public static class PrescriptionItem
    {
        public static readonly Error PrescriptionNotFound = new(
            "PrescriptionNotFound", 
            "Prescription not found.");

        public static readonly Error PrescriptionItemNotFound = new(
            "PrescriptionItemNotFound",
            "Prescription item not found."
        );

        public static readonly Error VisitNotFound = new(
            "VisitNotFound",
            "Visit not found."
        );
    }

    public static class Supplier
    {
        public static readonly Error PhoneNumberExists =
            new("PhoneNumberExists", "Phone number already exists.");
    }

    public static class Treatment
    {
        public static readonly Error DuplicateName =
            new("DuplicateName", "A treatment with the same name already exists.");
    }

    public static class Material
    {
        public static readonly Error InvalidSupplierId =
            new("InvalidSupplierId", "Invalid supplier ID.");

        public static readonly Error DuplicateName =
            new("DuplicateName", "A material with the same name already exists.");
    }
}