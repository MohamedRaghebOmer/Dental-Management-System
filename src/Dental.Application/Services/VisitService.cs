using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Visit;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public sealed class VisitService(
    IRepository<Visit> repo,
    IUnitOfWork unitOfWork,
    ILogger<ServiceBase<Visit, VisitResponseDto>> logger)
    : ServiceBase<Visit, VisitResponseDto>(repo, unitOfWork, logger)
    , IVisitService
{
    public async Task<Result<int>> CreateAsync(
        CreateVisitDto dto,
        CancellationToken cancellationToken)
    {
        Result<Id> appointmentIdResult = null!;

        if (dto.AppointmentId is not null)
        {
            appointmentIdResult = Id.Create((int)dto.AppointmentId);
            if (appointmentIdResult.IsFailure)
            {
                logger.LogWarning("Failed to create visit: Invalid appointment ID.");
                return Result.Failure<int>(ServiceErrors.InvalidId);
            }
        }

        var paidAmountResult = Money.Create(dto.PaidAmount);
        if (paidAmountResult.IsFailure)
        {
            logger.LogWarning("Failed to create visit: Invalid paid amount. {0} {1}",
                dto.PaidAmount, paidAmountResult);

            return Result.Failure<int>(ServiceErrors.InvalidId);
        }

        var discountAmountResult = Money.Create(dto.DiscountAmount);
        if (discountAmountResult.IsFailure)
        {
            logger.LogWarning("Failed to create visit: Invalid discount amount. {0} {1}",
                dto.DiscountAmount, discountAmountResult);
            return Result.Failure<int>(ServiceErrors.InvalidId);
        }

        var totalAmountResult = Money.Create(dto.TotalAmount);
        if (totalAmountResult.IsFailure)
        {
            logger.LogWarning(
                "Failed to create visit: Invalid total amount. {0} {1}",
                dto.TotalAmount, totalAmountResult);

            return Result.Failure<int>(ServiceErrors.InvalidId);
        }

        var visitResult = Visit.Create(
            appointmentIdResult?.Value,
            paidAmountResult.Value,
            discountAmountResult.Value,
            totalAmountResult.Value,
            dto.Date,
            dto.Notes);

        if (visitResult.IsFailure)
        {
            logger.LogWarning("Failed to create visit: {visitResult}", visitResult);
            return Result.Failure<int>(ServiceErrors.InvalidId);
        }

        await repo.AddAsync(visitResult.Value, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        logger.LogInformation("Visit created successfully with ID {id}.", visitResult.Value.Id);
        return Result.Success(visitResult.Value.Id);
    }

    public async Task<Result> UpdateASync(
        int visitId,
        UpdateVisitDto dto,
        CancellationToken cancellationToken)
    {
        if (visitId <= 0)
        {
            logger.LogWarning("Failed to update visit: Invalid visit ID. {0}", visitId);
            return Result.Failure<int>(ServiceErrors.InvalidId);
        }

        Result<Id> appointmentIdResult = null!;

        if (dto.AppointmentId is not null)
        {
            appointmentIdResult = Id.Create((int)dto.AppointmentId);
            if (appointmentIdResult.IsFailure)
            {
                logger.LogWarning("Failed to create visit: Invalid appointment ID.");
                return Result.Failure<int>(ServiceErrors.InvalidId);
            }
        }

        var paidAmountResult = Money.Create(dto.PaidAmount);
        if (paidAmountResult.IsFailure)
        {
            logger.LogWarning("Failed to create visit: Invalid paid amount. {0} {1}",
                dto.PaidAmount, paidAmountResult);

            return Result.Failure<int>(ServiceErrors.InvalidId);
        }

        var discountAmountResult = Money.Create(dto.DiscountAmount);
        if (discountAmountResult.IsFailure)
        {
            logger.LogWarning("Failed to create visit: Invalid discount amount. {0} {1}",
                dto.DiscountAmount, discountAmountResult);
            return Result.Failure<int>(ServiceErrors.InvalidId);
        }

        var totalAmountResult = Money.Create(dto.TotalAmount);
        if (totalAmountResult.IsFailure)
        {
            logger.LogWarning(
                "Failed to create visit: Invalid total amount. {0} {1}",
                dto.TotalAmount, totalAmountResult);

            return Result.Failure<int>(ServiceErrors.InvalidId);
        }

        var visit = await repo.GetByIdAsync(visitId, cancellationToken);

        if (visit == null)
        {
            logger.LogWarning("Failed to update visit: Visit not found. {0}", visitId);
            return Result.Failure<int>(ServiceErrors.NotFound);
        }

        var visitResult = visit.Update(
            appointmentIdResult?.Value,
            paidAmountResult.Value,
            discountAmountResult.Value,
            totalAmountResult.Value,
            dto.Date,
            dto.Notes);

        if (visitResult.IsFailure)
        {
            logger.LogWarning("Failed to update visit: {visitResult}", visitResult);
            return Result.Failure<int>(ServiceErrors.InvalidId);
        }

        await unitOfWork.CommitAsync(cancellationToken);
        logger.LogInformation("Visit updated successfully. {0}", visitId);

        return Result.Success();
    }
}