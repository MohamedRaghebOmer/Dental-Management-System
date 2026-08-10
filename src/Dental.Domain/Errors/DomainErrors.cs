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
                    "Name.Empty",
                    "The treatment name cannot be empty.");

                public static readonly Error TooLong = new(
                    "Name.TooLong",
                    $"The treatment name cannot be longer than {Domain.Entities.Treatment.Constants.NameMaxLength} characters."
                );
            }

            public static class Description
            {
                public static readonly Error TooLong = new(
                    "Description.TooLong",
                    $@"The description cannot be longer than {Domain.Entities.Treatment.Constants.DescriptionMaxLength} characters."
                );
            }
        }

        public static class Appointment
        {
            public static class ScheduledVisitDateTime
            {
                public static readonly Error InThePast = new(
                    "Date.InThePast",
                    "The appointment date cannot be in the past."
                );

                public static readonly Error CannotBeChangedWhenStatusIsNotPendingOrMissed = new(
                    "Date.CannotBeChangedWhenStatusIsNotPendingOrMissed",
                    "The appointment date cannot be changed when the status is not pending."
                );
            }

            public static class PatientId
            {
                public static readonly Error CannotBeChangedWhenStatusIsNotPendingOrMissed = new(
                    "PatientId.CannotBeChangedWhenStatusIsNotPendingOrMissed",
                    "The appointment patient ID cannot be changed when the status is not pending."
                );
            }

            public static class Status
            {
                public static readonly Error CannotBeCanceledWhenAlreadyCanceled = new(
                    "Status.CannotBeCanceledWhenAlreadyCanceled",
                    "The appointment status is already canceled");

                public static readonly Error CannotBePendingWhenAlreadyPending = new(
                    "Status.CannotBePendingWhenAlreadyPending",
                    "Appointment status is already pending.");

                public static readonly Error CannotBeCompletedWhenAlreadyCompleted = new(
                    "Status.CannotBeCompletedWhenAlreadyCompleted",
                    "Appointment status is already completed.");

                public static readonly Error CannotBePendingWhenCanceled = new(
                    "Status.CannotBePendingWhenCanceled",
                    "Appointment status is can not be pending when canceled.");

                public static readonly Error CannotBeCanceledWhenCompleted = new(
                    "Status.CannotBeCanceledWhenCompleted",
                    "The appointment status can not be canceled when completed.");

                public static readonly Error CannotBeCompletedWhenCanceled = new(
                    "Status.CannotBeCompletedWhenCanceled",
                    "The appointment status can not completed when canceled.");
            }

            public static class Notes
            {
                public static readonly Error TooLong = new(
                    "Notes.TooLong",
                    $"The appointment notes cannot be longer than {Domain.Entities.Appointment.Constants.NotesMaxLength} characters."
                );
            }
        }

        public static class Visit
        {
            public static class Notes
            {
                public static readonly Error TooLong = new(
                    "Notes.TooLong",
                    $"Visit notes cannot exceed {Domain.Entities.Visit.Constants.NotesMaxLength} characters length.");
            }

            public static class Treatment
            {
                public static readonly Error DuplicateTreatmentForTheSameTooth = new(
                    "Treatment.DuplicateTreatmentForTheSameTooth",
                    "A treatment with the same ID already exists for the same tooth in this visit.");

                public static readonly Error NotFound = new(
                    "Treatment.NotFound",
                    "Treatment not found");
            }

            public static class Prescription
            {
                public static readonly Error VisitDoesNotHavePrescription = new(
                    "Prescription.VisitDoesNotHavePrescription",
                    "Prescription not found.");

                public static readonly Error AlreadyExists = new(
                    "Prescription.AlreadyExists",
                    "There is already a prescription added for this visit.");
            }

            public static class PatientName
            {
                public static readonly Error TooLong = new(
                    "PatientName.TooLong",
                    $"Patient name can not exceed {Domain.Entities.Visit.Constants.PatientNameMaxLength} character length.");
            }

            public static class VisitPayment
            {
                public static readonly Error NotFound = new(
                    "VisitPayment.NotFounf",
                    "Visit payment not found.");
            }

            public static class VisitRadiograph
            {
                public static readonly Error NotFound = new(
                    "VisitRadiograph.NotFound",
                    "Visit radiograph not found.");
            }
        }

        public static class VisitTreatment
        {
            public static class Notes
            {
                public static readonly Error TooLong = new(
                    "Notes.TooLong",
                    $"Visit tooth treatment notes cannot exceed {Domain.Entities.VisitTreatment.Constants.NotesMaxLength} characters length.");
            }

            public static class Count
            {
                public static readonly Error EqualToOrLessThanZero = new(
                    "Count.EqualToOrLessThanZero",
                    "The treatment count must be a positive integer.");
            }
        }

        public static class PrescriptionItem
        {
            public static class MedicineName
            {
                public static readonly Error Empty = new(
                    "MedicineName.Empty",
                    "The medicine name is required.");

                public static readonly Error TooLong = new(
                    "MedicineName.TooLong",
                    $"The medicine name cannot be longer than {Domain.Entities.PrescriptionItem.Constants.MedicineNameMaxLength}" +
                    $" characters.");

                public static readonly Error AlreadyExists = new(
                    "MedicineName.AlreadyExists",
                    "There is already a medicine with the same name");
            }

            public static class Dosage
            {
                public static readonly Error LessThanOrEqualToZero = new(
                    "Dosage.LessThanOrEqualToZero",
                    "The dosage is required and must be greater than zero.");
            }

            public static class Instructions
            {
                public static Error TooLong = new(
                    "Instructions.TooLong",
                    $"The instructions cannot be longer than {Domain.Entities.PrescriptionItem.Constants.InstructionsMaxLength} characters."
                );
            }
        }

        public static class Patient
        {
            public static class Age
            {
                public static readonly Error LessThanMinimumAllowedAge = new(
                    "Age.LessThanMinimumAllowedAge",
                    $"Age must be greater than or equal to{Domain.Entities.Patient.Constants.MinimumAllowedAge}");

                public static readonly Error GreaterThanMaximumAllowedAge = new(
                    "Age.GreaterThanMaximumAllowedAge",
                    $"Age must less than or equal to{Domain.Entities.Patient.Constants.MaximumAllowedAge}");
            }

            public static class Name
            {
                public static readonly Error Empty = new(
                    "Name.Empty",
                    "The patient name is required."
                );

                public static readonly Error TooLong = new(
                    "Name.TooLong",
                    $"The patient name cannot be longer than {Domain.Entities.Patient.Constants.NameMaxLength} characters."
                );
            }
        }

        public static class Supplier
        {
            public static class Name
            {
                public static readonly Error TooLong = new(
                    "Name.TooLong",
                    $"The supplier name cannot be longer than {Domain.Entities.Supplier.Constants.NameMaxLength} characters."
                );
            }

            public static class Address
            {
                public static readonly Error TooLong = new(
                    "Address.TooLong",
                    $"The supplier address cannot be longer than {Domain.Entities.Supplier.Constants.AddressMaxLength} characters."
                );
            }

            public static class Description
            {
                public static readonly Error TooLong = new(
                    "Description.TooLong",
                    $"The supplier description cannot be longer than {Domain.Entities.Supplier.Constants.DescriptionMaxLength} characters."
                );
            }
        }

        public static class Prescription
        {
            public static class Notes
            {
                public static readonly Error TooLong = new(
                    "Notes.TooLong",
                    $"The prescription notes cannot be longer than{Domain.Entities.Prescription.Constants.NotesMaxLength} characters.");
            }

            public static class Item
            {
                public static readonly Error NotFound = new(
                    "Item.NotFound",
                    "Prescription Item not found.");

                public static readonly Error MedicineWithTheSameNameAlreadyExists = new(
                    "Item.MedicineWithTheSameNameAlreadyExists",
                    "There is already a medicine with the same name.");
            }
        }

        public static class Material
        {
            public static class Name
            {
                public static readonly Error Empty = new(
                    "Name.Empty",
                    "The material name cannot be empty."
                );

                public static readonly Error TooLong = new(
                    "Name.TooLong",
                    $"The material name cannot be longer than {Domain.Entities.Material.Constants.NameMaxLength} characters."
                );
            }

            public static class ReorderLevel
            {
                public static readonly Error Negative = new(
                    "ReorderLevel.Negative",
                    "The reorder level cannot be negative."
                );
            }

            public static class Quantity
            {
                public static readonly Error Negative = new(
                    "Quantity.Negative",
                    "The quantity cannot be negative."
                );
            }

            public static class Price
            {
                public static readonly Error Negative = new(
                    "Price.Negative",
                    "The price cannot be negative."
                );
            }
        }

        public static class DentalInfo
        {
            public static readonly Error DoctorNameTooLong = new(
                "DentalInfo.DoctorNameTooLong",
                $"The doctor name cannot be longer than {Domain.Entities.DentalInfo.Constants.DoctorNameMaxLength} characters."
            );

            public static readonly Error DentalDescriptionTooLong = new(
                "DentalInfo.DentalDescriptionTooLong",
                $"The dental description cannot be longer than {Domain.Entities.DentalInfo.Constants.DentalDescriptionMaxLength} characters."
            );

            public static readonly Error PhoneNumberTooLong = new(
                "DentalInfo.PhoneNumberTooLong",
                $"The phone number cannot be longer than {Domain.Entities.DentalInfo.Constants.PhoneNumberMaxLength} characters."
            );

            public static readonly Error DentalPicturePathTooLong = new(
                "DentalInfo.DentalPicturePathTooLong",
                $"The dental picture path cannot be longer than {Domain.Entities.DentalInfo.Constants.DentalPicturePathMaxLength} characters."
            );

            public static readonly Error DoctorPicturePathTooLong = new(
                "DentalInfo.DoctorPicturePathTooLong",
                $"The doctor picture path cannot be longer than {Domain.Entities.DentalInfo.Constants.DoctorPicturePathMaxLength} characters."
            );

            public static readonly Error DentalNameTooLong = new(
                "DentalInfo.DentalNameTooLong",
                $"The dental name cannot be longer than {Domain.Entities.DentalInfo.Constants.DentalNameMaxLength} characters."
            );
        }

        public static class LabTransaction
        {
            public static class LabName
            {
                public static readonly Error Empty = new(
                    "LabName.Empty",
                    "The lab name cannot be empty.");
                public static readonly Error TooLong = new(
                    "LabName.TooLong",
                    $"The lab name cannot be longer than {Domain.Entities.LabTransaction.Constants.LabNameMaxLength} characters."
                );
            }
            public static class Treatments
            {
                public static readonly Error TooLong = new(
                    "Treatments.TooLong",
                    $"The treatments cannot be longer than {Domain.Entities.LabTransaction.Constants.TreatmentsMaxLength} characters."
                );
            }
        }

        public static class VisitPayment
        {
            public static class PaidAmount
            {
                public static readonly Error CanNotBeZero = new(
                    "PaidAmount.CanNotBeZero",
                    "Paid amount must be a positive value.");
            }
        }

        public static class VisitRadioghraph
        {
            public static class ImagePath
            {
                public static readonly Error Empty = new(
                    "ImagePath.Empty",
                    "The image path cannot be empty.");
                public static readonly Error TooLong = new(
                    "ImagePath.TooLong",
                    $"The image path cannot be longer than {Domain.Entities.VisitRadiograph.Constants.ImagePathMaxLength} characters."
                );
            }
        }
    }

    public static class ValueObjects
    {
        public static class Id
        {
            public static readonly Error LessThanOrEqualToZero = new(
                "Id.LessThanOrEqualToZero",
                "The value of the Id must be positive.");
        }

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
                $"The first name cannot be longer than {Domain.ValueObjects.FirstName.MaxLength} characters."
            );
        }

        public static class LastName
        {
            public static readonly Error Empty = new(
                "LastName.Empty",
                "The last name cannot be empty.");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                $"The last name cannot be longer than {Domain.ValueObjects.LastName.MaxLength} characters."
            );
        }

        public static class PhoneNumber
        {
            public static readonly Error Empty = new(
                "PhoneNumber.Empty",
                "The phone number cannot be empty."
            );

            public static readonly Error InvalidLength = new(
                "PhoneNumber.InvalidLength",
                $"Phone number length must be exact {Domain.ValueObjects.PhoneNumber.Length} character length.");
        }

        public static class ToothNumber
        {
            public static readonly Error OutOfRange = new(
                "ToothNumber.OutOfRange",
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
}