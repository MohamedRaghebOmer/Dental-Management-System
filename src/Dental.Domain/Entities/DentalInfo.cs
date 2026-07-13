using System.ComponentModel.DataAnnotations;
using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class DentalInfo : Entity
{
    private DentalInfo(){} // EF Core

    private DentalInfo(
        Id id,
        string? doctorName,
        string? dentalDescription,
        string? phoneNumber,
        string? picturePath)
    {
        Id = id;
        DoctorName = doctorName;
        DentalDescription = dentalDescription;
        PhoneNumber = phoneNumber;
        PicturePath = picturePath;
    }

    private DentalInfo(
        string? doctorName,
        string? dentalDescription,
        string? phoneNumber,
        string? picturePath)
    {
        DoctorName = doctorName;
        DentalDescription = dentalDescription;
        PhoneNumber = phoneNumber;
        PicturePath = picturePath;
    }

    public static class Constants
    {
        public const int DoctorNameMaxLength = 20;
        public const int DentalDescriptionMaxLength = 20;
        public const int PhoneNumberMaxLength = 13;
        public const int PicturePathMaxLength = 200;
    }

    public string? DoctorName { get; private set; }
    public string? DentalDescription { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? PicturePath{ get; private set; }

    public static Result<DentalInfo> Create(
        string? doctorName,
        string? dentalDescription,
        string? phoneNumber,
        string? picturePath)
    {
        var validateResult = Validate(doctorName, dentalDescription, phoneNumber, picturePath);

        if (!validateResult.IsSuccess)
        {
            return Result.Failure<DentalInfo>(validateResult.Error);
        }

        return Result.Success(new DentalInfo(
            doctorName?.Trim(),
            dentalDescription?.Trim(),
            phoneNumber?.Trim(),
            picturePath?.Trim()));
    }

    public Result Update(
        string? doctorName,
        string? dentalDescription,
        string? phoneNumber,
        string? picturePath)
    {
        var validateResult = Validate(doctorName, dentalDescription, phoneNumber, picturePath);

        if (!validateResult.IsSuccess)
        {
            return Result.Failure(validateResult.Error);
        }

        DoctorName = doctorName?.Trim();
        DentalDescription = dentalDescription?.Trim();
        PhoneNumber = phoneNumber?.Trim();
        PicturePath = picturePath?.Trim();

        return Result.Success();
    }

    public static DentalInfo CreateDefault()
    {
        return new DentalInfo(
            Id.FromDatabase(1),
            "د/ كريم فتوح",
            "طب الفم والأسنان",
            "+20100619816",
            null);
    }
    private static Result Validate(
        string? doctorName,
        string? dentalDescription,
        string? phoneNumber,
        string? picturePath)
    {
        // Validate is about check the max length for each property
        if (doctorName?.Length > Constants.DoctorNameMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.DentalInfo.DoctorNameTooLong);
        }
        if (dentalDescription?.Length > Constants.DentalDescriptionMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.DentalInfo.DentalDescriptionTooLong);
        }
        if (phoneNumber?.Length > Constants.PhoneNumberMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.DentalInfo.PhoneNumberTooLong);
        }
        if (picturePath?.Length > Constants.PicturePathMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.DentalInfo.PicturePathTooLong);
        }
        return Result.Success();
    }
}