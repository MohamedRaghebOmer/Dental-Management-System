using Dental.Application.Abstractions;
using Dental.Domain.Enums;

namespace Dental.Application.DTOs.Material;

public sealed record MaterialResponseDto(
    int Id,
    string Name,
    decimal Quantity,
    decimal ReorderLevel,
    decimal Price,
    MaterialStatus Status)
    : IResponseDto<Domain.Entities.Material, MaterialResponseDto>
{
    public static MaterialResponseDto ToResponseDto(Domain.Entities.Material entity)
    {
        return new MaterialResponseDto(
            entity.Id.Value,
            entity.Name,
            entity.Quantity,
            entity.ReorderLevel,
            entity.Price,
            entity.Status
        );
    }
}