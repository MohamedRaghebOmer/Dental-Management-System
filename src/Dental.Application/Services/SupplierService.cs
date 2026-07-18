using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Supplier;
using Dental.Application.Errors;
using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Dental.Application.Services;

public sealed class SupplierService
    : ServiceBase<Supplier, SupplierResponseDto>
    , ISupplierService
{
    private readonly IRepository<Supplier> _repo;
    private readonly ISupplierRepository _supplierRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<SupplierService> _logger;

    public SupplierService(
        IRepository<Supplier> repo,
        ISupplierRepository supplierRepo,
        IUnitOfWork unitOfWork,
        ILogger<SupplierService> logger) : base(repo, unitOfWork, logger)
    {
        _repo = repo;
        _supplierRepo = supplierRepo;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }


    public async Task<Result<int>> CreateAsync(
        SupplierRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        var entityResult = await BuildEntityAndEnsureUniqueFields(dto, cancellationToken);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        _repo.Add(entityResult.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entityResult.Value.Id.Value;
    }

    public async Task<Result> UpdateAsync(
        int supplierId,
        SupplierRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        var createIdResult = Id.Create(supplierId);
        if (createIdResult.IsFailure)
        {
            _logger.LogWarning("Invalid Id. {Id} {Error}", supplierId, createIdResult.Error);
            return Result.Failure(createIdResult.Error);
        }

        var updatedEntityResult =
            await BuildEntityAndEnsureUniqueFields(dto, cancellationToken, createIdResult.Value);
        if (updatedEntityResult.IsFailure)
        {
            return Result.Failure(updatedEntityResult.Error);
        }

        var existingEntity = await _repo.GetByIdAsync(createIdResult.Value, cancellationToken);
        if (existingEntity is null)
        {
            return Result.Failure(ServiceErrors.NotFound);
        }

        existingEntity.Update(
            updatedEntityResult.Value.Name,
            updatedEntityResult.Value.PhoneNumber,
            updatedEntityResult.Value.Address,
            updatedEntityResult.Value.Description);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }


    private async Task<Result<Supplier>> BuildEntityAndEnsureUniqueFields(
        SupplierRequestDto dto,
        CancellationToken cancellationToken = default,
        Id? supplierId = null)
    {
        Result<PhoneNumber> phoneNumberResult = null!;
        if (dto.PhoneNumber is not null)
        {
            phoneNumberResult = PhoneNumber.Create(dto.PhoneNumber);
            if (phoneNumberResult.IsFailure)
            {
                _logger.LogInformation("Invalid phone number provided. {PhoneNumber}", dto.PhoneNumber);
                return Result.Failure<Supplier>(phoneNumberResult.Error);
            }

            if (await _supplierRepo.PhoneNumberExistsAsync(
                    phoneNumberResult.Value,
                    supplierId,
                    cancellationToken))
            {
                _logger.LogInformation("Phone number already exists. {PhoneNumber}", dto.PhoneNumber);
                return Result.Failure<Supplier>(ServiceErrors.Supplier.PhoneNumberAlreadyExists);
            }
        }

        var entityResult = Supplier.Create(
            name: dto.Name,
            phoneNumber: phoneNumberResult?.Value,
            address: dto.Address,
            description: dto.Description);

        if (entityResult.IsFailure)
        {
            _logger.LogInformation("Failed to create supplier entity. {Errors}", entityResult.Error);
            return Result.Failure<Supplier>(entityResult.Error);
        }

        return Result.Success(entityResult.Value);
    }
}