using Dental.Application.DTOs.Patient;
using Dental.Application.Errors;
using Dental.Application.Services;
using Dental.Domain.Entities;
using Dental.Domain.Enums;
using Dental.Domain.Errors;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.ValueObjects;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Dental.UnitTests.Application.Services;

public class PatientServiceTests
{
    private readonly Mock<IRepository<Patient>> _repoMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<ILogger<PatientService>> _loggerMock;
    private readonly PatientService _sut;

    public PatientServiceTests()
    {
        _repoMock = new Mock<IRepository<Patient>>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _loggerMock = new Mock<ILogger<PatientService>>();
        _sut = new PatientService(_repoMock.Object, _unitOfWorkMock.Object, _loggerMock.Object);
    }

    // ------------------------------------------------------------------
    // Test data builders
    // ------------------------------------------------------------------

    private static CreatePatientDto ValidCreateDto(
        string firstName = "John",
        string lastName = "Doe",
        DateOnly? dateOfBirth = null,
        Gender gender = Gender.Male,
        string? phoneNumber = "01012345678",
        string? address = "123 Main St") =>
        new()
        {
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth,
            Gender = gender,
            PhoneNumber = phoneNumber,
            Address = address
        };

    private static UpdatePatientDto ValidUpdateDto(
        string firstName = "Jane",
        string lastName = "Smith",
        DateOnly? dateOfBirth = null,
        Gender gender = Gender.Female,
        string? phoneNumber = "01098765432",
        string? address = "456 Side St") =>
        new()
        {
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth,
            Gender = gender,
            PhoneNumber = phoneNumber,
            Address = address
        };

