using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Visit;
using Dental.Application.DTOs.VisitPayment;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Dental.Application.Services;

public sealed class VisitService
    : ServiceBase<Visit, VisitResponseDto>
    , IVisitService
{
    private readonly IVisitRepository _visitRepo;
    private readonly IAppointmentRepository _appointmentRepo;
    private readonly IPatientRepository _patientRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<VisitService> _logger;

    public VisitService(
        IVisitRepository repo,
        IAppointmentRepository appointmentRepository,
        IPatientRepository patientRepository,
        IUnitOfWork unitOfWork,
        ILogger<VisitService> logger)
        : base(repo, unitOfWork, logger)
    {
        _visitRepo = repo;
        _appointmentRepo = appointmentRepository;
        _patientRepo = patientRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }


    public async Task<Result<int>> CreateWalkInVisitAsync(
        WalkInVisitDto walkInVisitDto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation(
                "VisitService.CreateWalkInVisitAsync is called. {WalkInVisitDto}",
                walkInVisitDto);

            // Optional but recommended: validate DTO attributes here too
            var validationContext = new ValidationContext(walkInVisitDto);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(
                    walkInVisitDto,
                    validationContext,
                    validationResults,
                    validateAllProperties: true))
            {
                var validationMessage = string.Join(" | ", validationResults.Select(r => r.ErrorMessage));

                _logger.LogWarning(
                    "CreateWalkInVisitAsync failed because of invalid DTO. Errors: {Errors}",
                    validationMessage);

                return Result.Failure<int>(ServiceErrors.Common.ValidationFailed);
            }

            var patientIdResult = Id.Create(walkInVisitDto.PatientId);
            if (patientIdResult.IsFailure)
            {
                _logger.LogWarning(
                    "CreateWalkInVisitAsync failed. Invalid PatientId: {PatientId}.",
                    walkInVisitDto.PatientId);
                return Result.Failure<int>(patientIdResult.Error);
            }

            if (!await _patientRepo.ExistsAsync(patientIdResult.Value, cancellationToken))
            {
                _logger.LogWarning(
                    "CreateWalkInVisitAsync failed. Patient with Id {PatientId} was not found.",
                    walkInVisitDto.PatientId);

                return Result.Failure<int>(ServiceErrors.Visit.PatientNotFound);
            }


            var discountAmount = Money.Create(walkInVisitDto.DiscountAmount);
            if (discountAmount.IsFailure)
            {
                _logger.LogWarning(
                    "CreateWalkInVisitAsync failed. Invalid DiscountAmount: {DiscountAmount}.",
                    walkInVisitDto.DiscountAmount);

                return Result.Failure<int>(discountAmount.Error);
            }

            var visitResult = Visit.Create(
                appointmentId: null,
                patientId: patientIdResult.Value,
                discountAmount: discountAmount.Value,
                visitDateTime: walkInVisitDto.VisitDateTime,
                notes: walkInVisitDto.Notes);

            if (visitResult.IsFailure)
            {
                _logger.LogWarning(
                    "CreateWalkInVisitAsync failed while creating Visit for PatientId {PatientId}. Error: {Error}",
                    walkInVisitDto.PatientId,
                    visitResult.Error);

                return Result.Failure<int>(visitResult.Error);
            }

            var visit = visitResult.Value;

            _visitRepo.Add(visit);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(visit.Id.Value);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation(
                "CreateWalkInVisitAsync was canceled for PatientId {PatientId}.",
                walkInVisitDto?.PatientId);

            return Result.Failure<int>(ServiceErrors.Common.UnexpectedError);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Unexpected error occurred in CreateWalkInVisitAsync for PatientId {PatientId}.",
                walkInVisitDto?.PatientId);

            return Result.Failure<int>(ServiceErrors.Common.UnexpectedError);
        }
    }

    public async Task<Result<int>> CreatePreAppointmentVisitAsync(
        PreAppointmentVisitDto preAppointmentVisitDto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation(
                "VisitService.CreatePreAppointmentVisitAsync is called. {PreAppointmentVisitDto}",
                preAppointmentVisitDto);

            // Optional but recommended: validate DTO attributes here too
            var validationContext = new ValidationContext(preAppointmentVisitDto);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(
                    preAppointmentVisitDto,
                    validationContext,
                    validationResults,
                    validateAllProperties: true))
            {
                var validationMessage = string.Join(" | ", validationResults.Select(r => r.ErrorMessage));

                _logger.LogWarning(
                    "CreatePreAppointmentVisitAsync failed because of invalid DTO. Errors: {Errors}",
                    validationMessage);

                return Result.Failure<int>(ServiceErrors.Common.ValidationFailed);
            }

            var appointmentIdResult = Id.Create(preAppointmentVisitDto.AppointmentId);
            if (appointmentIdResult.IsFailure)
            {
                _logger.LogWarning(
                    "CreatePreAppointmentVisitAsync failed. Invalid AppointmentId: {AppointmentId}.",
                    preAppointmentVisitDto.AppointmentId);

                return Result.Failure<int>(appointmentIdResult.Error);
            }

            var appointment = await _appointmentRepo.GetByIdAsync(
                appointmentIdResult.Value, cancellationToken);
            if (appointment is null)
            {
                _logger.LogWarning(
                    "CreatePreAppointmentVisitAsync failed. Appointment with Id {AppointmentId} was not found.",
                    preAppointmentVisitDto.AppointmentId);

                return Result.Failure<int>(ServiceErrors.Visit.AppointmentNotFound);
            }

            var completeResult = appointment.Complete();
            if (completeResult.IsFailure)
            {
                _logger.LogWarning("CreatePreAppointmentVisitAsync failed. Appointment with Id {AppointmentId} could not be completed. Error: {Error}",
                    preAppointmentVisitDto.AppointmentId,
                    completeResult.Error);

                return Result.Failure<int>(completeResult.Error);
            }

            var discountAmount = Money.Create(preAppointmentVisitDto.DiscountAmount);
            if (discountAmount.IsFailure)
            {
                _logger.LogWarning(
                    "CreatePreAppointmentVisitAsync failed. Invalid DiscountAmount: {DiscountAmount}.",
                    preAppointmentVisitDto.DiscountAmount);

                return Result.Failure<int>(discountAmount.Error);
            }

            var visitResult = Visit.Create(
                appointmentId: appointmentIdResult.Value,
                patientId: appointment.PatientId,
                discountAmount: discountAmount.Value,
                visitDateTime: preAppointmentVisitDto.VisitDateTime,
                notes: preAppointmentVisitDto.Notes);

            if (visitResult.IsFailure)
            {
                _logger.LogWarning(
                    "CreatePreAppointmentVisitAsync failed while creating Visit for AppointmentId {AppointmentId}. Error: {Error}",
                    preAppointmentVisitDto.AppointmentId,
                    visitResult.Error);

                return Result.Failure<int>(visitResult.Error);
            }

            var visit = visitResult.Value;

            _visitRepo.Add(visit);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(visit.Id.Value);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation(
                "CreatePreAppointmentVisitAsync was canceled for AppointmentId {AppointmentId}.",
                preAppointmentVisitDto?.AppointmentId);

            return Result.Failure<int>(ServiceErrors.Common.UnexpectedError);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Unexpected error occurred in CreatePreAppointmentVisitAsync for AppointmentId {AppointmentId}.",
                preAppointmentVisitDto?.AppointmentId);

            return Result.Failure<int>(ServiceErrors.Common.UnexpectedError);
        }
    }

    public async Task<Result> UpdateAsync(
         int visitId,
         UpdateVisitDto updateVisitDto,
         CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation(
                "VisitService.UpdateAsync is called. {UpdateVisitDto}",
                updateVisitDto);

            // Optional but recommended: validate DTO attributes here too
            var validationContext = new ValidationContext(updateVisitDto);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(
                    updateVisitDto,
                    validationContext,
                    validationResults,
                    validateAllProperties: true))
            {
                var validationMessage = string.Join(" | ", validationResults.Select(r => r.ErrorMessage));

                _logger.LogWarning(
                    "UpdateAsync failed because of invalid DTO. VisitId: {VisitId}. Errors: {Errors}",
                    visitId,
                    validationMessage);

                return Result.Failure(ServiceErrors.Common.ValidationFailed);
            }

            var visitIdResult = Id.Create(visitId);
            if (visitIdResult.IsFailure)
            {
                _logger.LogWarning(
                    "UpdateAsync failed. Invalid VisitId: {VisitId}.",
                    visitId);

                return Result.Failure(visitIdResult.Error);
            }

            var visit = await _visitRepo.GetByIdAsync(visitIdResult.Value, cancellationToken);
            if (visit is null)
            {
                _logger.LogWarning(
                    "UpdateAsync failed. Visit with Id {VisitId} was not found.",
                    visitId);

                return Result.Failure(ServiceErrors.Common.NotFound);
            }


            var discountAmount = Money.Create(updateVisitDto.DiscountAmount);
            if (discountAmount.IsFailure)
            {
                _logger.LogWarning(
                    "UpdateAsync failed. Invalid DiscountAmount: {DiscountAmount}. VisitId: {VisitId}.",
                    updateVisitDto.DiscountAmount,
                    visitId);

                return Result.Failure(discountAmount.Error);
            }

            var updateResult = visit.Update(
                discountAmount: discountAmount.Value,
                visitDateTime: updateVisitDto.VisitDateTime,
                notes: updateVisitDto.Notes);

            if (updateResult.IsFailure)
            {
                _logger.LogWarning(
                    "UpdateAsync failed while updating VisitId {VisitId}. Error: {Error}",
                    visitId,
                    updateResult.Error);

                return Result.Failure(updateResult.Error);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation(
                "UpdateAsync was canceled for VisitId {VisitId}.",
                visitId);

            return Result.Failure(ServiceErrors.Common.UnexpectedError);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Unexpected error occurred in UpdateAsync for VisitId {VisitId}.",
                visitId);

            return Result.Failure(ServiceErrors.Common.UnexpectedError);
        }
    }

    public async Task<Result<List<VisitPaymentResponseDto>>> GetPaymentsByVisitIdAsync(
        int visitId,
        CancellationToken cancellationToken = default)
    {
        var idResult = Id.Create(visitId);
        if (idResult.IsFailure)
            return Result.Failure
                <List<VisitPaymentResponseDto>>(ServiceErrors.Common.InvalidId);

        var entities = await _visitRepo.GetPaymentsByVisitIdAsync(
           idResult.Value,
           cancellationToken);

        return entities.Select(VisitPaymentResponseDto.ToResponseDto).ToList();
    }
}