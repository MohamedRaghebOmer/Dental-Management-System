using Dental.Domain.Entities;
using Dental.Domain.Errors;
using Dental.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Dental.UnitTests.Domain;

public class VisitTests
{
    private static Id ValidAppointmentId => Id.Create(1).Value;
    private static Money ValidPaidAmount => Money.Create(50m).Value;
    private static Money ValidDiscountAmount => Money.Create(10m).Value;
    private static Money ValidTotalAmount => Money.Create(100m).Value;
    private static DateTime ValidDate => DateTime.UtcNow.AddDays(-1);
    private const string ValidNotes = "Routine checkup.";

    [Fact]
    public void Create_ShouldReturnSuccess_WhenAllFieldsAreValid()
    {
        var result = Visit.Create(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            ValidNotes);

        result.IsSuccess.Should().BeTrue();
        result.Value.AppointmentId.Should().Be(ValidAppointmentId);
        result.Value.PaidAmount.Should().Be(ValidPaidAmount);
        result.Value.DiscountAmount.Should().Be(ValidDiscountAmount);
        result.Value.TotalAmount.Should().Be(ValidTotalAmount);
        result.Value.Date.Should().BeCloseTo(ValidDate, new TimeSpan(0, 0, 1));
        result.Value.Notes.Should().Be(ValidNotes);
    }

    [Fact]
    public void Create_ShouldReturnSuccess_WhenAppointmentIdIsNull()
    {
        var result = Visit.Create(
            null,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            ValidNotes);

        result.IsSuccess.Should().BeTrue();
        result.Value.AppointmentId.Should().BeNull();
    }

    [Fact]
    public void Create_ShouldReturnSuccess_WhenNotesIsNull()
    {
        var result = Visit.Create(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            null);

        result.IsSuccess.Should().BeTrue();
        result.Value.Notes.Should().BeNull();
    }

    [Fact]
    public void Create_ShouldReturnFailure_WhenPaidAmountIsGreaterThanTotalAmount()
    {
        var paidAmount = Money.Create(150m).Value;

        var result = Visit.Create(
            ValidAppointmentId,
            paidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            ValidNotes);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Visit.PaidAmount.AmountMustLessThanTotalAmount);
    }

    [Fact]
    public void Create_ShouldReturnFailure_WhenDiscountAmountIsGreaterThanTotalAmount()
    {
        var discountAmount = Money.Create(150m).Value;

        var result = Visit.Create(
            ValidAppointmentId,
            ValidPaidAmount,
            discountAmount,
            ValidTotalAmount,
            ValidDate,
            ValidNotes);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Visit.DiscountAmount.AmountCannotBeGreaterThanTotalAmount);
    }

    [Fact]
    public void Create_ShouldReturnFailure_WhenDateIsInTheFuture()
    {
        var futureDate = DateTime.UtcNow.AddDays(1);

        var result = Visit.Create(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            futureDate,
            ValidNotes);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Visit.Date.CannotBeInTheFuture);
    }

    [Fact]
    public void Create_ShouldReturnFailure_WhenNotesExceedsMaxLength()
    {
        var tooLongNotes = new string('a', Visit.Constants.NotesMaxLength + 1);

        var result = Visit.Create(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            tooLongNotes);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Visit.Notes.TooLong);
    }

    [Fact]
    public void Create_ShouldReturnSuccess_WhenNotesIsExactlyMaxLength()
    {
        var maxLengthNotes = new string('a', Visit.Constants.NotesMaxLength);

        var result = Visit.Create(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            maxLengthNotes);

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void Update_ShouldReturnSuccess_AndUpdateAllFields_WhenAllFieldsAreValid()
    {
        var visit = Visit.Create(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            ValidNotes).Value;

        var newAppointmentId = Id.Create(2).Value;
        var newPaidAmount = Money.Create(60m).Value;
        var newDiscountAmount = Money.Create(20m).Value;
        var newTotalAmount = Money.Create(200m).Value;
        var newDate = DateTime.UtcNow.AddDays(-2);
        const string newNotes = "Follow-up visit.";

        var result = visit.Update(
            newAppointmentId,
            newPaidAmount,
            newDiscountAmount,
            newTotalAmount,
            newDate,
            newNotes);

        result.IsSuccess.Should().BeTrue();
        visit.AppointmentId.Should().Be(newAppointmentId);
        visit.PaidAmount.Should().Be(newPaidAmount);
        visit.DiscountAmount.Should().Be(newDiscountAmount);
        visit.TotalAmount.Should().Be(newTotalAmount);
        visit.Date.Should().Be(newDate);
        visit.Notes.Should().Be(newNotes);
    }

    [Fact]
    public void Update_ShouldTrimNotes_WhenNotesHasSurroundingWhitespace()
    {
        var visit = Visit.Create(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            ValidNotes).Value;

        var result = visit.Update(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            "  padded notes  ");

        result.IsSuccess.Should().BeTrue();
        visit.Notes.Should().Be("padded notes");
    }

    [Fact]
    public void Update_ShouldReturnFailure_AndNotChangeState_WhenPaidAmountIsGreaterThanTotalAmount()
    {
        var visit = Visit.Create(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            ValidNotes).Value;

        var invalidPaidAmount = Money.Create(150m).Value;

        var result = visit.Update(
            ValidAppointmentId,
            invalidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            ValidNotes);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Visit.PaidAmount.AmountMustLessThanTotalAmount);
        visit.PaidAmount.Should().Be(ValidPaidAmount);
    }

    [Fact]
    public void Update_ShouldReturnFailure_WhenDiscountAmountIsGreaterThanTotalAmount()
    {
        var visit = Visit.Create(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            ValidNotes).Value;

        var invalidDiscountAmount = Money.Create(150m).Value;

        var result = visit.Update(
            ValidAppointmentId,
            ValidPaidAmount,
            invalidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            ValidNotes);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Visit.DiscountAmount.AmountCannotBeGreaterThanTotalAmount);
    }

    [Fact]
    public void Update_ShouldReturnFailure_WhenDateIsInTheFuture()
    {
        var visit = Visit.Create(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            ValidNotes).Value;

        var futureDate = DateTime.UtcNow.AddDays(1);

        var result = visit.Update(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            futureDate,
            ValidNotes);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Visit.Date.CannotBeInTheFuture);
    }

    [Fact]
    public void Update_ShouldReturnFailure_WhenNotesExceedsMaxLength()
    {
        var visit = Visit.Create(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            ValidNotes).Value;

        var tooLongNotes = new string('a', Visit.Constants.NotesMaxLength + 1);

        var result = visit.Update(
            ValidAppointmentId,
            ValidPaidAmount,
            ValidDiscountAmount,
            ValidTotalAmount,
            ValidDate,
            tooLongNotes);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Visit.Notes.TooLong);
    }
}