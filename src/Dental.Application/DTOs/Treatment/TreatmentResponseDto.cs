using Dental.Application.Abstractions;

namespace Dental.Application.DTOs.Treatment;

public sealed record TreatmentResponseDto(
    int Id,
    string Name,
    decimal Price,
    string? Description)
    : IResponseDto<Domain.Entities.Treatment, TreatmentResponseDto>
{

    public static TreatmentResponseDto ToResponseDto(Domain.Entities.Treatment entity)
    {
        return new TreatmentResponseDto(
            Id: entity.Id.Value,
            Name: entity.Name,
            Price: entity.Price.Value,
            Description: entity.Description
        );
    }
}