using Dental.Domain.Enums;
using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;

namespace Dental.Domain.Entities;

public sealed class Material : Entity
{
    private Material() { } // EF Core

    private Material(
        string name,
        decimal quantity,
        decimal reorderLevel,
        decimal price)
    {
        Name = name;
        Quantity = quantity;
        ReorderLevel = reorderLevel;
        Price = price;
    }

    public static class Constants
    {
        public const int NameMaxLength = 50;
    }

    public string Name { get; private set; } = string.Empty;
    public decimal Quantity { get; private set; }
    public decimal ReorderLevel { get; private set; }
    public decimal Price { get; private set; }
    public MaterialStatus Status
    {
        get
        {
            if (Quantity <= 0)
            {
                return MaterialStatus.OutOfStock;
            }
            else if (Quantity <= ReorderLevel)
            {
                return MaterialStatus.LowStock;
            }
            else
            {
                return MaterialStatus.Available;
            }
        }
    }

    public static Result<Material> Create(
        string name,
        decimal quantity,
        decimal reorderLevel,
        decimal price)
    {
        name = name.Trim();

        var validationResult = Validate(
            name,
            quantity,
            reorderLevel,
            price);
        if (validationResult.IsFailure)
        {
            return Result.Failure<Material>(validationResult.Error);
        }

        return new Material(
            name,
            quantity,
            reorderLevel,
            price);
    }

    public Result Update(
        string name,
        decimal quantity,
        decimal reorderLevel,
        decimal price)
    {
        name = name.Trim();

        var validationResult = Validate(
            name,
            quantity,
            reorderLevel,
            price);
        if (validationResult.IsFailure)
        {
            return Result.Failure<Material>(validationResult.Error);
        }

        Name = name;
        Quantity = quantity;
        ReorderLevel = reorderLevel;
        Price = price;

        return Result.Success();
    }

    private static Result Validate(
        string name,
        decimal quantity,
        decimal reorderLevel,
        decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure(DomainErrors.Entities.Material.Name.Empty);
        }

        if (name.Length > Constants.NameMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.Material.Name.TooLong);
        }

        if (quantity < 0)
        {
            return Result.Failure(DomainErrors.Entities.Material.Quantity.Negative);
        }

        if (reorderLevel < 0)
        {
            return Result.Failure(DomainErrors.Entities.Material.ReorderLevel.Negative);
        }

        if (price < 0)
        {
            return Result.Failure(DomainErrors.Entities.Material.Price.Negative);
        }

        return Result.Success();
    }
}