    private static Patient ExistingPatient(int id = 1) =>
        Patient.Create(
            FirstName.Create("Old").Value,
            LastName.Create("Name").Value,
            DateOfBirth.Create(DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-40))).Value,
            Gender.Male,
            PhoneNumber.Create("01011122233").Value,
            "Old Address").Value;

    // ====================================================================
    // CreatePatient
    // ====================================================================

    [Fact]
    public async Task CreatePatient_WithValidData_AddsPatientSavesChangesAndReturnsSuccess()
    {
        // Arrange
        var dto = ValidCreateDto();
        Patient? capturedPatient = null;

        _repoMock
            .Setup(r => r.AddAsync(It.IsAny<Patient>(), It.IsAny<CancellationToken>()))
            .Callback<Patient, CancellationToken>((p, _) => capturedPatient = p)
            .Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CreatePatient(dto);

        // Assert
        result.IsSuccess.Should().BeTrue();

        capturedPatient.Should().NotBeNull();
        capturedPatient!.FirstName.Value.Should().Be(dto.FirstName);
        capturedPatient.LastName.Value.Should().Be(dto.LastName);
        capturedPatient.Gender.Should().Be(dto.Gender);
        capturedPatient.PhoneNumber!.Value.Should().Be(dto.PhoneNumber);
        capturedPatient.Address.Should().Be(dto.Address);

        _repoMock.Verify(r => r.AddAsync(It.IsAny<Patient>(), It.IsAny<CancellationToken>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CreatePatient_WithNullDateOfBirthAndPhoneNumber_SucceedsWithNullOptionalValues()
    {
        // Arrange
        var dto = ValidCreateDto(dateOfBirth: null, phoneNumber: null);
        Patient? capturedPatient = null;

        _repoMock
            .Setup(r => r.AddAsync(It.IsAny<Patient>(), It.IsAny<CancellationToken>()))
            .Callback<Patient, CancellationToken>((p, _) => capturedPatient = p)
            .Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CreatePatient(dto);

        // Assert
        result.IsSuccess.Should().BeTrue();
        capturedPatient!.DateOfBirth.Should().BeNull();
        capturedPatient!.PhoneNumber.Should().BeNull();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public async Task CreatePatient_WithEmptyFirstName_ReturnsFailureAndDoesNotPersist(string? firstName)
    {
        // Arrange
        var dto = ValidCreateDto(firstName: firstName!);

        // Act
        var result = await _sut.CreatePatient(dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.FirstName.Empty);

        _repoMock.Verify(r => r.AddAsync(It.IsAny<Patient>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreatePatient_WithFirstNameTooLong_ReturnsFailureAndDoesNotPersist()
    {
        // Arrange
        var dto = ValidCreateDto(firstName: new string('a', FirstName.MaxLength + 1));

        // Act
        var result = await _sut.CreatePatient(dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.FirstName.TooLong);
        _repoMock.Verify(r => r.AddAsync(It.IsAny<Patient>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreatePatient_WithFirstNameAtMaxLength_Succeeds()
    {
        // Arrange - boundary: exactly MaxLength should be valid
        var dto = ValidCreateDto(firstName: new string('a', FirstName.MaxLength));

        _repoMock
            .Setup(r => r.AddAsync(It.IsAny<Patient>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CreatePatient(dto);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public async Task CreatePatient_WithEmptyLastName_ReturnsFailureAndDoesNotPersist(string? lastName)
    {
        // Arrange
        var dto = ValidCreateDto(lastName: lastName!);

        // Act
        var result = await _sut.CreatePatient(dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.LastName.Empty);
        _repoMock.Verify(r => r.AddAsync(It.IsAny<Patient>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreatePatient_WithLastNameTooLong_ReturnsFailureAndDoesNotPersist()
    {
        // Arrange
        var dto = ValidCreateDto(lastName: new string('b', LastName.MaxLength + 1));

        // Act
        var result = await _sut.CreatePatient(dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.LastName.TooLong);
        _repoMock.Verify(r => r.AddAsync(It.IsAny<Patient>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreatePatient_WithDateOfBirthYoungerThanMinimumAge_ReturnsFailure()
    {
        // Arrange - born this calendar year => age 0, below MinimumAge (1)
        var dto = ValidCreateDto(dateOfBirth: new DateOnly(DateTime.UtcNow.Year, 1, 1));

        // Act
        var result = await _sut.CreatePatient(dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.DateOfBirth.LessThanMinimumAllowedAge);
        _repoMock.Verify(r => r.AddAsync(It.IsAny<Patient>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreatePatient_WithDateOfBirthOlderThanMaximumAge_ReturnsFailure()
    {
        // Arrange - older than MaximumAge (100)
        var dto = ValidCreateDto(
            dateOfBirth: new DateOnly(DateTime.UtcNow.Year - DateOfBirth.MaximumAge - 1, 1, 1));

        // Act
        var result = await _sut.CreatePatient(dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.DateOfBirth.OlderThanMaximumAllowedAge);
        _repoMock.Verify(r => r.AddAsync(It.IsAny<Patient>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreatePatient_WithDateOfBirthExactlyAtMinimumAge_Succeeds()
    {
        // Arrange - boundary: exactly MinimumAge years old should be valid
        var dto = ValidCreateDto(
            dateOfBirth: new DateOnly(DateTime.UtcNow.Year - DateOfBirth.MinimumAge, 1, 1));

        _repoMock
            .Setup(r => r.AddAsync(It.IsAny<Patient>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CreatePatient(dto);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Theory]
    [InlineData("123")]
    [InlineData("123456789012")]
    [InlineData("abc")]
    public async Task CreatePatient_WithInvalidPhoneNumberLength_ReturnsFailure(string invalidPhoneNumber)
    {
        // Arrange
        var dto = ValidCreateDto(phoneNumber: invalidPhoneNumber);

        // Act
        var result = await _sut.CreatePatient(dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.PhoneNumber.Invalid);
        _repoMock.Verify(r => r.AddAsync(It.IsAny<Patient>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreatePatient_ValidatesInOrder_FirstNameBeforeOtherFields()
    {
        // Arrange - everything is invalid; only the FirstName error should surface
        var dto = ValidCreateDto(
            firstName: "",
            lastName: "",
            dateOfBirth: new DateOnly(DateTime.UtcNow.Year, 1, 1),
            phoneNumber: "1");

        // Act
        var result = await _sut.CreatePatient(dto);

        // Assert
        result.Error.Should().Be(DomainErrors.Patients.FirstName.Empty);
    }

    // ====================================================================
    // UpdatePatient
    // ====================================================================

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-50)]
    public async Task UpdatePatient_WithInvalidId_ReturnsFailureAndNeverQueriesRepository(int invalidId)
    {
        // Act
        var result = await _sut.UpdatePatient(invalidId, ValidUpdateDto());

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);

        _repoMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdatePatient_WhenPatientDoesNotExist_ReturnsFailureWithNotFound()
    {
        // Arrange
        const int id = 1;
        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Patient?)null);

        // Act
        var result = await _sut.UpdatePatient(id, ValidUpdateDto());

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.NotFound);
    }

    [Fact]
    public async Task UpdatePatient_WithValidData_UpdatesPatientInPlaceSavesChangesAndReturnsSuccess()
    {
        // Arrange
        const int id = 1;
        var existingPatient = ExistingPatient(id);
        var dto = ValidUpdateDto();

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingPatient);

        // Act
        var result = await _sut.UpdatePatient(id, dto);

        // Assert
        result.IsSuccess.Should().BeTrue();

        existingPatient.FirstName.Value.Should().Be(dto.FirstName);
        existingPatient.LastName.Value.Should().Be(dto.LastName);
        existingPatient.Gender.Should().Be(dto.Gender);
        existingPatient.PhoneNumber!.Value.Should().Be(dto.PhoneNumber);
        existingPatient.Address.Should().Be(dto.Address);
        existingPatient.DateOfBirth!.Value.Should().Be(dto.DateOfBirth);

        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdatePatient_WhenValidationFails_DoesNotCallSaveChangesAsync()
    {
        // Arrange - SaveChangesAsync must only run after every validation step
        // and Patient.Update itself succeed.
        const int id = 1;
        var existingPatient = ExistingPatient(id);
        var dto = ValidUpdateDto(firstName: "");

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingPatient);

        // Act
        await _sut.UpdatePatient(id, dto);

        // Assert
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdatePatient_CallsPatientUpdateBeforeSaveChangesAsync()
    {
        // Arrange - guards the ordering: the entity must be mutated via
        // Patient.Update before changes are flushed through the unit of work.
        const int id = 1;
        var existingPatient = ExistingPatient(id);
        var dto = ValidUpdateDto();

        _unitOfWorkMock
            .Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .Callback(() =>
            {
                // By the time SaveChangesAsync runs, the entity must already be updated.
                existingPatient.FirstName.Value.Should().Be(dto.FirstName);
            })
            .Returns(Task.CompletedTask);

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingPatient);

        // Act
        var result = await _sut.UpdatePatient(id, dto);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task UpdatePatient_WithEmptyFirstName_ReturnsFailureAndDoesNotMutateEntity(string firstName)
    {
        // Arrange
        const int id = 1;
        var existingPatient = ExistingPatient(id);
        var originalFirstName = existingPatient.FirstName.Value;
        var dto = ValidUpdateDto(firstName: firstName);

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingPatient);

        // Act
        var result = await _sut.UpdatePatient(id, dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.FirstName.Empty);
        existingPatient.FirstName.Value.Should().Be(originalFirstName);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdatePatient_WithLastNameTooLong_ReturnsFailureAndDoesNotMutateEntity()
    {
        // Arrange
        const int id = 1;
        var existingPatient = ExistingPatient(id);
        var originalLastName = existingPatient.LastName.Value;
        var dto = ValidUpdateDto(lastName: new string('z', LastName.MaxLength + 1));

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingPatient);

        // Act
        var result = await _sut.UpdatePatient(id, dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.LastName.TooLong);
        existingPatient.LastName.Value.Should().Be(originalLastName);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdatePatient_WithDateOfBirthOlderThanMaximumAge_ReturnsFailureAndDoesNotMutateEntity()
    {
        // Arrange
        const int id = 1;
        var existingPatient = ExistingPatient(id);
        var originalDob = existingPatient.DateOfBirth!.Value;
        var dto = ValidUpdateDto(
            dateOfBirth: new DateOnly(DateTime.UtcNow.Year - DateOfBirth.MaximumAge - 1, 1, 1));

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingPatient);

        // Act
        var result = await _sut.UpdatePatient(id, dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.DateOfBirth.OlderThanMaximumAllowedAge);
        existingPatient.DateOfBirth!.Value.Should().Be(originalDob);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("123456789012")]
    public async Task UpdatePatient_WithInvalidPhoneNumberLength_ReturnsFailureAndDoesNotMutateEntity(string invalidPhone)
    {
        // Arrange
        const int id = 1;
        var existingPatient = ExistingPatient(id);
        var originalPhone = existingPatient.PhoneNumber!.Value;
        var dto = ValidUpdateDto(phoneNumber: invalidPhone);

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingPatient);

        // Act
        var result = await _sut.UpdatePatient(id, dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Patients.PhoneNumber.Invalid);
        existingPatient.PhoneNumber!.Value.Should().Be(originalPhone);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdatePatient_WithNullPhoneNumberAndDateOfBirth_SucceedsAndClearsOptionalValues()
    {
        // Arrange
        const int id = 1;
        var existingPatient = ExistingPatient(id);
        var dto = ValidUpdateDto(phoneNumber: null, dateOfBirth: null);

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingPatient);

        // Act
        var result = await _sut.UpdatePatient(id, dto);

        // Assert
        result.IsSuccess.Should().BeTrue();
        existingPatient.PhoneNumber.Should().BeNull();
        existingPatient.DateOfBirth.Should().BeNull();
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdatePatient_TrimsAddressWhitespace()
    {
        // Arrange
        const int id = 1;
        var existingPatient = ExistingPatient(id);
        var dto = ValidUpdateDto(address: "  123 Trimmed St  ");

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingPatient);

        // Act
        var result = await _sut.UpdatePatient(id, dto);

        // Assert
        result.IsSuccess.Should().BeTrue();
        existingPatient.Address.Should().Be("123 Trimmed St");
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}