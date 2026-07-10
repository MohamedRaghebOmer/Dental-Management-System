using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Material;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public sealed class MaterialService(
    IRepository<Material> repo,
    IMaterialRepository materialRepo,
    IUnitOfWork unitOfWork,
    ILogger<ServiceBase<Material, MaterialResponseDto>> logger)
    : ServiceBase<Material, MaterialResponseDto>(repo, unitOfWork, logger),
    IMaterialService
{
    public async Task<Result<int>> CreateAsync(
        MaterialRequestDto requestDto,
        CancellationToken cancellationToken = default)
    {
        var entityResult = await BuildEntityAsync(requestDto, cancellationToken);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        await repo.AddAsync(entityResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(entityResult.Value.Id);
    }

    public async Task<Result> UpdateAsync(
        int materialId,
        MaterialRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        var entityResult = await BuildEntityAsync(dto, cancellationToken, materialId);
        if (entityResult.IsFailure)
        {
            return Result.Failure(entityResult.Error);
        }

        var existingEntity = await repo.GetByIdAsync(materialId, cancellationToken);
        if (existingEntity == null)
        {
            logger.LogWarning("Material with ID {MaterialId} not found.", materialId);
            return Result.Failure(ServiceErrors.NotFound);
        }

        var updatedEntity = entityResult.Value.Update(
            entityResult.Value.Name,
            entityResult.Value.SupplierId,
            entityResult.Value.ReorderLevel,
            entityResult.Value.Description,
            entityResult.Value.Quantity,
            entityResult.Value.BuyingPrice);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    private async Task<Result<Material>> BuildEntityAsync(
        MaterialRequestDto requestDto,
        CancellationToken cancellationToken,
        int? materialId = null)
    {
        if (materialId <= 0)
        {
            logger.LogWarning("Invalid material ID. {MaterialId}", materialId);
            return Result.Failure<Material>(ServiceErrors.InvalidId);
        }

        Result<Id> supplierIdResult = null!;
        if (requestDto.SupplierId.HasValue)
        {
            supplierIdResult = Id.Create(requestDto.SupplierId.Value);
            if (supplierIdResult.IsFailure)
            {
                logger.LogWarning("Invalid supplier ID. {SupplierId}", requestDto.SupplierId);
                return Result.Failure<Material>(ServiceErrors.Material.InvalidSupplierId);
            }
        }

        if (await materialRepo.ExistsByNameAsync(requestDto.Name, materialId, cancellationToken))
        {
            logger.LogWarning("Material with name {Name} already exists.", requestDto.Name);
            return Result.Failure<Material>(ServiceErrors.Material.DuplicateName);
        }

        var entityResult = Material.Create(
            requestDto.Name,
            supplierIdResult?.Value,
            requestDto.ReorderLevel,
            requestDto.Description,
            requestDto.Quantity,
            requestDto.BuyingPrice);

        if (entityResult.IsFailure)
        {
            logger.LogWarning("Failed to create material entity. {Error}", entityResult.Error);
            return Result.Failure<Material>(entityResult.Error);
        }

        return Result.Success(entityResult.Value);
    }
}