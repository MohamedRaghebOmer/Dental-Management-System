using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Visit;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public sealed class VisitService(
    IRepository<Visit> repo,
    IRepository<Appointment> appointmentRepo,
    IVisitToothTreatmentRepository visitToothTreatmentRepo,
    IUnitOfWork unitOfWork,
    ILogger<ServiceBase<Visit, VisitResponseDto>> logger)
    : ServiceBase<Visit, VisitResponseDto>(repo, unitOfWork, logger)
    , IVisitService
{
    public async Task<Result<int>> CreateAsync(
        VisitRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("VisitService.CreateAsync is called. {CreateVisitDto}", dto);

        var entityResult = await BuildEntityAndEnsureForeignKeys(
            dto,
            cancellationToken);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        await repo.AddAsync(entityResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Visit created successfully with ID {id}.", entityResult.Value.Id);
        return Result.Success(entityResult.Value.Id);
    }

    public async Task<Result> UpdateASync(
        int visitId,
        VisitRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        var entityResult = await BuildEntityAndEnsureForeignKeys(
            dto,
            cancellationToken);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        var visit = await repo.GetByIdAsync(visitId, cancellationToken);
        if (visit == null)
        {
            logger.LogWarning("Failed to update visit: Visit not found. {VisitId}", visitId);
            return Result.Failure<int>(ServiceErrors.NotFound);
        }

        var visitResult = visit.Update(
            entityResult.Value.AppointmentId,
            entityResult.Value.PaidAmount,
            entityResult.Value.DiscountAmount,
            dto.Date,
            dto.Notes);
        if (visitResult.IsFailure)
        {
            logger.LogWarning("Failed to update visit: {visitResult}", visitResult);
            return Result.Failure<int>(ServiceErrors.InvalidId);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Visit updated successfully. {VisitId}", visitId);

        return Result.Success();
    }

    public async Task<decimal> GetTotalAmountAsync(
        int visitId,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("VisitService.GetTotalAmountAsync is called. {VisitId}", visitId);
        var result =
            await visitToothTreatmentRepo.GetTotalCostAsync(visitId, cancellationToken);
        logger.LogInformation("Total amount for visit {VisitId}: {TotalAmount}", visitId, result);
        return result;
    }

    private async Task<Result<Visit>> BuildEntityAndEnsureForeignKeys(
        VisitRequestDto dto,
        CancellationToken cancellationToken,
        int? visitId = null)
    {
        if (visitId <= 0)
        {
            logger.LogWarning("Failed to update visit: Invalid visit ID. {VisitId}", visitId);
            return Result.Failure<Visit>(ServiceErrors.InvalidId);
        }

        Result<Id> appointmentIdResult = null!;
        if (dto.AppointmentId is not null)
        {
            appointmentIdResult = Id.Create((int)dto.AppointmentId);
            if (appointmentIdResult.IsFailure)
            {
                logger.LogWarning("Failed to create visit: Invalid appointment ID. {AppointmentId}", dto.AppointmentId);
                return Result.Failure<Visit>(ServiceErrors.InvalidId);
            }
        }

        var paidAmountResult = Money.Create(dto.PaidAmount);
        if (paidAmountResult.IsFailure)
        {
            logger.LogWarning("Failed to create visit: Invalid paid amount. {PaidAmount} {PaidAmountResult}",
                dto.PaidAmount, paidAmountResult);

            return Result.Failure<Visit>(ServiceErrors.InvalidId);
        }

        var discountAmountResult = Money.Create(dto.DiscountAmount);
        if (discountAmountResult.IsFailure)
        {
            logger.LogWarning("Failed to create visit: Invalid discount amount. {DiscountAmount} {DiscountAmountResult}",
                dto.DiscountAmount, discountAmountResult);
            return Result.Failure<Visit>(ServiceErrors.InvalidId);
        }


        var visitResult = Visit.Create(
            appointmentIdResult?.Value,
            paidAmountResult.Value,
            discountAmountResult.Value,
            dto.Date,
            dto.Notes);

        if (visitResult.IsFailure)
        {
            logger.LogWarning("Failed to create visit: {visitResult}", visitResult);
            return Result.Failure<Visit>(ServiceErrors.InvalidId);
        }

        if (!await appointmentRepo.ExistsAsync(
                (int)(appointmentIdResult?.Value?.Value)!,
                cancellationToken))
        {
            logger.LogWarning("Failed to create visit: Appointment not found. {AppointmentId}", appointmentIdResult?.Value);
            return Result.Failure<Visit>(ServiceErrors.AppointmentErrors.PatientNotFound);
        }

        return Result.Success(visitResult.Value);
    }
}