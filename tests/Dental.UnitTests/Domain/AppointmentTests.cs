using Dental.Domain.Entities;
using Dental.Domain.Enums;
using Dental.Domain.Errors;
using Dental.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Dental.UnitTests.Domain;

public class AppointmentTests
{
    private static readonly Id ValidPatientId = Id.FromDatabase(1);
    private static readonly Id OtherPatientId = Id.FromDatabase(2);

    private static DateTime Future(int minutes = 60) => DateTime.UtcNow.AddMinutes(minutes);

    // IsMissed() can only ever be true for a Pending appointment whose date is in
    // the past, but neither Create nor Update allow a past date to be set through
    // the public API. This helper uses reflection purely to force that otherwise
    // unreachable state (e.g. representing data that has simply aged past its
    // scheduled time) so IsMissed's own logic can be tested in isolation.
    private static void SetAppointmentDate(Appointment appointment, DateTime date)
    {
        typeof(Appointment)
            .GetProperty(nameof(Appointment.AppointmentDate))!
            .SetValue(appointment, date);
    }

    #region Create

    [Fact]
    public void Create_ShouldReturnSuccess_WhenDataIsValid()
    {
        var appointmentDate = Future();

        var result = Appointment.Create(ValidPatientId, appointmentDate, "Routine checkup");

        result.IsSuccess.Should().BeTrue();
        result.Value.PatientId.Should().Be(ValidPatientId);
        result.Value.AppointmentDate.Should().Be(appointmentDate);
        result.Value.Notes.Should().Be("Routine checkup");
        result.Value.Status.Should().Be(AppointmentStatus.Pending);
        result.Value.CompletedAt.Should().BeNull();
    }

