using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.VisitRadioghraph;
using Dental.Application.Errors;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public sealed class VisitRadioghraphService : IVisitRadioghraphService
{
    private readonly IVisitRepository _visitRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<VisitRadioghraphService> _logger;

    public VisitRadioghraphService(
        IVisitRepository visitRepository,
        IUnitOfWork unitOfWork,
        ILogger<VisitRadioghraphService> logger)
    {
        _visitRepository = visitRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<VisitRadioghraphResponseDto>> GetByIdAsync(
        int visitRadioghrapId,
        CancellationToken cancellationToken = default)
    {
        var idResult = Id.Create(visitRadioghrapId);
        if (idResult.IsFailure)
        {
            _logger.LogWarning(
                "Invalid visit radiograph ID provided. {VisitRadiographId}", visitRadioghrapId);
            return Result.Failure<VisitRadioghraphResponseDto>(idResult.Error);
        }

        var radiograph = await _visitRepository.GetRadiographByIdAsync(
            idResult.Value, cancellationToken);
        if (radiograph is null)
        {
            _logger.LogWarning("Visit radiograph not found.");
            return Result.Failure<VisitRadioghraphResponseDto>(
                ServiceErrors.Common.NotFound);
        }

        return VisitRadioghraphResponseDto.ToResponseDto(radiograph);
    }

    public async Task<Result> UpdateAsync(
        int visitRadiographId,
        VisitRadioghraphRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        var visitRadiographIdResult = Id.Create(visitRadiographId);
        if (visitRadiographIdResult.IsFailure)
        {
            return Result.Failure(visitRadiographIdResult.Error);
        }

        var visitIdResult = Id.Create(dto.VisitId);
        if (visitIdResult.IsFailure)
        {
            return Result.Failure(visitIdResult.Error);
        }

        var visit = await _visitRepository.GetByIdAsync(
            visitIdResult.Value,
            cancellationToken);
        if (visit is null)
        {
            return Result.Failure(ServiceErrors.Common.NotFound);
        }

        var udpateResult = visit.UpdateVisitRadiograph(
            visitRadiographId: visitRadiographIdResult.Value,
            imagePath: dto.ImagePath);
        if (udpateResult.IsFailure)
        {
            return Result.Failure(udpateResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<Result> DeleteAsync(
        int radiographId,
        CancellationToken cancellationToken = default)
    {
        var idResult = Id.Create(radiographId);
        if (idResult.IsFailure)
        {
            _logger.LogWarning("Invalid radiograph ID provided. {RadiographId}", radiographId);
            return Result.Failure(idResult.Error);
        }

        var visit = await _visitRepository.GetByRadiographIdAsync(
            idResult.Value,
            cancellationToken);

        if (visit is null)
        {
            _logger.LogWarning("Visit containing radiograph not found. {RadiographId}", radiographId);
            return Result.Failure(ServiceErrors.Common.NotFound);
        }

        var removeResult = visit.RemoveVisitRadiograph(idResult.Value);
        if (removeResult.IsFailure)
        {
            _logger.LogWarning("Failed to remove radiograph. {RadiographId}, Error: {Error}", radiographId, removeResult.Error);
            return Result.Failure(removeResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<int>> AddAsync(
        VisitRadioghraphRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        var visitIdResult = Id.Create(dto.VisitId);
        if (visitIdResult.IsFailure)
        {
            return Result.Failure<int>(visitIdResult.Error);
        }

        var visit = await _visitRepository.GetByIdAsync(
            visitIdResult.Value,
            cancellationToken);
        if (visit is null)
        {
            return Result.Failure<int>(ServiceErrors.Common.NotFound);
        }

        var addResult = visit.AddVisitRadiograph(
            dto.ImagePath);
        if (addResult.IsFailure)
        {
            return Result.Failure<int>(addResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return addResult.Value.Id.Value;
    }
}