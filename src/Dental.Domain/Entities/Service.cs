using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class Service : Entity
{
    public static class Constants
    {
        public const int DescriptionMaxLength = 500;
        public const int NameMaxLength = 100;
    }

    private Service(
        string name,
        Money price,
        string? description = null)
    {
        Name = name;
        Price = price;
        Description = description;
    }

    private Service() { } // EF Core

    public string Name { get; private set; }

    public Money Price { get; private set; } = default!;

    public string? Description { get; private set; }
    public ICollection<VisitToothTreatment> VisitToothTreatments { get; private set; } = [];

    public static Result<Service> Create(
        string name,
        Money price,
        string? description = null)
    {
        if (!string.IsNullOrWhiteSpace(description)
            && description.Length > Constants.DescriptionMaxLength)
        {
            return Result.Failure<Service>(DomainErrors.Entities.Services.Description.TooLong);
        }

        return new Service(name, price, description?.Trim());
    }

    public Result Update(
        string name,
        Money price,
        string? description = null)
    {
        if (!string.IsNullOrWhiteSpace(description)
            && description.Length > Constants.DescriptionMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.Services.Description.TooLong);
        }

        Name = name;
        Price = price;
        Description = description?.Trim();

        return Result.Success();
    }
}