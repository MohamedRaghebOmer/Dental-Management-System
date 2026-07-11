namespace Dental.Application.DTOs.DentalInfo;

public sealed record DentalInfoDto(
    string? DoctorName,
    string? DentalDescription,
    string? PhoneNumber,
    string? PicturePath);