    [Fact]
    public void Create_ShouldReturnFailure_WhenAppointmentDateIsInThePast()
    {
        var result = Appointment.Create(ValidPatientId, DateTime.UtcNow.AddMinutes(-10), "Notes");

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Date.InThePast);
    }

    [Fact]
    public void Create_ShouldReturnFailure_WhenNotesExceedMaxLength()
    {
        var tooLongNotes = new string('a', Appointment.Constants.NotesMaxLength + 1);

        var result = Appointment.Create(ValidPatientId, Future(), tooLongNotes);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Notes.TooLong);
    }

    [Fact]
    public void Create_ShouldReturnSuccess_WhenNotesLengthIsExactlyMaxLength()
    {
        var maxLengthNotes = new string('a', Appointment.Constants.NotesMaxLength);

        var result = Appointment.Create(ValidPatientId, Future(), maxLengthNotes);

        result.IsSuccess.Should().BeTrue();
        result.Value.Notes.Should().Be(maxLengthNotes);
    }

    [Fact]
    public void Create_ShouldReturnSuccess_WhenNotesIsNull()
    {
        var result = Appointment.Create(ValidPatientId, Future(), null);

        result.IsSuccess.Should().BeTrue();
        result.Value.Notes.Should().BeNull();
    }

    [Fact]
    public void Create_ShouldTrimNotes_WhenNotesHasSurroundingWhitespace()
    {
        var result = Appointment.Create(ValidPatientId, Future(), "  Routine checkup  ");

        result.IsSuccess.Should().BeTrue();
        result.Value.Notes.Should().Be("Routine checkup");
    }

    #endregion

    #region Update

    [Fact]
    public void Update_ShouldReturnSuccess_WhenAppointmentIsPendingAndDataIsValid()
    {
        var appointment = Appointment.Create(ValidPatientId, Future(), "Original notes").Value;
        var newDate = Future(120);

        var result = appointment.Update(OtherPatientId, newDate, "Updated notes");

        result.IsSuccess.Should().BeTrue();
        appointment.PatientId.Should().Be(OtherPatientId);
        appointment.AppointmentDate.Should().Be(newDate);
        appointment.Notes.Should().Be("Updated notes");
    }

    [Fact]
    public void Update_ShouldReturnFailure_WhenAppointmentDateIsInThePast()
    {
        var appointment = Appointment.Create(ValidPatientId, Future(), "Notes").Value;

        var result = appointment.Update(ValidPatientId, DateTime.UtcNow.AddMinutes(-5), "Notes");

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Date.InThePast);
    }

    [Fact]
    public void Update_ShouldReturnFailure_WhenNotesExceedMaxLength()
    {
        var appointment = Appointment.Create(ValidPatientId, Future(), "Notes").Value;
        var tooLongNotes = new string('a', Appointment.Constants.NotesMaxLength + 1);

        var result = appointment.Update(ValidPatientId, Future(), tooLongNotes);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Notes.TooLong);
    }

    [Fact]
    public void Update_ShouldReturnFailure_WhenStatusIsNotPendingAndDateIsChanged()
    {
        var originalDate = Future();
        var appointment = Appointment.Create(ValidPatientId, originalDate, "Notes").Value;
        appointment.Complete();

        var result = appointment.Update(ValidPatientId, Future(120), "Notes");

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Date.CannotBeChangedWhenStatusIsNotPending);
    }

    [Fact]
    public void Update_ShouldReturnFailure_WhenStatusIsNotPendingAndPatientIdIsChanged()
    {
        var originalDate = Future();
        var appointment = Appointment.Create(ValidPatientId, originalDate, "Notes").Value;
        appointment.Complete();

        var result = appointment.Update(OtherPatientId, originalDate, "Notes");

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.PatientId.CannotBeChangedWhenStatusIsNotPending);
    }

    [Fact]
    public void Update_ShouldReturnSuccessAndUpdateNotes_WhenStatusIsNotPendingButDateAndPatientIdAreUnchanged()
    {
        var originalDate = Future();
        var appointment = Appointment.Create(ValidPatientId, originalDate, "Old notes").Value;
        appointment.Complete();

        var result = appointment.Update(ValidPatientId, originalDate, "New notes");

        result.IsSuccess.Should().BeTrue();
        appointment.Notes.Should().Be("New notes");
        appointment.AppointmentDate.Should().Be(originalDate);
        appointment.PatientId.Should().Be(ValidPatientId);
    }

    #endregion

    #region Cancel

    [Fact]
    public void Cancel_ShouldReturnSuccess_WhenAppointmentIsPending()
    {
        var appointment = Appointment.Create(ValidPatientId, Future(), "Notes").Value;

        var result = appointment.Cancel();

        result.IsSuccess.Should().BeTrue();
        appointment.Status.Should().Be(AppointmentStatus.Canceled);
    }

    [Fact]
    public void Cancel_ShouldReturnFailure_WhenAppointmentIsAlreadyCanceled()
    {
        var appointment = Appointment.Create(ValidPatientId, Future(), "Notes").Value;
        appointment.Cancel();

        var result = appointment.Cancel();

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Status.CannotBeCanceledWhenCompletedOrCanceled);
    }

    [Fact]
    public void Cancel_ShouldReturnFailure_WhenAppointmentIsAlreadyCompleted()
    {
        var appointment = Appointment.Create(ValidPatientId, Future(), "Notes").Value;
        appointment.Complete();

        var result = appointment.Cancel();

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Status.CannotBeCanceledWhenCompletedOrCanceled);
    }

    #endregion

    #region Complete

    [Fact]
    public void Complete_ShouldReturnSuccessAndSetCompletedAt_WhenAppointmentIsPending()
    {
        var appointment = Appointment.Create(ValidPatientId, Future(), "Notes").Value;

        var result = appointment.Complete();

        result.IsSuccess.Should().BeTrue();
        appointment.Status.Should().Be(AppointmentStatus.Completed);
        appointment.CompletedAt.Should().NotBeNull();
        appointment.CompletedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void Complete_ShouldReturnFailure_WhenAppointmentIsAlreadyCompleted()
    {
        var appointment = Appointment.Create(ValidPatientId, Future(), "Notes").Value;
        appointment.Complete();

        var result = appointment.Complete();

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Status.CannotBeCompletedWhenCanceledOrCompleted);
    }

    [Fact]
    public void Complete_ShouldReturnFailure_WhenAppointmentIsCanceled()
    {
        var appointment = Appointment.Create(ValidPatientId, Future(), "Notes").Value;
        appointment.Cancel();

        var result = appointment.Complete();

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Appointment.Status.CannotBeCompletedWhenCanceledOrCompleted);
    }

    #endregion

    #region IsMissed

    [Fact]
    public void IsMissed_ShouldReturnTrue_WhenStatusIsPendingAndDateIsInThePast()
    {
        var appointment = Appointment.Create(ValidPatientId, Future(), "Notes").Value;
        SetAppointmentDate(appointment, DateTime.UtcNow.AddDays(-1));

        appointment.IsMissed().Should().BeTrue();
    }

    [Fact]
    public void IsMissed_ShouldReturnFalse_WhenStatusIsPendingAndDateIsInTheFuture()
    {
        var appointment = Appointment.Create(ValidPatientId, Future(), "Notes").Value;

        appointment.IsMissed().Should().BeFalse();
    }

    [Fact]
    public void IsMissed_ShouldReturnFalse_WhenDateIsInThePastButStatusIsNotPending()
    {
        var appointment = Appointment.Create(ValidPatientId, Future(), "Notes").Value;
        appointment.Complete();
        SetAppointmentDate(appointment, DateTime.UtcNow.AddDays(-1));

        appointment.IsMissed().Should().BeFalse();
    }

    #endregion
}