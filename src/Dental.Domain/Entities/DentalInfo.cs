using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class DentalInfo : Entity
{
    private DentalInfo() { } // EF Core

    // Made to initialize data
    private DentalInfo(
        Id id,
        string? doctorName,
        string? phoneNumber,
        string? doctorPicturePath,
        string? dentalName,
        string? dentalDescription,
        string? dentalPicturePath)
    {
        Id = id;
        DoctorName = doctorName;
        PhoneNumber = phoneNumber;
        DentalDescription = dentalDescription;
        DoctorPicturePath = doctorPicturePath;
        DentalName = dentalName;
        DentalPicturePath = dentalPicturePath;
    }

    // Update to take all the new fields
    private DentalInfo(
        string? doctorName,
        string? phoneNumber,
        string? doctorPicturePath,
        string? dentalName,
        string? dentalDescription,
        string? dentalPicturePath)
    {
        DoctorName = doctorName;
        PhoneNumber = phoneNumber;
        DentalDescription = dentalDescription;
        DoctorPicturePath = doctorPicturePath;
        DentalName = dentalName;
        DentalPicturePath = dentalPicturePath;
    }

    public static class Constants
    {
        public const int DoctorNameMaxLength = 30;
        public const int PhoneNumberMaxLength = 11;
        public const int DoctorPicturePathMaxLength = 500;
        public const int DentalNameMaxLength = 30;
        public const int DentalDescriptionMaxLength = 100;
        public const int DentalPicturePathMaxLength = 500;
    }

    public string? DoctorName { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? DoctorPicturePath { get; private set; }
    public string? DentalName { get; private set; }
    public string? DentalDescription { get; private set; }
    public string? DentalPicturePath { get; private set; }

    public static Result<DentalInfo> Create(
        string? doctorName,
        string? phoneNumber,
        string? doctorPicturePath,
        string? dentalName,
        string? dentalDescription,
        string? dentalPicturePath)
    {
        doctorName = doctorName?.Trim();
        phoneNumber = phoneNumber?.Trim();
        doctorPicturePath = doctorPicturePath?.Trim();
        dentalName = dentalName?.Trim();
        dentalDescription = dentalDescription?.Trim();
        dentalPicturePath = dentalPicturePath?.Trim();

        var validateResult = Validate(
            doctorName,
            phoneNumber,
            doctorPicturePath,
            dentalName,
            dentalDescription,
            dentalPicturePath);

        if (!validateResult.IsSuccess)
        {
            return Result.Failure<DentalInfo>(validateResult.Error);
        }

        return Result.Success(new DentalInfo(
            doctorName,
            phoneNumber,
            doctorPicturePath,
            dentalName,
            dentalDescription,
            dentalPicturePath));
    }

    public Result Update(
        string? doctorName,
        string? phoneNumber,
        string? doctorPicturePath,
        string? dentalName,
        string? dentalDescription,
        string? dentalPicturePath)
    {
        doctorName = doctorName?.Trim();
        phoneNumber = phoneNumber?.Trim();
        doctorPicturePath = doctorPicturePath?.Trim();
        dentalName = dentalName?.Trim();
        dentalDescription = dentalDescription?.Trim();
        dentalPicturePath = dentalPicturePath?.Trim();

        var validateResult = Validate(
            doctorName,
            phoneNumber,
            doctorPicturePath,
            dentalName,
            dentalDescription,
            dentalPicturePath);

        if (!validateResult.IsSuccess)
        {
            return Result.Failure<DentalInfo>(validateResult.Error);
        }

        DoctorName = doctorName;
        PhoneNumber = phoneNumber;
        DoctorPicturePath = doctorPicturePath;
        DentalName = dentalName;
        DentalDescription = dentalDescription;
        DentalPicturePath = dentalPicturePath;

        return Result.Success();
    }

    public static DentalInfo CreateDefault()
    {
        return new DentalInfo(
            id: Id.FromDatabase(1),
            "د/ كريم فتوح",
            "01006169816",
            null,
            "إبتسامه",
            "طب الفم والأسنان",
            null);
    }

    private static Result Validate(
        string? doctorName,
        string? phoneNumber,
        string? doctorPicturePath,
        string? dentalName,
        string? dentalDescription,
        string? dentalPicturePath)
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
        if (doctorPicturePath?.Length > Constants.DoctorPicturePathMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.DentalInfo.DoctorPicturePathTooLong);
        }
        if (dentalName?.Length > Constants.DentalNameMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.DentalInfo.DentalNameTooLong);
        }
        if (dentalPicturePath?.Length > Constants.DentalPicturePathMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.DentalInfo.DentalPicturePathTooLong);
        }
        return Result.Success();
    }
}