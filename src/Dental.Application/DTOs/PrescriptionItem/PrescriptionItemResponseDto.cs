using Dental.Application.Abstractions;
using Dental.Domain.ValueObjects;

namespace Dental.Application.DTOs.PrescriptionItem;

public sealed record PrescriptionItemResponseDto(
    int Id,
    Id PrescriptionId,
    string MedicineName,
    decimal Dosage,
    MedicineFrequency MedicineFrequency,
    string? Instructions)
    : IResponseDto<Domain.Entities.PrescriptionItem, PrescriptionItemResponseDto>
{
    public static PrescriptionItemResponseDto ToResponseDto(Domain.Entities.PrescriptionItem entity)
    {
        return new PrescriptionItemResponseDto(
            Id: entity.Id.Value,
            PrescriptionId: entity.PrescriptionId,
            MedicineName: entity.MedicineName,
            Dosage: entity.Dosage,
            MedicineFrequency: entity.MedicineFrequency,
            Instructions: entity.Instructions
        );
    }
}