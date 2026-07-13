using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Treatment;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public class TreatmentService(
    IRepository<Treatment> repo,
    ITreatmentRepository treatmentRepo,
    IUnitOfWork unitOfWork,
    ILogger<TreatmentService> logger)
    : ServiceBase<Treatment, TreatmentResponseDto>(repo, unitOfWork, logger)
    , ITreatmentService
{
    public async Task<Result<int>> CreateAsync(
        TreatmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("TreatmentService.CreateAsync is called. {TreatmentRequestDto}", dto);

        var entityResult = await BuildEntityAsync(dto, cancellationToken);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        await repo.AddAsync(entityResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Treatment created successfully.");

        return Result.Success(entityResult.Value.Id.Value);
    }

    public async Task<Result> UpdateAsync(
        int id,
        TreatmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("TreatmentService.UpdateAsync is called. {TreatmentId} {TreatmentRequestDto}", id, dto);

        var updatedEntity = await BuildEntityAsync(dto, cancellationToken, id);
        if (updatedEntity.IsFailure)
        {
            return Result.Failure(updatedEntity.Error);
        }

        var treatment = await repo.GetByIdAsync(id, cancellationToken);
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

    private async Task<Result<Treatment>> BuildEntityAsync(
        TreatmentRequestDto dto,
        CancellationToken cancellationToken,
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

        if (await treatmentRepo.ExistsByNameAsync(dto.Name.Trim(), id, cancellationToken))
        {
            logger.LogWarning("A treatment with the same name already exists.");
            return Result.Failure<Treatment>(ServiceErrors.Treatment.DuplicateName);
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

    public async Task<Result<List<TreatmentResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var all = await repo.GetAllAsync(cancellationToken);

        var dtos = 
            all.Select(TreatmentResponseDto.ToResponseDto).ToList();

        return Result.Success(dtos);
    }

}