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

public sealed class VisitService
    : ServiceBase<Visit, VisitResponseDto>
    , IVisitService
{
    private readonly IVisitRepository _visitRepo;
    private readonly IAppointmentRepository _appointmentRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<VisitService> _logger;

    public VisitService(
        IVisitRepository repo,
        IAppointmentRepository appointmentRepository,
        IUnitOfWork unitOfWork,
        ILogger<VisitService> logger)
        : base(repo, unitOfWork, logger)
    {
        _visitRepo = repo;
        _appointmentRepo = appointmentRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }


    public async Task<Result<int>> CreateAsync(
        VisitRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("VisitService.CreateAsync is called. {CreateVisitDto}", dto);

        var entityResult = await BuildEntityAndEnsureForeignKeys(
            dto,
            null,
            cancellationToken);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        _visitRepo.Add(entityResult.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Visit created successfully with ID {id}.", entityResult.Value.Id);
        return entityResult.Value.Id.Value;
    }

    public async Task<Result> UpdateAsync(
        int visitId,
        VisitRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        var visitIdResult = Id.Create(visitId);
        if (visitIdResult.IsFailure)
        {
            _logger.LogWarning("Invalid Id. {Id} {Error}", visitId, visitIdResult.Error);
            return Result.Failure<Visit>(visitIdResult.Error);
        }

        var entityResult = await BuildEntityAndEnsureForeignKeys(
            dto,
            visitIdResult.Value,
            cancellationToken);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        var visit = await _visitRepo.GetByIdAsync(visitIdResult.Value, cancellationToken);
        if (visit == null)
        {
            _logger.LogWarning("Failed to update visit: Visit not found. {VisitId}", visitId);
            return Result.Failure<int>(ServiceErrors.NotFound);
        }

        var visitUpdateResult = visit.Update(
            entityResult.Value.AppointmentId,
            entityResult.Value.PaidAmount,
            entityResult.Value.DiscountAmount,
            dto.VisitDateTime,
            dto.Notes);
        if (visitUpdateResult.IsFailure)
        {
            _logger.LogWarning("Failed to update visit: {Error}", visitUpdateResult.Error);
            return Result.Failure<int>(visitUpdateResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Visit updated successfully. {VisitId}", visitId);

        return Result.Success();
    }

    private async Task<Result<Visit>> BuildEntityAndEnsureForeignKeys(
        VisitRequestDto dto,
        Id? visitId,
        CancellationToken cancellationToken)
    {
        Result<Id> appointmentIdResult = null!;
        if (dto.AppointmentId.HasValue)
        {
            appointmentIdResult = Id.Create(dto.AppointmentId.Value);
            if (appointmentIdResult.IsFailure)
            {
                _logger.LogWarning(
                    "Failed to create visit: Invalid appointment ID. {AppointmentId} {Error}", dto.AppointmentId, appointmentIdResult.Error);
                return Result.Failure<Visit>(appointmentIdResult.Error);
            }
        }

        var paidAmountResult = Money.Create(dto.PaidAmount);
        if (paidAmountResult.IsFailure)
        {
            _logger.LogWarning("Failed to create visit: Invalid paid amount. {PaidAmount} {PaidAmountResult}",
                dto.PaidAmount, paidAmountResult);

            return Result.Failure<Visit>(paidAmountResult.Error);
        }

        var discountAmountResult = Money.Create(dto.DiscountAmount);
        if (discountAmountResult.IsFailure)
        {
            _logger.LogWarning("Failed to create visit: Invalid discount amount. {DiscountAmount} {DiscountAmountResult}",
                dto.DiscountAmount, discountAmountResult);
            return Result.Failure<Visit>(discountAmountResult.Error);
        }

        var visitResult = Visit.Create(
            appointmentIdResult?.Value,
            paidAmountResult.Value,
            discountAmountResult.Value,
            dto.VisitDateTime,
            dto.Notes);

        if (visitResult.IsFailure)
        {
            _logger.LogWarning("Failed to create visit: {visitResult}", visitResult);
            return Result.Failure<Visit>(visitResult.Error);
        }

        if (appointmentIdResult != null)
        {
            Appointment? appointment = null!;
            if ((appointment = await _appointmentRepo.GetByIdAsync(
                    appointmentIdResult.Value, cancellationToken)) == null)
            {
                _logger.LogWarning(
                    "Failed to create visit: Appointment not found. {AppointmentId}", appointmentIdResult.Value);
                return Result.Failure<Visit>(ServiceErrors.NotFound);
            }

            if (await _visitRepo.ExistsByAppointmentIdAsync(
                appointmentIdResult.Value, visitId, cancellationToken))
            {
                _logger.LogWarning(
                    "Attempted to create a visit with duplicated appointment Id." +
                    " {AppointmentId} {Error}", appointmentIdResult.Value.Value, appointmentIdResult.Error);

                return Result.Failure<Visit>(ServiceErrors.Visit.DuplicatedAppointmentId);
            }

            var completeResult = appointment.Complete();
            if (completeResult.IsFailure)
            {
                _logger.LogWarning("Failed to complete an Appointment. {AppointmentId} {Error}",
                    appointmentIdResult.Value.Value, completeResult.Error);

                return Result.Failure<Visit>(completeResult.Error);
            }
        }

        return Result.Success(visitResult.Value);
    }


    //public async Task<Result<int>> AddVisitWithManyTreatmentsAsync(
    //    VisitRequestDto dto,
    //    List<VisitTreatmentRequestDto> treatments,
    //    CancellationToken cancellationToken = default)
    //{
    //    var visitResult = await BuildEntityAndEnsureForeignKeys(
    //        dto, cancellationToken);

    //    await _visitRepo.Add(visitResult.Value);

    //    foreach (var treatment in treatments)
    //    {
    //        var addTreatmentResult = await AddTreatmentAsync(visitResult.Value, treatment, cancellationToken);
    //        if (addTreatmentResult.IsFailure)
    //        {
    //            return Result.Failure<int>(addTreatmentResult.Error);
    //        }
    //    }

    //    await _unitOfWork.SaveChangesAsync(cancellationToken);
    //    _logger.LogInformation("Visit and VisitTreatment was added successfully. {VisitId}", visitResult.Value.Id.Value);

    //    return visitResult.Value.Id.Value;
    //}

    //private async Task<Result> AddTreatmentAsync(
    //    Visit visit,
    //    VisitTreatmentRequestDto treatment,
    //    CancellationToken cancellationToken)
    //{
    //    var toothNumberResult = ToothNumber.Create(treatment.ToothNumber);
    //    if (toothNumberResult.IsFailure)
    //    {
    //        _logger.LogWarning("Invalid Tooth Number. {ToothNumber}", treatment.ToothNumber);
    //        return Result.Failure<int>(ServiceErrors.Visit.InvalidToothNumber);
    //    }

    //    var treatmentIdResult = Id.Create(treatment.TreatmentId);
    //    if (treatmentIdResult.IsFailure)
    //    {
    //        _logger.LogWarning("Invalid Treatment Id. {Id}", treatment.TreatmentId);
    //        return Result.Failure(ServiceErrors.Visit.InvalidTreatmentId);
    //    }

    //    var priceResult = Money.Create(treatment.TreatmentId);
    //    if (priceResult.IsFailure)
    //    {
    //        _logger.LogWarning("Invalid Treatment Id. {Id}", treatment.TreatmentId);
    //        return Result.Failure(ServiceErrors.Visit.InvalidTreatmentId);
    //    }

    //    var price = await _treatmentRepo.GetPriceByIdAsync(treatmentIdResult.Value, cancellationToken);
    //    if (price == null)
    //    {
    //        _logger.LogWarning("Treatment not found. {Id}", treatmentIdResult.Value);
    //        return Result.Failure(ServiceErrors.Visit.TreatmentNotFound);
    //    }

    //    var addTreatmentsResult = visit.AddVisitTreatment(
    //        toothNumberResult.Value,
    //        treatmentIdResult.Value,
    //        price,
    //        treatment.Notes);

    //    if (addTreatmentsResult.IsFailure)
    //    {
    //        _logger.LogWarning("Failed to add VisitTreatment due to Domain business rules.");
    //        return Result.Failure(addTreatmentsResult.Error);
    //    }

    //    return Result.Success();
    //}
}