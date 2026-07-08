using Dental.Domain.Entities;
using Dental.Domain.Enums;
using Dental.Domain.Errors;
using Dental.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Dental.UnitTests.Domain;

// ============================================================================
// FirstName
// ============================================================================

public class FirstNameTests
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Create_WithEmptyOrWhitespaceValue_ReturnsFailure(string? value)
    {
        var result = FirstName.Create(value!);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.FirstName.Empty);
    }

    [Fact]
    public void Create_WithValueLongerThanMaxLength_ReturnsFailure()
    {
        var value = new string('a', FirstName.MaxLength + 1);

        var result = FirstName.Create(value);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.FirstName.TooLong);
    }

    [Fact]
    public void Create_WithValueAtExactlyMaxLength_Succeeds()
    {
        var value = new string('a', FirstName.MaxLength);

        var result = FirstName.Create(value);

        result.IsSuccess.Should().BeTrue();
        result.Value.Value.Should().Be(value);
    }

    [Fact]
    public void Create_WithValidValue_ReturnsSuccessWithMatchingValue()
    {
        var result = FirstName.Create("John");

        result.IsSuccess.Should().BeTrue();
        result.Value.Value.Should().Be("John");
    }

    [Fact]
    public void TwoInstances_WithSameValue_AreEqual()
    {
        // FirstName is a record - equality should be structural (value-based),
        // not reference-based.
        var first = FirstName.Create("John").Value;
        var second = FirstName.Create("John").Value;

        first.Should().Be(second);
        (first == second).Should().BeTrue();
    }

    [Fact]
    public void TwoInstances_WithDifferentValue_AreNotEqual()
    {
        var first = FirstName.Create("John").Value;
        var second = FirstName.Create("Jane").Value;

        first.Should().NotBe(second);
    }

    [Fact]
    public void FromDatabase_BypassesValidation_EvenForInvalidLength()
    {
        // FromDatabase is documented to skip validation entirely - confirm that
        // contract holds, since callers rely on it for already-trusted data.
        var tooLong = new string('a', FirstName.MaxLength + 100);

        var firstName = FirstName.FromDatabase(tooLong);

        firstName.Value.Should().Be(tooLong);
    }
}

// ============================================================================
// LastName
// ============================================================================

public class LastNameTests
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Create_WithEmptyOrWhitespaceValue_ReturnsFailure(string? value)
    {
        var result = LastName.Create(value!);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.LastName.Empty);
    }

    [Fact]
    public void Create_WithValueLongerThanMaxLength_ReturnsFailure()
    {
        var value = new string('b', LastName.MaxLength + 1);

        var result = LastName.Create(value);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.LastName.TooLong);
    }

    [Fact]
    public void Create_WithValueAtExactlyMaxLength_Succeeds()
    {
        var value = new string('b', LastName.MaxLength);

        var result = LastName.Create(value);

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void Create_WithValidValue_ReturnsSuccessWithMatchingValue()
    {
        var result = LastName.Create("Doe");

        result.IsSuccess.Should().BeTrue();
        result.Value.Value.Should().Be("Doe");
    }

    [Fact]
    public void TwoInstances_WithSameValue_AreEqual()
    {
        var first = LastName.Create("Doe").Value;
        var second = LastName.Create("Doe").Value;

        first.Should().Be(second);
    }

    [Fact]
    public void FromDatabase_BypassesValidation()
    {
        var lastName = LastName.FromDatabase("");

        lastName.Value.Should().BeEmpty();
    }
}

// ============================================================================
// DateOfBirth
// ============================================================================

