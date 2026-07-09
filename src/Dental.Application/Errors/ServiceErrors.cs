using Dental.Domain.Shared;

namespace Dental.Application.Errors;

public static class ServiceErrors
{
    public static readonly Error ParameterNullReference =
        new("NullReference", "Parameter is null.");

    public static readonly Error NotFound =
        new("NotFound", "Service not found.");

    public static readonly Error InvalidId =
        new("InvalidId", "Service ID must be greater than zero.");

    public static readonly Error EmptyDataset =
        new("EmptyDataset", "The dataset is empty.");

    public static class VisitToothTreatmentErrors
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
    }
}