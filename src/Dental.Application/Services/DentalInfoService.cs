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
    private readonly ILogger<DentalInfoService> _logger;

    public DentalInfoService(
        IDentalInfoRepository repo,
        ILogger<DentalInfoService> logger)
    {
        _repo = repo;
        _logger = logger;
    }


    public async Task<Result> SetAsync(
        DentalInfoDto dto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("DentalInfoService.SetAsync is called. {dto}", dto);
        var createResult = DentalInfo.Create(
            dto.DoctorName,
            dto.PhoneNumber,
            dto.DoctorPicturePath,
            dto.DentalName,
            dto.DentalDescription,
            dto.DentalPicturePath);
        if (createResult.IsFailure)
        {
            _logger.LogWarning("Failed to create a DentalInfo. {Error}", createResult.Error);
            return Result.Failure(createResult.Error);
        }

        try
        {
            await _repo.SetAsync(createResult.Value, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while setting dental info.");
            return Result.Failure(ServiceErrors.Common.UnexpectedError);
        }

        return Result.Success();
    }

    public async Task<DentalInfoDto> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return DentalInfoDto.FromEntity(await _repo.GetAsync(cancellationToken));
    }
}