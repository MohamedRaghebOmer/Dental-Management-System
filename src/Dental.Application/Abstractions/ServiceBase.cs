using Dental.Application.Errors;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Abstractions;

public abstract class ServiceBase<TEntity, TResponseDto>(
    IRepository<TEntity> repo,
    IUnitOfWork unitOfWork,
    ILogger<ServiceBase<TEntity, TResponseDto>> logger)
    where TEntity : Entity
    where TResponseDto : IResponseDto<TEntity, TResponseDto>
{
    public async Task<Result<TResponseDto>> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        if (id <= 0)
        {
            logger.LogWarning(
                "Attempted to retrieve an entity of type {EntityType} with an invalid ID.",
                typeof(TEntity).Name);

            return Result.Failure<TResponseDto>(ServiceErrors.InvalidId);
        }

        var entity = await repo.GetByIdAsync(id, cancellationToken);

        if (entity is null)
        {
            return Result.Failure<TResponseDto>(ServiceErrors.NotFound);
        }

        return TResponseDto.ToResponseDto(entity);
    }


    public async Task<Result<IEnumerable<TResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var all = await repo.GetAllAsync(cancellationToken);

        var dtos = all.Select(TResponseDto.ToResponseDto);

        return Result.Success(dtos);
    }


    public async Task<Result> DeleteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        if (id <= 0)
        {
            logger.LogWarning(
                "Attempted to delete an entity of type {EntityType} with an invalid ID.",
                typeof(TEntity).Name);

            return Result.Failure(ServiceErrors.InvalidId);
        }

        var entity = await repo.GetByIdAsync(id, cancellationToken);

        if (entity is null)
        {
            return Result.Failure(ServiceErrors.NotFound);
        }

        await repo.DeleteAsync(id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}