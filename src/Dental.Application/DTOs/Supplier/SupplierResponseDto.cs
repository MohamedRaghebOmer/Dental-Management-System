using Dental.Application.Abstractions;

namespace Dental.Application.DTOs.Supplier;

public sealed record SupplierResponseDto(
    string Name,
    string? PhoneNumber,
    string? Address,
    string? Description)
    : IResponseDto<Domain.Entities.Supplier, SupplierResponseDto>
{
    public static SupplierResponseDto ToResponseDto(Domain.Entities.Supplier entity)
    {
        return new SupplierResponseDto(
            Name: entity.Name,
            PhoneNumber: entity.PhoneNumber?.Value,
            Address: entity.Address,
            Description: entity.Description
        );
    }
}