public class DateOfBirthTests
{
    [Fact]
    public void Create_WithDateYoungerThanMinimumAge_ReturnsFailure()
    {
        // Born this calendar year => age 0, below MinimumAge (1)
        var value = new DateOnly(DateTime.UtcNow.Year, 1, 1);

        var result = DateOfBirth.Create(value);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.DateOfBirth.LessThanMinimumAllowedAge);
    }

    [Fact]
    public void Create_WithDateOlderThanMaximumAge_ReturnsFailure()
    {
        var value = new DateOnly(DateTime.UtcNow.Year - DateOfBirth.MaximumAge - 1, 1, 1);

        var result = DateOfBirth.Create(value);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.DateOfBirth.OlderThanMaximumAllowedAge);
    }

    [Fact]
    public void Create_WithDateExactlyAtMinimumAgeBoundary_Succeeds()
    {
        var value = new DateOnly(DateTime.UtcNow.Year - DateOfBirth.MinimumAge, 1, 1);

        var result = DateOfBirth.Create(value);

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void Create_WithDateExactlyAtMaximumAgeBoundary_Succeeds()
    {
        var value = DateOnly
            .FromDateTime(DateTime.UtcNow)
            .AddYears(-DateOfBirth.MaximumAge);

        var result = DateOfBirth.Create(value);
        
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void Create_WithValidDate_StoresTheProvidedValue()
    {
        var value = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-30));

        var result = DateOfBirth.Create(value);

        result.IsSuccess.Should().BeTrue();
        result.Value.Value.Should().Be(value);
    }

    [Fact]
    public void CalculateAge_ComputesDifferenceByCalendarYearOnly()
    {
        // NOTE: CalculateAge subtracts calendar years only (UtcNow.Year - Value.Year).
        // It does NOT check whether the birthday has occurred yet this year, so the
        // result can be off by one compared to a "true" age calculation once the
        // person's actual birthday hasn't happened yet this calendar year.
        var birthYear = DateTime.UtcNow.Year - 25;
        var dateOfBirth = DateOfBirth.Create(new DateOnly(birthYear, 1, 1)).Value;

        var age = dateOfBirth.CalculateAge();

        age.Should().Be(25);
    }

    [Fact]
    public void FromDatabase_BypassesValidation_EvenForOutOfRangeDate()
    {
        var farFuture = new DateOnly(DateTime.UtcNow.Year + 50, 1, 1);

        var dateOfBirth = DateOfBirth.FromDatabase(farFuture);

        dateOfBirth.Value.Should().Be(farFuture);
    }
}

// ============================================================================
// PhoneNumber
// ============================================================================

public class PhoneNumberTests
{

    [Theory]
    [InlineData("123")]
    [InlineData("123456789012")]
    [InlineData("1234567890")] // one short of 11
    public void Create_WithIncorrectLength_ReturnsFailure(string value)
    {
        var result = PhoneNumber.Create(value);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.PhoneNumber.Invalid);
    }

    [Fact]
    public void Create_WithValueOfExactlyRequiredLength_Succeeds()
    {
        var value = new string('1', PhoneNumber.Length);

        var result = PhoneNumber.Create(value);

        result.IsSuccess.Should().BeTrue();
        result.Value!.Value.Should().Be(value);
    }

    [Fact]
    public void Create_TrimsSurroundingWhitespaceBeforeValidatingLength()
    {
        var value = "  01012345678  ";

        var result = PhoneNumber.Create(value);

        result.IsSuccess.Should().BeTrue();
        result.Value!.Value.Should().Be("01012345678");
    }

    [Fact]
    public void FromDatabase_BypassesValidation()
    {
        var phoneNumber = PhoneNumber.FromDatabase("12");

        phoneNumber.Value.Should().Be("12");
    }
}

// ============================================================================
// Patient entity
// ============================================================================

public class PatientTests
{
    private static FirstName ValidFirstName => FirstName.Create("John").Value;
    private static LastName ValidLastName => LastName.Create("Doe").Value;

