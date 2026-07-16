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

public class TreatmentService
    : ServiceBase<Treatment, TreatmentResponseDto>
    , ITreatmentService
{
    private readonly ITreatmentRepository _treatmentRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TreatmentService> _logger;

    public TreatmentService(
        ITreatmentRepository treatmentRepo,
        IUnitOfWork unitOfWork,
        ILogger<TreatmentService> logger) : base(treatmentRepo, unitOfWork, logger)
    {
        _treatmentRepo = treatmentRepo;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<int>> CreateAsync(
        TreatmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("TreatmentService.CreateAsync is called. {TreatmentRequestDto}", dto);

        var entityResult = await BuildEntityAsync(dto, cancellationToken);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        _treatmentRepo.Add(entityResult.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Treatment created successfully.");

        return Result.Success(entityResult.Value.Id.Value);
    }

    public async Task<Result> UpdateAsync(
        int id,
        TreatmentRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("TreatmentService.UpdateAsync is called. {TreatmentId} {TreatmentRequestDto}", id, dto);

        var createIdResult = Id.Create(id);
        if (createIdResult.IsFailure)
        {
            _logger.LogWarning("Invalid Id. {Id} {Error}", id, createIdResult.Error);
            return Result.Failure(createIdResult.Error);
        }

        var updatedEntity = await BuildEntityAsync(dto, cancellationToken, createIdResult.Value);
        if (updatedEntity.IsFailure)
        {
            return Result.Failure(updatedEntity.Error);
        }

        var treatment = await _treatmentRepo.GetByIdAsync(createIdResult.Value, cancellationToken);
        if (treatment is null)
        {
            _logger.LogWarning("Treatment not found.");
            return Result.Failure<Treatment>(ServiceErrors.NotFound);
        }

        var updateResult = treatment.Update(dto.Name, updatedEntity.Value.Price, dto.Description);
        if (updateResult.IsFailure)
        {
            return Result.Failure<Treatment>(updateResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Treatment updated successfully.");

        return Result.Success();
    }

    private async Task<Result<Treatment>> BuildEntityAsync(
        TreatmentRequestDto dto,
        CancellationToken cancellationToken,
        Id? id = null)
    {
        var priceResult = Money.Create(dto.Price);
        if (!priceResult.IsSuccess)
        {
            return Result.Failure<Treatment>(priceResult.Error);
        }

        if (await _treatmentRepo.ExistsByNameAsync(dto.Name.Trim(), id, cancellationToken))
        {
            _logger.LogWarning("A treatment with the same name already exists.");
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
}