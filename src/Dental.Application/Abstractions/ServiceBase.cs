using Dental.Application.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Abstractions;

public abstract class ServiceBase<TEntity, TResponseDto>
    where TEntity : Entity
    where TResponseDto : IResponseDto<TEntity, TResponseDto>
{
    private readonly IRepository<TEntity> _repo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ServiceBase<TEntity, TResponseDto>> _logger;

    public ServiceBase(
        IRepository<TEntity> repo,
        IUnitOfWork unitOfWork,
        ILogger<ServiceBase<TEntity, TResponseDto>> logger)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<TResponseDto>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var idResult = Id.Create(id);
        if (idResult.IsFailure)
        {
            _logger.LogWarning(
                "Attempted to retrieve an entity of type {EntityType} with an invalid ID." +
                " {Id} {Error}", typeof(TEntity).Name, id, idResult.Error);

            return Result.Failure<TResponseDto>(idResult.Error);
        }

        var entity = await _repo.GetByIdAsync(idResult.Value, cancellationToken);
        if (entity is null)
        {
            return Result.Failure<TResponseDto>(ServiceErrors.NotFound);
        }

        return TResponseDto.ToResponseDto(entity);
    }

    public async Task<Result<bool>> ExistsAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var idResult = Id.Create(id);
        if (idResult.IsFailure)
        {
            _logger.LogWarning("Attempted to check the existence of entity of type {TEntity} with invalid Id. {Id} {Error}", typeof(TEntity).Name, id, idResult.Error);
            return Result.Failure<bool>(idResult.Error);
        }

        return await _repo.ExistsAsync(idResult.Value, cancellationToken);
    }

    public async Task<List<TResponseDto>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var all = await _repo.GetAllAsync(cancellationToken);
        return all.Select(TResponseDto.ToResponseDto).ToList();
    }

    public async Task<Result> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var idResult = Id.Create(id); 
        if (idResult.IsFailure)
        {
            _logger.LogWarning(
                "Attempted to delete an entity of type {EntityType} with an invalid ID." +
                "{Id} {Error}", typeof(TEntity).Name, id, idResult.Error);
            return Result.Failure(ServiceErrors.InvalidId);
        }

        var isDeleted = await _repo.RemoveAsync(idResult.Value, cancellationToken);
        if (!isDeleted)
        {
            return Result.Failure(ServiceErrors.NotFound);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}