    private static DateOfBirth? ValidDateOfBirth =>
        DateOfBirth.Create(DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-30))).Value;

    private static PhoneNumber? ValidPhoneNumber => PhoneNumber.Create("01012345678").Value;

    [Fact]
    public void Create_WithValidValueObjects_ReturnsSuccess()
    {
        var result = Patient.Create(
            ValidFirstName,
            ValidLastName,
            ValidDateOfBirth,
            Gender.Male,
            ValidPhoneNumber,
            "123 Main St");

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void Create_SetsAllPropertiesFromArguments()
    {
        var firstName = ValidFirstName;
        var lastName = ValidLastName;
        var dateOfBirth = ValidDateOfBirth;
        var phoneNumber = ValidPhoneNumber;

        var patient = Patient.Create(
            firstName, lastName, dateOfBirth, Gender.Female, phoneNumber, "123 Main St").Value;

        patient.FirstName.Should().Be(firstName);
        patient.LastName.Should().Be(lastName);
        patient.DateOfBirth.Should().Be(dateOfBirth);
        patient.Gender.Should().Be(Gender.Female);
        patient.PhoneNumber.Should().Be(phoneNumber);
        patient.Address.Should().Be("123 Main St");
    }

    [Fact]
    public void Create_TrimsLeadingAndTrailingWhitespaceFromAddress()
    {
        var patient = Patient.Create(
            ValidFirstName, ValidLastName, ValidDateOfBirth, Gender.Male, ValidPhoneNumber,
            "   123 Main St   ").Value;

        patient.Address.Should().Be("123 Main St");
    }

    [Fact]
    public void Create_WithNullAddress_KeepsAddressNull()
    {
        var patient = Patient.Create(
            ValidFirstName, ValidLastName, ValidDateOfBirth, Gender.Male, ValidPhoneNumber, null).Value;

        patient.Address.Should().BeNull();
    }

    [Fact]
    public void Create_WithNullDateOfBirthAndPhoneNumber_Succeeds()
    {
        var result = Patient.Create(
            ValidFirstName, ValidLastName, null, Gender.Male, null, null);

        result.IsSuccess.Should().BeTrue();
        result.Value.DateOfBirth.Should().BeNull();
        result.Value.PhoneNumber.Should().BeNull();
        result.Value.Age.Should().BeNull();
    }

    [Fact]
    public void FullName_CombinesFirstAndLastNameWithASingleSpace()
    {
        var firstName = FirstName.Create("Ada").Value;
        var lastName = LastName.Create("Lovelace").Value;

        var patient = Patient.Create(
            firstName, lastName, null, Gender.Female, null, null).Value;

        patient.FullName.Should().Be("Ada Lovelace");
    }

    [Fact]
    public void Age_WhenDateOfBirthIsSet_ReflectsCalculateAgeResult()
    {
        var dateOfBirth = DateOfBirth.Create(
            new DateOnly(DateTime.UtcNow.Year - 40, 6, 1)).Value;

        var patient = Patient.Create(
            ValidFirstName, ValidLastName, dateOfBirth, Gender.Male, null, null).Value;

        patient.Age.Should().Be(40);
    }

    [Fact]
    public void Age_WhenDateOfBirthIsNull_IsNull()
    {
        var patient = Patient.Create(
            ValidFirstName, ValidLastName, null, Gender.Male, null, null).Value;

        patient.Age.Should().BeNull();
    }

    [Fact]
    public void Update_ReturnsSuccessAndMutatesEntityInPlace()
    {
        var patient = Patient.Create(
            ValidFirstName, ValidLastName, ValidDateOfBirth, Gender.Male, ValidPhoneNumber, "Old Address").Value;

        var newFirstName = FirstName.Create("Jane").Value;
        var newLastName = LastName.Create("Smith").Value;
        var newDateOfBirth = DateOfBirth.Create(DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-22))).Value;
        var newPhoneNumber = PhoneNumber.Create("09876543210").Value;

        var result = patient.Update(
            newFirstName, newLastName, newDateOfBirth, Gender.Female, newPhoneNumber, "New Address");

        result.IsSuccess.Should().BeTrue();
        patient.FirstName.Should().Be(newFirstName);
        patient.LastName.Should().Be(newLastName);
        patient.DateOfBirth.Should().Be(newDateOfBirth);
        patient.Gender.Should().Be(Gender.Female);
        patient.PhoneNumber.Should().Be(newPhoneNumber);
        patient.Address.Should().Be("New Address");
    }

    [Fact]
    public void Update_TrimsAddressWhitespace()
    {
        var patient = Patient.Create(
            ValidFirstName, ValidLastName, null, Gender.Male, null, null).Value;

        patient.Update(ValidFirstName, ValidLastName, null, Gender.Male, null, "  456 New St  ");

        patient.Address.Should().Be("456 New St");
    }

    [Fact]
    public void Update_WithNullDateOfBirthAndPhoneNumber_ClearsThoseFields()
    {
        var patient = Patient.Create(
            ValidFirstName, ValidLastName, ValidDateOfBirth, Gender.Male, ValidPhoneNumber, null).Value;

        patient.Update(ValidFirstName, ValidLastName, null, Gender.Male, null, null);

        patient.DateOfBirth.Should().BeNull();
        patient.PhoneNumber.Should().BeNull();
        patient.Age.Should().BeNull();
    }

    [Fact]
    public void Update_DoesNotChangeTheEntityId()
    {
        var patient = Patient.Create(
            ValidFirstName, ValidLastName, null, Gender.Male, null, null).Value;
        var originalId = patient.Id;

        patient.Update(ValidFirstName, ValidLastName, null, Gender.Female, null, null);

        patient.Id.Should().Be(originalId);
    }

    // ============================================================================
    // Entity equality (via Patient, exercising Entity's shared base behavior)
    // ============================================================================

    public class PatientEntityEqualityTests
    {
        private static Patient NewPatient(string firstName = "John") =>
            Patient.Create(
                FirstName.Create(firstName).Value,
                LastName.Create("Doe").Value,
                null,
                Gender.Male,
                null,
                null).Value;

        [Fact]
        public void TwoDistinctUnsavedPatients_AreConsideredEqual_BecauseBothHaveDefaultId()
        {
            // IMPORTANT BEHAVIOR TO BE AWARE OF: Entity equality is based solely on
            // Id + runtime type. Since Patient.Create never assigns an Id (that only
            // happens once EF Core persists the entity), two freshly created, never-saved
            // Patient instances are treated as equal even though their data differs.
            // This is easy to trip over in in-memory collections (HashSet<Patient>,
            // Dictionary keyed by entity, etc.) before the entities are saved.
            var patientA = NewPatient("John");
            var patientB = NewPatient("Jane");

            patientA.Should().Be(patientB);
            (patientA == patientB).Should().BeTrue();
            patientA.GetHashCode().Should().Be(patientB.GetHashCode());
        }

        [Fact]
        public void SamePatientReference_IsEqualToItself()
        {
            var patient = NewPatient();

            patient.Should().Be(patient);
            (patient == patient).Should().BeTrue();
        }

        [Fact]
        public void PatientComparedToNull_IsNotEqual()
        {
            var patient = NewPatient();

            patient!.Equals(null).Should().BeFalse();
            (patient == null).Should().BeFalse();
            (null == patient).Should().BeFalse();
        }

        [Fact]
        public void TwoNullPatientReferences_AreEqualViaOperator()
        {
            Patient? left = null;
            Patient? right = null;

            (left == right).Should().BeTrue();
        }

        [Fact]
        public void InequalityOperator_IsConsistentWithEqualityOperator()
        {
            var patientA = NewPatient("John");
            var patientB = NewPatient("Jane");

            // Both have default Id 0, so they ARE equal per current Entity semantics -
            // != must therefore report false, consistent with ==.
            (patientA != patientB).Should().BeFalse();
        }

        [Fact]
        public void PatientComparedToDifferentEntityType_IsNotEqual_EvenWithSameId()
        {
            // Entity.Equals checks GetType() as well as Id, so two different entity
            // subclasses can never be equal, even if both happen to have Id 0.
            var patient = NewPatient();
            var service = Service.Create(
                ServiceName.Create("Cleaning").Value,
                Money.Create(50m).Value,
                null).Value;

            patient.Equals(service).Should().BeFalse();
        }
    }
}