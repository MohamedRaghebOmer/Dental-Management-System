using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Responses;
using Dental.Application.DTOs.Treatment;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public class TreatmentService(
    IRepository<Treatment> treatmentRepo,
    IUnitOfWork unitOfWork,
    ILogger<TreatmentService> logger)
    : ServiceBase<Treatment, ServiceResponseDto>(treatmentRepo, unitOfWork, logger)
    , ITreatmentService
{
    public async Task<Result<int>> CreateAsync(
        TreatmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("TreatmentService.CreateAsync is called. {TreatmentRequestDto}", dto);

        var entityResult = BuildEntity(dto);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        await treatmentRepo.AddAsync(entityResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Treatment created successfully.");

        return Result.Success(entityResult.Value.Id);
    }

    public async Task<Result> UpdateAsync(
        int id,
        TreatmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("TreatmentService.UpdateAsync is called. {TreatmentId} {TreatmentRequestDto}", id, dto);

        var updatedEntity = BuildEntity(dto, id);
        if (updatedEntity.IsFailure)
        {
            return Result.Failure(updatedEntity.Error);
        }

        var treatment = await treatmentRepo.GetByIdAsync(id, cancellationToken);
        if (treatment is null)
        {
            logger.LogWarning("Treatment not found.");
            return Result.Failure<Treatment>(ServiceErrors.NotFound);
        }

        var updateResult = treatment.Update(dto.Name, updatedEntity.Value.Price, dto.Description);
        if (updateResult.IsFailure)
        {
            return Result.Failure<Treatment>(updateResult.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Treatment updated successfully.");

        return Result.Success();
    }

    private Result<Treatment> BuildEntity(
        TreatmentRequestDto dto,
        int? id = null)
    {
        if (id <= 0)
        {
            logger.LogWarning("Attempted to update a treatment with an invalid ID.");
            return Result.Failure<Treatment>(ServiceErrors.InvalidId);
        }

        var priceResult = Money.Create(dto.Price);
        if (!priceResult.IsSuccess)
        {
            return Result.Failure<Treatment>(priceResult.Error);
        }

        var serviceResult =
            Treatment.Create(
                dto.Name,
                priceResult.Value,
                dto.Description);

        if (!serviceResult.IsSuccess)
        {
            return Result.Failure<Treatment>(serviceResult.Error);
        }

        return Result.Success(serviceResult.Value);
    }

}