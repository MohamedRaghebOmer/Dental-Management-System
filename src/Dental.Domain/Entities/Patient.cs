using Dental.Domain.Enums;
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
        public const int MinimumAllowedAge = DateOfBirth.MinimumAge;
        public const int MaximumAllowedAge = DateOfBirth.MaximumAge;
        public const int PhoneNumberLength = PhoneNumber.Length;
        public const int AddressMaxLength = 500;
    }

    private Patient() { } // EF Core

    private Patient(
        FirstName firstName,
        LastName lastName,
        DateOfBirth? dateOfBirth,
        Gender gender,
        PhoneNumber? phoneNumber,
        string? address)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        PhoneNumber = phoneNumber;
        Address = address;
    }

    public FirstName FirstName { get; private set; } = default!;
    public LastName LastName { get; private set; } = default!;
    public string FullName => $"{FirstName.Value} {LastName.Value}";
    public DateOfBirth? DateOfBirth { get; private set; }
    public int? Age => DateOfBirth?.CalculateAge();
    public Gender Gender { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; } = default!;
    public string? Address { get; private set; }

    public ICollection<Appointment> Appointments { get; private set; } = [];
    public ICollection<Prescription> Prescriptions { get; private set; } = [];

    public static Result<Patient> Create(
        FirstName firstName,
        LastName lastName,
        DateOfBirth? date,
        Gender gender,
        PhoneNumber? phoneNumber,
        string? address)
    {
        return new Patient(firstName, lastName, date, gender, phoneNumber, address?.Trim());
    }

    public Result Update(
        FirstName firstName,
        LastName lastName,
        DateOfBirth? date,
        Gender gender,
        PhoneNumber? phoneNumber,
        string? address)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.DateOfBirth = date;
        this.Gender = gender;
        this.PhoneNumber = phoneNumber;
        this.Address = address?.Trim();

        return Result.Success();
    }
}