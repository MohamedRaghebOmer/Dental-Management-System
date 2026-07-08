using Dental.Domain.Entities;
using Dental.Domain.Shared;

namespace Dental.Domain.Errors;

public static class DomainErrors
{
    public static class Services
    {
        public static class ServiceName
        {
            public static readonly Error Empty = new(
                "ServiceName.Empty",
                "The service name cannot be empty.");

            public static readonly Error TooLong = new(
                "ServiceName.TooLong",
                $"The service name cannot be longer than {Service.NameMaxLength} characters."
            );
        }

        public static class Money
        {
            public static readonly Error NonPositiveValue = new(
                "Money.NonPositiveValue",
                "Money value cannot be zero or negative.");
        }

        public static class Description
        {
            public static readonly Error TooLong = new(
                "Description.TooLong",
                $@"The description cannot be longer than {Entities.Service.DescriptionMaxLength} characters."
            );
        }
    }

    public static class Patients
    {
        public static class FirstName
        {
            public static readonly Error Empty = new(
                "FirstName.Empty",
                "The first name cannot be empty.");

            public static readonly Error TooLong = new(
                "FirstName.TooLong",
                $"The first name cannot be longer than {Entities.Patient.Constants.FirstNameMaxLength} characters."
            );
        }

        public static class LastName
        {
            public static readonly Error Empty = new(
                "LastName.Empty",
                "The last name cannot be empty.");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                $"The last name cannot be longer than {Entities.Patient.Constants.LastNameMaxLength} characters."
            );
        }

        public static class DateOfBirth
        {
            public static readonly Error LessThanMinimumAllowedAge = new(
                "DateOfBirth.LessThanMinimumAllowedAge",
                $"The date of birth cannot be less than {ValueObjects.DateOfBirth.MinimumAge} years.");

            public static readonly Error OlderThanMaximumAllowedAge = new(
                "DateOfBirth.OlderThanMaximumAllowedAge",
                $"The date of birth cannot be longer than {ValueObjects.DateOfBirth.MaximumAge} years."
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
                $"The phone number must be {Entities.Patient.Constants.PhoneNumberLength} characters long."
            );
        }
    }
}