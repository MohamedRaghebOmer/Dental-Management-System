using Dental.Application.Abstractions;

namespace Dental.Application.DTOs.Responses;

public sealed record ServiceResponseDto(
    int Id,
    string Name,
    decimal Price,
    string? Description)
    : IResponseDto<Domain.Entities.Treatment, ServiceResponseDto>
{
    public ServiceResponseDto(Domain.Entities.Treatment treatment)
        : this(treatment.Id,
            treatment.Name,
            treatment.Price.Value,
            treatment.Description)
    {
    }

    public static ServiceResponseDto ToResponseDto(Domain.Entities.Treatment entity)
    {
        return new ServiceResponseDto(entity);
    }
}