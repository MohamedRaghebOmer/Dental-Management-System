using Dental.Application.DTOs.Responses;
using Dental.Application.DTOs.Service;
using Dental.Application.Interfaces;
using Dental.Domain.Entities;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _repo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ServiceService> _logger;

    public ServiceService(
        IServiceRepository repo,
        IUnitOfWork unitOfWork,
        ILogger<ServiceService> logger)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<int>> CreateServiceAsync(
        CreateServiceDto? dto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Creating new service.");

        if (dto is null)
        {
            _logger.LogWarning("Attempted to create a service with null data.");
            return Result.Failure<int>(ServiceErrors.ParameterNullReference);
        }

        var nameResult = ServiceName.Create(dto.Name);
        if (!nameResult.IsSuccess)
        {
            return Result.Failure<int>(nameResult.Error);
        }

        var priceResult = Money.Create(dto.Price);
        if (!priceResult.IsSuccess)
        {
            return Result.Failure<int>(priceResult.Error);
        }

        var serviceResult =
            Service.Create(
                nameResult.Value,
                priceResult.Value,
                dto.Description);

        if (!serviceResult.IsSuccess)
        {
            return Result.Failure<int>(serviceResult.Error);
        }

        await _repo.AddServiceAsync(serviceResult.Value, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Service created successfully.");

        return Result.Success(serviceResult.Value.Id);
    }

    public async Task<Result<ServiceResponseDto?>> GetServiceByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        if (id <= 0)
        {
            _logger.LogWarning("Attempted to retrieve a service with an invalid ID.");
            return Result.Failure<ServiceResponseDto?>(ServiceErrors.InvalidId);
        }

        var service = await _repo.GetServiceByIdAsync(id, cancellationToken);

        if (service is null)
        {
            _logger.LogWarning("Service not found.");
            return Result.Failure<ServiceResponseDto?>(ServiceErrors.NotFound);
        }

        return new ServiceResponseDto(service);
    }

    public async Task<Result<IEnumerable<ServiceResponseDto>>> ListServicesAsync(
        CancellationToken cancellationToken = default)
    {
        var services = await _repo.ListServicesAsync(cancellationToken);

        var serviceDos =
            services.Select(s => new ServiceResponseDto(s));

        if (serviceDos is null || !serviceDos.Any())
        {
            _logger.LogWarning("No services found in the database.");
            return Result.Failure<IEnumerable<ServiceResponseDto>>
                (ServiceErrors.EmptyDataset);
        }

        return Result.Success(serviceDos!);
    }

    public async Task<Result<ServiceResponseDto>> UpdateServiceAsync(
        UpdateServiceDto dto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating service.");

        if (dto.Id <= 0)
        {
            _logger.LogWarning("Attempted to update a service with an invalid ID.");
            return Result.Failure<ServiceResponseDto>(ServiceErrors.InvalidId);
        }

        var service = await _repo.GetServiceByIdAsync(dto.Id, cancellationToken);

        if (service is null)
        {
            _logger.LogWarning("Service not found.");
            return Result.Failure<ServiceResponseDto>(ServiceErrors.NotFound);
        }

        var name = ServiceName.Create(dto.Name);
        if (!name.IsSuccess)
        {
            return Result.Failure<ServiceResponseDto>(name.Error);
        }

        var price = Money.Create(dto.Price);
        if (!price.IsSuccess)
        {
            return Result.Failure<ServiceResponseDto>(price.Error);
        }

        var updateResult = service.Update(name.Value, price.Value, dto.Description);
        if (!updateResult.IsSuccess)
        {
            return Result.Failure<ServiceResponseDto>(updateResult.Error);
        }

        // Save changes
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Service updated successfully.");

        return new ServiceResponseDto(service);
    }

    public async Task<Result> DeleteServiceAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Deleting service.");

        if (id <= 0)
        {
            _logger.LogWarning("Attempted to delete a service with an invalid ID.");
            return Result.Failure(ServiceErrors.InvalidId);
        }

        var service = await _repo.GetServiceByIdAsync(id, cancellationToken);

        if (service is null)
        {
            _logger.LogWarning("Service not found.");
            return Result.Failure(ServiceErrors.NotFound);
        }

        await _repo.DeleteServiceAsync(service.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Service deleted successfully.");

        return Result.Success();
    }
}