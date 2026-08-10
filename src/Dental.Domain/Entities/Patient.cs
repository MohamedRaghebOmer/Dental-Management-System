using Dental.Domain.Enums;
using Dental.Domain.Errors;
using Dental.Domain.Primitives;
using Dental.Domain.Shared;
using Dental.Domain.ValueObjects;

namespace Dental.Domain.Entities;

public sealed class Patient : Entity
{
    public static class Constants
    {
        public const int NameMaxLength = 100;
        public const int MinimumAllowedAge = 0;
        public const int MaximumAllowedAge = 99;
        public const int PhoneNumberLength = PhoneNumber.Length;
    }

    private Patient() { } // EF Core

    private Patient(
        string name,
        int? age,
        Gender gender,
        PhoneNumber? phoneNumber)
    {
        Name = name;
        Age = age;
        Gender = gender;
        PhoneNumber = phoneNumber;
    }


    public string Name { get; set; } = string.Empty;
    public int? Age { get; private set; }
    public Gender Gender { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; } = default!;

    public ICollection<Appointment> Appointments { get; private set; } = [];
    public ICollection<Prescription> Prescriptions { get; private set; } = [];
    public ICollection<Visit> Visits { get; private set; } = [];


    public static Result<Patient> Create(
        string name,
        int? age,
        Gender gender,
        PhoneNumber? phoneNumber)
    {
        name = name.Trim();

        var validateResult = Validate(age, name);
        if (validateResult.IsFailure)
            return Result.Failure<Patient>(validateResult.Error);

        return new Patient(name, age, gender, phoneNumber);
    }

    public Result Update(
        string name,
        int? age,
        Gender gender,
        PhoneNumber? phoneNumber)
    {
        var validateResult = Validate(age, name);
        if (validateResult.IsFailure)
            return Result.Failure(validateResult.Error);

        this.Name = name;
        this.Age = age;
        this.Gender = gender;
        this.PhoneNumber = phoneNumber;

        return Result.Success();
    }


    private static Result Validate(int? age, string name)
    {
        if (age.HasValue)
        {
            if (age.Value < Constants.MinimumAllowedAge)
            {
                return Result.Failure(DomainErrors.Entities.Patient.Age.LessThanMinimumAllowedAge);
            }

            if (age.Value > Constants.MaximumAllowedAge)
            {
                return Result.Failure(DomainErrors.Entities.Patient.Age.GreaterThanMaximumAllowedAge);
            }
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure(DomainErrors.Entities.Patient.Name.Empty);
        }

        if (name.Length > Constants.NameMaxLength)
        {
            return Result.Failure(DomainErrors.Entities.Patient.Name.TooLong);
        }

        return Result.Success();
    }
}