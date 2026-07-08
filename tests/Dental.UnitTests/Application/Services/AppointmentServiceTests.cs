using Dental.Application.Abstractions;
using Dental.Application.DTOs.Appointment;
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

public class AppointmentServiceTests
{
    private readonly Mock<IRepository<Appointment>> _repositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<ILogger<ServiceBase<Appointment, AppointmentResponseDto>>> _loggerMock;
    private readonly AppointmentService _sut;

    public AppointmentServiceTests()
    {
        _repositoryMock = new Mock<IRepository<Appointment>>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _loggerMock = new Mock<ILogger<ServiceBase<Appointment, AppointmentResponseDto>>>();

        _sut = new AppointmentService(
            _repositoryMock.Object,
            _unitOfWorkMock.Object,
            _loggerMock.Object);
    }

    private static Appointment CreateValidAppointment(
        int patientId = 1,
        DateTime? appointmentDate = null,
        string? notes = "Routine checkup")
    {
        var patientId2 = Id.Create(patientId).Value;
        var result = Appointment.Create(
            patientId2,
            appointmentDate ?? DateTime.UtcNow.AddDays(1),
            notes);

        return result.Value;
    }

    // ----- CreateAsync -----

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task CreateAsync_PatientIdIsZeroOrNegative_ReturnsFailureAndNeverAddsToRepository(int invalidPatientId)
    {
        var dto = new CreateAppointmentDto
        {
            PatientId = invalidPatientId,
            AppointmentDate = DateTime.UtcNow.AddDays(1),
            Notes = "First visit"
        };

        var result = await _sut.CreateAsync(dto);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Id.InvalidId);
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Appointment>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateAsync_AppointmentDateInThePast_ReturnsFailureAndNeverAddsToRepository()
    {
        var dto = new CreateAppointmentDto
        {
            PatientId = 1,
            AppointmentDate = DateTime.UtcNow.AddDays(-1),
            Notes = "First visit"
        };

        var result = await _sut.CreateAsync(dto);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Date.InThePast);
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Appointment>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateAsync_NotesExceedMaxLength_ReturnsFailureAndNeverAddsToRepository()
    {
        var dto = new CreateAppointmentDto
        {
            PatientId = 1,
            AppointmentDate = DateTime.UtcNow.AddDays(1),
            Notes = new string('x', Appointment.Constants.NotesMaxLength + 1)
        };

        var result = await _sut.CreateAsync(dto);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Notes.TooLong);
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Appointment>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateAsync_ValidDto_AddsAppointmentCommitsAndReturnsCreatedId()
    {
        var dto = new CreateAppointmentDto
        {
            PatientId = 1,
            AppointmentDate = DateTime.UtcNow.AddDays(2),
            Notes = "Cleaning"
        };

        Appointment? addedAppointment = null;
        _repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Appointment>(), It.IsAny<CancellationToken>()))
            .Callback<Appointment, CancellationToken>((a, _) => addedAppointment = a)
            .Returns(Task.CompletedTask);

        var result = await _sut.CreateAsync(dto);

        result.IsSuccess.Should().BeTrue();
        addedAppointment.Should().NotBeNull();
        result.Value.Should().Be(addedAppointment!.Id);
        addedAppointment.PatientId.Value.Should().Be(dto.PatientId);
        addedAppointment.Notes.Should().Be(dto.Notes);
        addedAppointment.Status.Should().Be(AppointmentStatus.Pending);
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Appointment>(), It.IsAny<CancellationToken>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    // ----- UpdateAsync -----

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task UpdateAsync_AppointmentIdIsZeroOrNegative_ReturnsInvalidIdFailure(int invalidId)
    {
        var dto = new UpdateAppointmentDto { PatientId = 1, AppointmentDate = DateTime.UtcNow.AddDays(1), Notes = null };

        var result = await _sut.UpdateAsync(invalidId, dto);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateAsync_AppointmentNotFound_ReturnsNotFoundFailure()
    {
        var dto = new UpdateAppointmentDto { PatientId = 1, AppointmentDate = DateTime.UtcNow.AddDays(1), Notes = null };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(5, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Appointment?)null);

        var result = await _sut.UpdateAsync(5, dto);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.NotFound);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task UpdateAsync_PatientIdIsZeroOrNegative_ReturnsFailureAndNeverCommits(int invalidPatientId)
    {
        var existing = CreateValidAppointment();
        var dto = new UpdateAppointmentDto { PatientId = invalidPatientId, AppointmentDate = DateTime.UtcNow.AddDays(1), Notes = null };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(5, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existing);

        var result = await _sut.UpdateAsync(5, dto);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Id.InvalidId);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateAsync_ValidDtoOnPendingAppointment_UpdatesFieldsAndCommits()
    {
        var existing = CreateValidAppointment(patientId: 1, notes: "Old note");
        var dto = new UpdateAppointmentDto
        {
            PatientId = 2,
            AppointmentDate = DateTime.UtcNow.AddDays(5),
            Notes = "New note"
        };

        _repositoryMock
            .Setup(r => r.GetByIdAsync(5, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existing);

        var result = await _sut.UpdateAsync(5, dto);

        result.IsSuccess.Should().BeTrue();
        existing.PatientId.Value.Should().Be(dto.PatientId);
        existing.AppointmentDate.Should().Be(dto.AppointmentDate);
        existing.Notes.Should().Be(dto.Notes);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    // ----- CancelAsync -----

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task CancelAsync_IdIsZeroOrNegative_ReturnsInvalidIdFailure(int invalidId)
    {
        var result = await _sut.CancelAsync(invalidId);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CancelAsync_AppointmentNotFound_ReturnsNotFoundFailure()
    {
        _repositoryMock
            .Setup(r => r.GetByIdAsync(9, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Appointment?)null);

        var result = await _sut.CancelAsync(9);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.NotFound);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CancelAsync_PendingAppointment_CancelsCommitsAndReturnsSuccess()
    {
        var existing = CreateValidAppointment();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(9, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existing);

        var result = await _sut.CancelAsync(9);

        result.IsSuccess.Should().BeTrue();
        existing.Status.Should().Be(AppointmentStatus.Canceled);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CancelAsync_AppointmentAlreadyCanceled_ReturnsDomainFailureAndNeverCommits()
    {
        var existing = CreateValidAppointment();
        existing.Cancel(); // real domain call: first cancellation succeeds

        _repositoryMock
            .Setup(r => r.GetByIdAsync(9, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existing);

        var result = await _sut.CancelAsync(9);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Status.CannotBeCanceledWhenCompletedOrCanceled);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CancelAsync_AppointmentAlreadyCompleted_ReturnsDomainFailureAndNeverCommits()
    {
        var existing = CreateValidAppointment();
        existing.Complete(); // real domain call: completes it first

        _repositoryMock
            .Setup(r => r.GetByIdAsync(9, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existing);

        var result = await _sut.CancelAsync(9);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Status.CannotBeCanceledWhenCompletedOrCanceled);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    // ----- CompleteAsync -----

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task CompleteAsync_IdIsZeroOrNegative_ReturnsInvalidIdFailure(int invalidId)
    {
        var result = await _sut.CompleteAsync(invalidId);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CompleteAsync_AppointmentNotFound_ReturnsNotFoundFailure()
    {
        _repositoryMock
            .Setup(r => r.GetByIdAsync(9, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Appointment?)null);

        var result = await _sut.CompleteAsync(9);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.NotFound);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CompleteAsync_PendingAppointment_CompletesSetsCompletedAtCommitsAndReturnsSuccess()
    {
        var existing = CreateValidAppointment();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(9, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existing);

        var result = await _sut.CompleteAsync(9);

        result.IsSuccess.Should().BeTrue();
        existing.Status.Should().Be(AppointmentStatus.Completed);
        existing.CompletedAt.Should().NotBeNull();
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CompleteAsync_AppointmentAlreadyCanceled_ReturnsDomainFailureAndNeverCommits()
    {
        var existing = CreateValidAppointment();
        existing.Cancel();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(9, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existing);

        var result = await _sut.CompleteAsync(9);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Status.CannotBeCompletedWhenCanceledOrCompleted);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CompleteAsync_AppointmentAlreadyCompleted_ReturnsDomainFailureAndNeverCommits()
    {
        var existing = CreateValidAppointment();
        existing.Complete();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(9, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existing);

        var result = await _sut.CompleteAsync(9);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Status.CannotBeCompletedWhenCanceledOrCompleted);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    // ----- IsMissed -----

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task IsMissed_IdIsZeroOrNegative_ReturnsInvalidIdFailure(int invalidId)
    {
        var result = await _sut.IsMissed(invalidId);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task IsMissed_AppointmentNotFound_ReturnsNotFoundFailure()
    {
        _repositoryMock
            .Setup(r => r.GetByIdAsync(9, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Appointment?)null);

        var result = await _sut.IsMissed(9);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.NotFound);
    }

    [Fact]
    public async Task IsMissed_PendingAppointmentScheduledInFuture_ReturnsFalse()
    {
        var appointment = CreateValidAppointment(appointmentDate: DateTime.UtcNow.AddDays(1));

        _repositoryMock
            .Setup(r => r.GetByIdAsync(9, It.IsAny<CancellationToken>()))
            .ReturnsAsync(appointment);

        var result = await _sut.IsMissed(9);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeFalse();
    }

    [Fact]
    public async Task IsMissed_CompletedAppointment_ReturnsFalseEvenIfDateHasPassed()
    {
        var appointment = CreateValidAppointment(appointmentDate: DateTime.UtcNow.AddMilliseconds(100));
        await Task.Delay(200);
        appointment.Complete();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(9, It.IsAny<CancellationToken>()))
            .ReturnsAsync(appointment);

        var result = await _sut.IsMissed(9);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeFalse();
    }

    // NOTE: Appointment.Create/Update both reject a past AppointmentDate, so there's no
    // public-API way to build a Pending appointment whose date is already in the past
    // without waiting for real time to elapse. This test schedules just past "now" and
    // waits, rather than reflecting into private state — replace with a clock abstraction
    // if the domain ever gains one, to remove the timing dependency.
    [Fact]
    public async Task IsMissed_PendingAppointmentPastScheduledDate_ReturnsTrue()
    {
        var appointment = CreateValidAppointment(appointmentDate: DateTime.UtcNow.AddMilliseconds(150));
        await Task.Delay(300);

        _repositoryMock
            .Setup(r => r.GetByIdAsync(9, It.IsAny<CancellationToken>()))
            .ReturnsAsync(appointment);

        var result = await _sut.IsMissed(9);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeTrue();
    }
}