using Dental.Application.Errors;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Abstractions;

public abstract class ServiceBase<TEntity, TResponseDto>(
    IRepository<TEntity> prescriptionItemRepo,
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

        var entity = await prescriptionItemRepo.GetByIdAsync(id, cancellationToken);

        if (entity is null)
        {
            return Result.Failure<TResponseDto>(ServiceErrors.NotFound);
        }

        return TResponseDto.ToResponseDto(entity);
    }


    public async Task<Result<IEnumerable<TResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var services = await prescriptionItemRepo.GetAllAsync(cancellationToken);

        var dtos =
            services.Select(TResponseDto.ToResponseDto);

        if (dtos is null || !dtos.Any())
        {
            logger.LogWarning(
                "No data found in the database table of type {EntityType}.",
                typeof(TEntity).Name);

            return Result.Failure<IEnumerable<TResponseDto>>
                (ServiceErrors.EmptyDataset);
        }

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

        var entity = await prescriptionItemRepo.GetByIdAsync(id, cancellationToken);

        if (entity is null)
        {
            return Result.Failure(ServiceErrors.NotFound);
        }

        await prescriptionItemRepo.DeleteAsync(id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}