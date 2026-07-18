using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.DentalInfo;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public sealed class DentalInfoService : IDentalInfoService
{
    private readonly IDentalInfoRepository _repo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DentalInfoService> _logger;

    public DentalInfoService(
        IDentalInfoRepository repo,
        IUnitOfWork unitOfWork,
        ILogger<DentalInfoService> logger)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }


    public async Task<Result<DentalInfoDto>> UpdateAsync(
        DentalInfoDto dto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("DentalInfoService.UpdateAsync is called. {dto}", dto);
        var createResult = DentalInfo.Create(
            dto.DoctorName,
            dto.DentalDescription,
            dto.PhoneNumber,
            dto.PicturePath);
        if (createResult.IsFailure)
        {
            _logger.LogWarning("Failed to create a DentalInfo. {Error}", createResult.Error);
            return Result.Failure<DentalInfoDto>(createResult.Error);
        }

        var existingEntity = await _repo.GetAsync(cancellationToken);
        if (existingEntity is null)
        {
            _logger.LogCritical("Entity Not found. {Id}", 1);
            return Result.Failure<DentalInfoDto>(ServiceErrors.NotFound);
        }

        var updatedResult = existingEntity.Update(
            createResult.Value.DoctorName,
            createResult.Value.DentalDescription,
            createResult.Value.PhoneNumber,
            createResult.Value.PicturePath);

        if (updatedResult.IsFailure)
        {
            _logger.LogWarning("Failed to update entity due to domain validation. {Erorr}",
                updatedResult.Error);
            return Result.Failure<DentalInfoDto>(updatedResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("DentalInfo updated successfully. {UpdatedEntity}", createResult.Value);

        return Result.Success(new DentalInfoDto(
            createResult.Value.DoctorName,
            createResult.Value.DentalDescription,
            createResult.Value.PhoneNumber,
            createResult.Value.PicturePath));
    }

    public async Task<Result<DentalInfoDto>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        var entity = await _repo.GetAsync(cancellationToken);
        if (entity is null)
        {
            _logger.LogCritical("Entity Not found. {Id}", 1);
            return Result.Failure<DentalInfoDto>(ServiceErrors.NotFound);
        }

        return Result.Success(new DentalInfoDto(
            entity.DoctorName,
            entity.DentalDescription,
            entity.PhoneNumber,
            entity.PicturePath));
    }
}