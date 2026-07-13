using System.ComponentModel.DataAnnotations;
using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class Material : Entity
{
    private Material() { } // EF Core

    private Material(
        string name,
        Id? supplierId,
        int reorderLevel,
        string? description,
        int quantity,
        decimal buyingPrice)
    {
        Name = name;
        SupplierId = supplierId;
        ReorderLevel = reorderLevel;
        Description = description;
        Quantity = quantity;
        BuyingPrice = buyingPrice;
    }

    public static class Constants
    {
        public const int NameMaxLength = 50;
        public const int UnitMaxLength = 20;
        public const int DescriptionMaxLength = 500;
    }

    public string Name { get; private set; } = string.Empty;
    public Id? SupplierId { get; private set; }
    public int ReorderLevel { get; private set; }
    public string? Description { get; private set; } = null;
    public int Quantity { get; private set; }
    public decimal BuyingPrice { get; private set; }

    public Supplier? Supplier { get; private set; } = null;

    public static Result<Material> Create(
        string name, 
        Id? supplierId, 
        int reorderLevel, 
        string? description, 
        int quantity, 
        decimal buyingPrice)
    {
        var validationResult = Validate(
            name,
            reorderLevel,
            description,
            quantity,
            buyingPrice);
        if (validationResult.IsFailure)
        {
            return Result.Failure<Material>(validationResult.Error);
        }

        return new Material(
            name.Trim(), 
            supplierId, 
            reorderLevel, 
            description?.Trim(), 
            quantity, 
            buyingPrice);
    }

    public Result Update(
        string name,
        Id? supplierId,
        int reorderLevel,
        string? description,
        int quantity,
        decimal buyingPrice)
    {
        var validationResult = Validate(
            name,
            reorderLevel,
            description,
            quantity,
            buyingPrice);
        if (validationResult.IsFailure)
        {
            return Result.Failure<Material>(validationResult.Error);
        }

        Name = name;
        SupplierId = supplierId;
        ReorderLevel = reorderLevel;
        Description = description;
        Quantity = quantity;
        BuyingPrice = buyingPrice;

        return Result.Success();
    }

    private static Result Validate(
        string name, 
        int reorderLevel, 
        string? description, 
        int quantity, 
        decimal buyingPrice)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure(DomainErrors.Entities.Material.Name.Empty);
        }

        if (name.Trim().Length > Constants.NameMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.Material.Name.TooLong);
        }

        if (reorderLevel < 0)
        {
            return Result.Failure(DomainErrors.Entities.Material.ReorderLevel.Negative);
        }

        if (description is not null && description?.Trim().Length > Constants.DescriptionMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.Material.Description.TooLong);
        }

        if (quantity < 0)
        {
            return Result.Failure(DomainErrors.Entities.Material.Quantity.Negative);
        }

        if (buyingPrice < 0)
        {
            return Result.Failure(DomainErrors.Entities.Material.BuyingPrice.Negative);
        }

        return Result.Success();
    }
}