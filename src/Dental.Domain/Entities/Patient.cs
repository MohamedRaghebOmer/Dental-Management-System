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
        public const int FirstNameMaxLength = FirstName.MaxLength;
        public const int LastNameMaxLength = LastName.MaxLength;
        public const int MinimumAllowedAge = 0;
        public const int MaximumAllowedAge = 99;
        public const int PhoneNumberLength = PhoneNumber.Length;
    }

    private Patient() { } // EF Core

    private Patient(
        FirstName firstName,
        LastName lastName,
        int age,
        Gender gender,
        PhoneNumber? phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Gender = gender;
        PhoneNumber = phoneNumber;
    }


    public FirstName FirstName { get; private set; } = default!;
    public LastName LastName { get; private set; } = default!;
    public string FullName => $"{FirstName.Value} {LastName.Value}";
    public int Age { get; private set; }
    public Gender Gender { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; } = default!;

    public ICollection<Appointment> Appointments { get; private set; } = [];
    public ICollection<Prescription> Prescriptions { get; private set; } = [];


    public static Result<Patient> Create(
        FirstName firstName,
        LastName lastName,
        int age,
        Gender gender,
        PhoneNumber? phoneNumber)
    {
        var validateResult = Validate(age);
        if (validateResult.IsFailure)
            return Result.Failure<Patient>(validateResult.Error);

        return new Patient(firstName, lastName, age, gender, phoneNumber);
    }

    public Result Update(
        FirstName firstName,
        LastName lastName,
        int age,
        Gender gender,
        PhoneNumber? phoneNumber)
    {
        var validateResult = Validate(age);
        if (validateResult.IsFailure)
            return Result.Failure(validateResult.Error);

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Gender = gender;
        this.PhoneNumber = phoneNumber;

        return Result.Success();
    }


    private static Result Validate(int age)
    {
        if (age < Constants.MinimumAllowedAge)
        {
            return Result.Failure(DomainErrors.Entities.Patient.Age.LessThanMinimumAllowedAge);
        }

        if (age > Constants.MaximumAllowedAge)
        {
            return Result.Failure(DomainErrors.Entities.Patient.Age.GreaterThanMaximumAllowedAge);
        }

        return Result.Success();
    }
}