using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.DentalInfo;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public sealed class DentalInfoService(
    IDentalInfoRepository repo, 
    IUnitOfWork unitOfWork, 
    ILogger<DentalInfoService> logger) : 
    IDentalInfoService
{
    public async Task<Result<DentalInfoDto>> UpdateAsync(
        DentalInfoDto dto, 
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("DentalInfoService.UpdateAsync is called. {dto}", dto);
        var createResult = DentalInfo.Create(
            dto.DoctorName,
            dto.DentalDescription,
            dto.PhoneNumber,
            dto.PicturePath);
        if (createResult.IsFailure)
        {
            logger.LogWarning("Failed to create a DentalInfo. {Error}", createResult.Error);
            return Result.Failure<DentalInfoDto>(createResult.Error);
        }

        var existingEntity = await repo.GetAsync(cancellationToken);
        if (existingEntity is null)
        {
            logger.LogCritical("Entity Not found. {Id}", 1);
            return Result.Failure<DentalInfoDto>(ServiceErrors.NotFound);
        }

        var updatedResult = existingEntity.Update(
            createResult.Value.DoctorName,
            createResult.Value.DentalDescription,
            createResult.Value.PhoneNumber,
            createResult.Value.PicturePath);

        if (updatedResult.IsFailure)
        {
            logger.LogWarning("Failed to update entity due to domain validation. {Erorr}",
                updatedResult.Error);
            return Result.Failure<DentalInfoDto>(updatedResult.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation("DentalInfo updated successfully. {UpdatedEntity}", createResult.Value);

        return Result.Success(new DentalInfoDto(
            createResult.Value.DoctorName,
            createResult.Value.DentalDescription,
            createResult.Value.PhoneNumber,
            createResult.Value.PicturePath));
    }

    public async Task<Result<DentalInfoDto>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        var entity = await repo.GetAsync(cancellationToken);
        if (entity is null)
        {
            logger.LogCritical("Entity Not found. {Id}", 1);
            return Result.Failure<DentalInfoDto>(ServiceErrors.NotFound);
        }

        return Result.Success(new DentalInfoDto(
            entity.DoctorName,
            entity.DentalDescription,
            entity.PhoneNumber,
            entity.PicturePath));
    }
}