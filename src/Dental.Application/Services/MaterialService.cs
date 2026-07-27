using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Material;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Dental.Domain.Views.Material;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public sealed class MaterialService
    : ServiceBase<Material, MaterialResponseDto>,
    IMaterialService
{
    private readonly IMaterialRepository _repo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<MaterialService> _logger;

    public MaterialService(
        IMaterialRepository repo,
        IUnitOfWork unitOfWork,
        ILogger<MaterialService> logger) : base(repo, unitOfWork, logger)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<int>> CreateAsync(
        MaterialRequestDto requestDto,
        CancellationToken cancellationToken = default)
    {
        var entityResult = await BuildEntityAsync(requestDto, cancellationToken);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        _repo.Add(entityResult.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(entityResult.Value.Id.Value);
    }

    public async Task<Result> UpdateAsync(
        int materialId,
        MaterialRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        var createIdResult = Id.Create(materialId);
        if (createIdResult.IsFailure)
        {
            _logger.LogWarning("Invalid MaterialId {Id} {Error}", materialId, createIdResult.Error);
            return Result.Failure(createIdResult.Error);
        }

        var entityResult = await BuildEntityAsync(dto, cancellationToken, materialId);
        if (entityResult.IsFailure)
        {
            return Result.Failure(entityResult.Error);
        }

        var existingEntity = await _repo.GetByIdAsync(createIdResult.Value, cancellationToken);
        if (existingEntity == null)
        {
            _logger.LogWarning("Material with ID {MaterialId} not found.", materialId);
            return Result.Failure(ServiceErrors.Common.NotFound);
        }

        var updatedEntity = entityResult.Value.Update(
            entityResult.Value.Name,
            entityResult.Value.Quantity,
            entityResult.Value.ReorderLevel,
            entityResult.Value.Price);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public Task<List<MaterialFilterDto>> FilterAsync(
        MaterialFilterDto? filterDto = null, 
        CancellationToken cancellationToken = default)
    {
        return _repo.FilterAsync(filterDto, cancellationToken);
    }

    private async Task<Result<Material>> BuildEntityAsync(
        MaterialRequestDto requestDto,
        CancellationToken cancellationToken,
        int? materialId = null)
    {
        Result<Id>? createIdResult = null;
        if (materialId.HasValue)
        {
            createIdResult = Id.Create(materialId.Value);
            if (createIdResult.IsFailure)
            {
                _logger.LogWarning("Invalid Id. {Id} {Error}", materialId.Value, createIdResult.Value);
                return Result.Failure<Material>(createIdResult.Error);
            }
        }

        if (await _repo.ExistsByNameAsync(requestDto.Name, createIdResult?.Value, cancellationToken))
        {
            _logger.LogWarning("Material with name {Name} already exists.", requestDto.Name);
            return Result.Failure<Material>(ServiceErrors.Material.DuplicateName);
        }

        var entityResult = Material.Create(
            requestDto.Name,
            requestDto.Quantity,
            requestDto.ReorderLevel,
            requestDto.Price);

        if (entityResult.IsFailure)
        {
            _logger.LogWarning("Failed to create material entity. {Error}", entityResult.Error);
            return Result.Failure<Material>(entityResult.Error);
        }

        return Result.Success(entityResult.Value);
    }
}