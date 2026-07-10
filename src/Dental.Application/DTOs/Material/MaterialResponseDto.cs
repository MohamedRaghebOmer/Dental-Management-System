using Dental.Application.Abstractions;

namespace Dental.Application.DTOs.Material;

public sealed record MaterialResponseDto(
    int Id,
    string Name,
    int? SupplierId,
    string? Description,
    int Quantity,
    decimal BuyingPrice) 
    : IResponseDto<Domain.Entities.Material, MaterialResponseDto>
{
    public static MaterialResponseDto ToResponseDto(Domain.Entities.Material entity)
    {
        return new MaterialResponseDto(
            entity.Id,
            entity.Name,
            entity.SupplierId?.Value,
            entity.Description,
            entity.Quantity,
            entity.BuyingPrice
        );
    }
}