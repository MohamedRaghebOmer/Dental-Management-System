using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.LabTransaction;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public sealed class LabTransactionService
    : ServiceBase<LabTransaction, LabTransactionResponseDto>
    , ILabTransactionService
{
    private readonly ILabTransactionRepository _repo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<LabTransactionService> _logger;

    public LabTransactionService(
        ILabTransactionRepository repo,
        IUnitOfWork unitOfWork,
        ILogger<LabTransactionService> logger)
        : base(repo, unitOfWork, logger)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<int>> CreateAsync(LabTransactionRequestDto requestDto)
    {
        _logger.LogInformation("Creating a new lab transaction for lab: {LabName}", requestDto.LabName);

        var buildResult = BuildEntity(requestDto);
        if (buildResult.IsFailure)
        {
            _logger.LogWarning("Failed to create lab transaction for lab: {LabName}. Error: {Error}", requestDto.LabName, buildResult.Error);
            return Result.Failure<int>(buildResult.Error);
        }

        _repo.Add(buildResult.Value);
        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("Lab transaction created successfully for lab: {LabName}", requestDto.LabName);

        return buildResult.Value.Id.Value;
    }

    private Result<LabTransaction> BuildEntity(
        LabTransactionRequestDto requestDto)
    {
        var paidAmountResult = Money.Create(requestDto.PaidAmount);
        if (paidAmountResult.IsFailure)
        {
            _logger.LogWarning("Failed to create lab transaction for lab: {LabName}", requestDto.LabName);
            return Result.Failure<LabTransaction>(paidAmountResult.Error);
        }

        var totalAmountResult = Money.Create(requestDto.TotalAmount);
        if (totalAmountResult.IsFailure)
        {
            _logger.LogWarning("Failed to create lab transaction for lab: {LabName}", requestDto.LabName);
            return Result.Failure<LabTransaction>(totalAmountResult.Error);
        }

        var labTransaction = LabTransaction.Create(
            requestDto.LabName,
            paidAmountResult.Value,
            totalAmountResult.Value,
            requestDto.Treatments);

        if (labTransaction.IsFailure)
        {
            _logger.LogWarning("Failed to create lab transaction for lab: {LabName}", requestDto.LabName);
            return Result.Failure<LabTransaction>(labTransaction.Error);
        }

        return labTransaction.Value;
    }

    public async Task<Result> UpdateAsync(
        int id,
        LabTransactionRequestDto requestDto,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating lab transaction with ID: {Id} for lab: {LabName}", id, requestDto.LabName);

        var idResult = Id.Create(id);
        if (idResult.IsFailure)
        {
            _logger.LogWarning("Failed to create lab transaction for lab: {LabName}. Invalid ID: {Id}", requestDto.LabName, id);
            return Result.Failure<LabTransaction>(idResult.Error);
        }

        var buildResult = BuildEntity(requestDto);
        if (buildResult.IsFailure)
        {
            _logger.LogWarning("Failed to update lab transaction with ID: {Id} for lab: {LabName}. Error: {Error}", id, requestDto.LabName, buildResult.Error);
            return Result.Failure(buildResult.Error);
        }

        var existingTransaction = await _repo.GetByIdAsync(idResult.Value, cancellationToken);
        if (existingTransaction is null)
        {
            _logger.LogWarning(
                "Lab transaction with ID: {Id} not found for lab: {LabName}", id, requestDto.LabName);
            return Result.Failure(ServiceErrors.Common.NotFound);
        }

        var updateResult = existingTransaction.Update(
            buildResult.Value.LabName,
            buildResult.Value.PaidAmount,
            buildResult.Value.TotalAmount,
            buildResult.Value.Treatments);
        if (updateResult.IsFailure)
        {
            _logger.LogWarning("Failed to update lab transaction with ID: {Id} for lab: {LabName}. Error: {Error}", id, requestDto.LabName, updateResult.Error);
            return Result.Failure(updateResult.Error);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Lab transaction updated successfully with ID: {Id} for lab: {LabName}", id, requestDto.LabName);

        return Result.Success();
    }
}