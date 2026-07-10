using Dental.Domain.Shared;

namespace Dental.Domain.Errors;

public static class DomainErrors
{
    public static class Entities
    {
        public static class Treatment
        {
            public static class Name
            {
                public static readonly Error Empty = new(
                    "TreatmentName.Empty",
                    "The treatment name cannot be empty.");

                public static readonly Error TooLong = new(
                    "TreatmentName.TooLong",
                    $"The treatment name cannot be longer than {Domain.Entities.Treatment.Constants.NameMaxLength} characters."
                );
            }

            public static class Description
            {
                public static readonly Error TooLong = new(
                    "TreatmentDescription.TooLong",
                    $@"The description cannot be longer than {Domain.Entities.Treatment.Constants.DescriptionMaxLength} characters."
                );
            }
        }

        public static class Appointment
        {
            public static class Date
            {
                public static readonly Error InThePast = new(
                    "AppointmentDate.InThePast",
                    "The appointment date cannot be in the past."
                );

                public static readonly Error CannotBeChangedWhenStatusIsNotPending = new(
                    "AppointmentDate.CannotBeChangedWhenStatusIsNotPending",
                    "The appointment date cannot be changed when the status is not pending."
                );
            }

            public static class PatientId
            {
                public static readonly Error CannotBeChangedWhenStatusIsNotPending = new(
                    "AppointmentPatientId.CannotBeChangedWhenStatusIsNotPending",
                    "The appointment patient ID cannot be changed when the status is not pending."
                );
            }

            public static class Status
            {
                public static readonly Error CannotBeCanceledWhenCompletedOrCanceled = new(
                    "AppointmentStatus.CannotBeCanceledWhenCompletedOrCanceled",
                    "The appointment status cannot be canceled" +
                    " after it has been completed or it's already canceled."
                );

                public static readonly Error CannotBeCompletedWhenCanceledOrCompleted = new(
                    "AppointmentStatus.CannotBeCompletedWhenCanceledOrCompleted",
                    "The appointment status cannot be completed" +
                    " after it has been canceled or it's already completed."
                );
            }

            public static class Id
            {
                public static readonly Error InvalidId = new(
                    "AppointmentId.InvalidId",
                    "The appointment ID is invalid."
                );
            }

            public static class Notes
            {
                public static readonly Error TooLong = new(
                    "AppointmentNotes.TooLong",
                    $"The appointment notes cannot be longer than {Domain.Entities.Appointment.Constants.NotesMaxLength} characters."
                );
            }
        }

        public static class Visit
        {
            public static class Date
            {
                public static readonly Error CannotBeInTheFuture = new(
                    "VisitDate.CannotBeInTheFuture",
                    "The visit date cannot be in the future."
                );
            }

            public static class Notes
            {
                public static readonly Error TooLong = new(
                    "VisitNotes.TooLong",
                    $"Visit notes cannot exceed {Domain.Entities.Visit.Constants.NotesMaxLength} characters length.");
            }
        }

        public static class VisitToothTreatment
        {
            public static class Notes
            {
                public static readonly Error TooLong = new(
                    "VisitToothTreatmentNotes.TooLong",
                    $"Visit tooth treatment notes cannot exceed {Domain.Entities.VisitToothTreatment.Constants.NotesMaxLength} characters length.");
            }
        }

        public static class PrescriptionItems
        {
            public static class MedicineName
            {
                public static readonly Error Required = new(
                    "PrescriptionItems.MedicineNameRequired",
                    "The medicine name is required.");

                public static readonly Error TooLong = new(
                    "PrescriptionItems.MedicineNameTooLong",
                    $"The medicine name cannot be longer than {Domain.Entities.PrescriptionItem.Constants.MedicineNameMaxLength} characters."
                );
            }

            public static class Dosage
            {
                public static readonly Error MustBePositive = new(
                    "PrescriptionItems.MustBePositive",
                    "The dosage is required and must be greater than zero.");
            }

            public static class Instructions
            {
                public static Error TooLong = new(
                    "PrescriptionItems.InstructionsTooLong",
                    $"The instructions cannot be longer than {Domain.Entities.PrescriptionItem.Constants.InstructionsMaxLength} characters."
                );
            }
        }

        public static class Supplier
        {
            public static class Name
            {
                public static readonly Error TooLong = new(
                    "Supplier.NameTooLong",
                    $"The supplier name cannot be longer than {Domain.Entities.Supplier.Constants.NameMaxLength} characters."
                );
            }

            public static class Address
            {
                public static readonly Error TooLong = new(
                    "Supplier.AddressTooLong",
                    $"The supplier address cannot be longer than {Domain.Entities.Supplier.Constants.AddressMaxLength} characters."
                );
            }

            public static class Description
            {
                public static readonly Error TooLong = new(
                    "Supplier.DescriptionTooLong",
                    $"The supplier description cannot be longer than {Domain.Entities.Supplier.Constants.DescriptionMaxLength} characters."
                );
            }
        }
    }

    public static class ValueObjects
    {
        public static class Money
        {
            public static readonly Error NonPositiveValue = new(
                "Money.NonPositiveValue",
                "Money value cannot be zero or negative.");
        }

        public static class FirstName
        {
            public static readonly Error Empty = new(
                "FirstName.Empty",
                "The first name cannot be empty.");

            public static readonly Error TooLong = new(
                "FirstName.TooLong",
                $"The first name cannot be longer than {Domain.Entities.Patient.Constants.FirstNameMaxLength} characters."
            );
        }

        public static class LastName
        {
            public static readonly Error Empty = new(
                "LastName.Empty",
                "The last name cannot be empty.");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                $"The last name cannot be longer than {Domain.Entities.Patient.Constants.LastNameMaxLength} characters."
            );
        }

        public static class DateOfBirth
        {
            public static readonly Error LessThanMinimumAllowedAge = new(
                "DateOfBirth.LessThanMinimumAllowedAge",
                $"The date of birth cannot be less than {Domain.ValueObjects.DateOfBirth.MinimumAge} years.");

            public static readonly Error OlderThanMaximumAllowedAge = new(
                "DateOfBirth.OlderThanMaximumAllowedAge",
                $"The date of birth cannot be longer than {Domain.ValueObjects.DateOfBirth.MaximumAge} years."
            );
        }

        public static class PhoneNumber
        {
            public static readonly Error Empty = new(
                "PhoneNumber.Empty",
                "The phone number cannot be empty."
            );

            public static readonly Error Invalid = new(
                "PhoneNumber.Invalid",
                $"The phone number must be {Domain.Entities.Patient.Constants.PhoneNumberLength} characters long."
            );
        }

        public static class ToothNumber
        {
            public static readonly Error OutOfRange = new(
                "VisitToothTreatmentToothNumber.OutOfRange",
                "The tooth number must be between 1 and 32."
            );
        }

        public static class MedicineFrequency
        {
            public static readonly Error NegativeValue = new(
                "MedicineFrequency.NegativeValue",
                "The medicine frequency value must be greater than zero."
            );
        }
    }

    public static class Prescription
    {
        public static class Notes
        {
            public static readonly Error TooLong = new(
                "PrescriptionNotes.TooLong",
                $"The prescription notes cannot be longer than{Domain.Entities.Prescription.Constants.NotesMaxLength} characters.");
        }
    }
}