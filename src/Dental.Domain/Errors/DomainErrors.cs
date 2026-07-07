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
}