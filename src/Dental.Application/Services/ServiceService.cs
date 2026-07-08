using Dental.Application.Abstractions;
using Dental.Application.DTOs.Responses;
using Dental.Application.DTOs.Service;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public class ServiceService(
    IRepository<Service> repo,
    IUnitOfWork unitOfWork,
    ILogger<ServiceService> logger)
    : ServiceBase<Service, ServiceResponseDto>(repo, unitOfWork, logger)
{
    public async Task<Result<int>> CreateServiceAsync(
        CreateServiceDto? dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Creating new service.");

        if (dto is null)
        {
            logger.LogWarning("Attempted to create a service with null data.");
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

        await repo.AddAsync(serviceResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Service created successfully.");

        return Result.Success(serviceResult.Value.Id);
    }

    public async Task<Result<ServiceResponseDto>> UpdateServiceAsync(
        int id,
        UpdateServiceDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Updating service.");

        if (id <= 0)
        {
            logger.LogWarning("Attempted to update a service with an invalid ID.");
            return Result.Failure<ServiceResponseDto>(ServiceErrors.InvalidId);
        }

        var service = await repo.GetByIdAsync(id, cancellationToken);

        if (service is null)
        {
            logger.LogWarning("Service not found.");
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
        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Service updated successfully.");

        return new ServiceResponseDto(service);
    }
}