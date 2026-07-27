namespace Dental.Application.DTOs.DentalInfo;

public sealed record DentalInfoDto(
    string? DoctorName,
    string? PhoneNumber,
    string? DoctorPicturePath,
    string? DentalName,
    string? DentalDescription,
    string? DentalPicturePath)
{
    public static DentalInfoDto FromEntity(Dental.Domain.Entities.DentalInfo entity)
    {
        return new DentalInfoDto(
            entity.DoctorName,
            entity.PhoneNumber,
            entity.DoctorPicturePath,
            entity.DentalName,
            entity.DentalDescription,
            entity.DentalPicturePath);
    }
}