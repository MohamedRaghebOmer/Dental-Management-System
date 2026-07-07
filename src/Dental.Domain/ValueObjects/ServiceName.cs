using Dental.Domain.Entities;
using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;

namespace Dental.Domain.ValueObjects;

public record ServiceName : ValueObject
{
    public string Value { get; } = string.Empty;

    private ServiceName() { } // EF Core

    public ServiceName(string value)
    {
        Value = value;
    }

    public static Result<ServiceName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<ServiceName>(DomainErrors.Services.ServiceName.Empty);
        }

        if (value.Length > Service.NameMaxLength)
        {
            return Result.Failure<ServiceName>(DomainErrors.Services.ServiceName.TooLong);
        }

        return new ServiceName(value);
    }
}