using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class Service : Entity
{
    public const int DescriptionMaxLength = 500;
    public const int NameMaxLength = ServiceName.MaxLength;

    private Service(
        ServiceName name,
        Money price,
        string? description = null)
    {
        Name = name;
        Price = price;
        Description = description;
    }

    private Service() { } // EF Core

    public ServiceName Name { get; private set; } = default!;

    public Money Price { get; private set; } = default!;

    public string? Description { get; private set; }

    public static Result<Service> Create(
        ServiceName name,
        Money price,
        string? description = null)
    {
        if (!string.IsNullOrWhiteSpace(description)
            && description.Length > DescriptionMaxLength)
        {
            return Result.Failure<Service>(DomainErrors.Services.Description.TooLong);
        }

        return new Service(name, price, description?.Trim());
    }

    public Result Update(
        ServiceName name,
        Money price,
        string? description = null)
    {
        if (!string.IsNullOrWhiteSpace(description)
            && description.Length > DescriptionMaxLength)
        {
            return Result.Failure(DomainErrors.Services.Description.TooLong);
        }

        Name = name;
        Price = price;
        Description = description?.Trim();

        return Result.Success();
    }
}