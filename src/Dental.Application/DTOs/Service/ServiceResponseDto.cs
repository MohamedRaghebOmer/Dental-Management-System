using Dental.Application.Abstractions;

namespace Dental.Application.DTOs.Responses;

public sealed record ServiceResponseDto(
    int Id,
    string Name,
    decimal Price,
    string? Description)
    : IResponseDto<Domain.Entities.Service, ServiceResponseDto>
{
    public ServiceResponseDto(Domain.Entities.Service service)
        : this(service.Id,
            service.Name,
            service.Price.Value,
            service.Description)
    {
    }

    public static ServiceResponseDto ToResponseDto(Domain.Entities.Service entity)
    {
        return new ServiceResponseDto(entity);
    }
}