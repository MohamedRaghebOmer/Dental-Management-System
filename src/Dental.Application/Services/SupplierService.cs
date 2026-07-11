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

public sealed class SupplierService(
    IRepository<Supplier> repo,
    ISupplierRepository supplierRepo,
    IUnitOfWork unitOfWork,
    ILogger<ServiceBase<Supplier, SupplierResponseDto>> logger)
    : ServiceBase<Supplier, SupplierResponseDto>(repo, unitOfWork, logger), ISupplierService
{
    public async Task<Result<int>> CreateAsync(
        SupplierRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        var entityResult = await BuildEntityAndEnsureUniqueFields(dto, cancellationToken);
        if (entityResult.IsFailure)
        {
            return Result.Failure<int>(entityResult.Error);
        }

        await repo.AddAsync(entityResult.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return entityResult.Value.Id.Value;
    }

    public async Task<Result> UpdateAsync(
        int supplierId,
        SupplierRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        var updatedEntityResult = 
            await BuildEntityAndEnsureUniqueFields(dto,cancellationToken, supplierId);
        if (updatedEntityResult.IsFailure)
        {
            return Result.Failure(updatedEntityResult.Error);
        }

        var existingEntity = await repo.GetByIdAsync(supplierId, cancellationToken);
        if (existingEntity is null)
        {
            return Result.Failure(ServiceErrors.NotFound);
        }

        existingEntity.Update(
            updatedEntityResult.Value.Name,
            updatedEntityResult.Value.PhoneNumber,
            updatedEntityResult.Value.Address,
            updatedEntityResult.Value.Description);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }


    private async Task<Result<Supplier>> BuildEntityAndEnsureUniqueFields(
        SupplierRequestDto dto,
        CancellationToken cancellationToken = default,
        int? supplierId = null)
    {
        if (supplierId <= 0)
        {
            logger.LogInformation("Invalid supplier ID provided. {SupplierId}", supplierId);
            return Result.Failure<Supplier>(ServiceErrors.InvalidId);
        }

        Result<PhoneNumber> phoneNumberResult = null!;
        if (dto.PhoneNumber is not null)
        {
            phoneNumberResult = PhoneNumber.Create(dto.PhoneNumber);
            if (phoneNumberResult.IsFailure)
            {
                logger.LogInformation("Invalid phone number provided. {PhoneNumber}", dto.PhoneNumber);
                return Result.Failure<Supplier>(phoneNumberResult.Error);
            }

            if (await supplierRepo.PhoneNumberExistsAsync(
                    dto.PhoneNumber,
                    supplierId, 
                    cancellationToken))
            {
                logger.LogInformation("Phone number already exists. {PhoneNumber}", dto.PhoneNumber);
                return Result.Failure<Supplier>(ServiceErrors.Supplier.PhoneNumberExists);
            }
        }

        var entityResult = Supplier.Create(
            name: dto.Name,
            phoneNumber: phoneNumberResult?.Value,
            address: dto.Address,
            description: dto.Description);

        if (entityResult.IsFailure)
        {
            logger.LogInformation("Failed to create supplier entity. {Errors}", entityResult.Error);
            return Result.Failure<Supplier>(entityResult.Error);
        }

        return Result.Success(entityResult.Value);
    }
}