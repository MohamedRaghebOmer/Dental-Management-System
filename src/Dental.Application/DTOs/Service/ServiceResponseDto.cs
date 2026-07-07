namespace Dental.Application.DTOs.Responses;

public sealed record ServiceResponseDto(
    int Id,
    string Name,
    decimal Price,
    string? Description)
{
    public ServiceResponseDto(Domain.Entities.Service service)
        : this(service.Id,
            service.Name.Value,
            service.Price.Value,
            service.Description)
    {
    }
}