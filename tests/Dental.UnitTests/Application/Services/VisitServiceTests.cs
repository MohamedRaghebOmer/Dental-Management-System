using Dental.Application.Abstractions;
using Dental.Application.DTOs.Visit;
using Dental.Application.Errors;
using Dental.Application.Services;
using Dental.Domain.Entities;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.ValueObjects;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Dental.UnitTests.Application.Services;

public class VisitServiceTests
{
    private readonly Mock<IRepository<Visit>> _repositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<ILogger<ServiceBase<Visit, VisitResponseDto>>> _loggerMock;
    private readonly VisitService _sut;

    public VisitServiceTests()
    {
        _repositoryMock = new Mock<IRepository<Visit>>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _loggerMock = new Mock<ILogger<ServiceBase<Visit, VisitResponseDto>>>();

        _sut = new VisitService(
            _repositoryMock.Object,
            _unitOfWorkMock.Object,
            _loggerMock.Object);
    }

    private static CreateVisitDto ValidCreateDto(int? appointmentId = 1) => new()
    {
        AppointmentId = appointmentId,
        PaidAmount = 100m,
        DiscountAmount = 10m,
        TotalAmount = 200m,
        Date = DateTime.UtcNow.AddDays(-1),
        Notes = "Routine checkup"
    };

    private static UpdateVisitDto ValidUpdateDto(int? appointmentId = 2) => new()
    {
        AppointmentId = appointmentId,
        PaidAmount = 80m,
        DiscountAmount = 20m,
        TotalAmount = 180m,
        Date = DateTime.UtcNow.AddDays(-2),
        Notes = "Updated notes"
    };

    private static Visit ExistingVisit() => Visit.Create(
        Id.Create(1).Value,
        Money.Create(50m).Value,
        Money.Create(5m).Value,
        Money.Create(150m).Value,
        DateTime.UtcNow.AddDays(-5),
        "Initial notes").Value;

    // ---------------------------------------------------------------
    // CreateAsync
    // ---------------------------------------------------------------

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task CreateAsync_AppointmentIdIsZeroOrNegative_ReturnsInvalidIdFailure(int appointmentId)
    {
        var dto = ValidCreateDto(appointmentId);

        var result = await _sut.CreateAsync(dto, CancellationToken.None);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Visit>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateAsync_PaidAmountIsNegative_ReturnsInvalidIdFailure()
    {
        var dto = ValidCreateDto() with { PaidAmount = -1m };

        var result = await _sut.CreateAsync(dto, CancellationToken.None);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Visit>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateAsync_DiscountAmountIsNegative_ReturnsInvalidIdFailure()
    {
        var dto = ValidCreateDto() with { DiscountAmount = -1m };

        var result = await _sut.CreateAsync(dto, CancellationToken.None);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Visit>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateAsync_TotalAmountIsNegative_ReturnsInvalidIdFailure()
    {
        var dto = ValidCreateDto() with { TotalAmount = -1m };

        var result = await _sut.CreateAsync(dto, CancellationToken.None);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Visit>(), It.IsAny<CancellationToken>()), Times.Never);
    }


    [Fact]
    public async Task CreateAsync_ValidDto_AddsVisitCommitsAndReturnsSuccess()
    {
        var dto = ValidCreateDto();

        var result = await _sut.CreateAsync(dto, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
        _repositoryMock.Verify(r => r.AddAsync(
            It.Is<Visit>(v =>
                v.AppointmentId!.Value == dto.AppointmentId!.Value &&
                v.PaidAmount.Value == dto.PaidAmount &&
                v.DiscountAmount.Value == dto.DiscountAmount &&
                v.TotalAmount.Value == dto.TotalAmount &&
                v.Notes == dto.Notes),
            It.IsAny<CancellationToken>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    // ---------------------------------------------------------------
    // UpdateASync
    // ---------------------------------------------------------------

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task UpdateASync_VisitIdIsZeroOrNegative_ReturnsInvalidIdFailure(int visitId)
    {
        var dto = ValidUpdateDto();

        var result = await _sut.UpdateASync(visitId, dto, CancellationToken.None);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task UpdateASync_AppointmentIdIsZeroOrNegative_ReturnsInvalidIdFailure(int appointmentId)
    {
        var dto = ValidUpdateDto(appointmentId);

        var result = await _sut.UpdateASync(1, dto, CancellationToken.None);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateASync_PaidAmountIsNegative_ReturnsInvalidIdFailure()
    {
        var dto = ValidUpdateDto() with { PaidAmount = -1m };

        var result = await _sut.UpdateASync(1, dto, CancellationToken.None);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateASync_DiscountAmountIsNegative_ReturnsInvalidIdFailure()
    {
        var dto = ValidUpdateDto() with { DiscountAmount = -1m };

        var result = await _sut.UpdateASync(1, dto, CancellationToken.None);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateASync_TotalAmountIsNegative_ReturnsInvalidIdFailure()
    {
        var dto = ValidUpdateDto() with { TotalAmount = -1m };

        var result = await _sut.UpdateASync(1, dto, CancellationToken.None);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateASync_VisitNotFound_ReturnsNotFoundFailure()
    {
        var dto = ValidUpdateDto();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Visit?)null);

        var result = await _sut.UpdateASync(1, dto, CancellationToken.None);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.NotFound);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateASync_ValidDto_UpdatesVisitCommitsAndReturnsSuccess()
    {
        var visit = ExistingVisit();
        var dto = ValidUpdateDto();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(visit);

        var result = await _sut.UpdateASync(1, dto, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
        visit.PaidAmount.Value.Should().Be(dto.PaidAmount);
        visit.DiscountAmount.Value.Should().Be(dto.DiscountAmount);
        visit.TotalAmount.Value.Should().Be(dto.TotalAmount);
        visit.AppointmentId!.Value.Should().Be(dto.AppointmentId!.Value);
        visit.Notes.Should().Be(dto.Notes!.Trim());
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdateASync_AppointmentIdIsNull_UpdatesVisitWithNullAppointmentAndReturnsSuccess()
    {
        // Unlike CreateAsync, this path is safe: UpdateASync uses "appointmentIdResult?.Value"
        // instead of the null-forgiving "!.Value", so a null AppointmentId doesn't crash.
        var visit = ExistingVisit();
        var dto = ValidUpdateDto(appointmentId: null);

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(visit);

        var result = await _sut.UpdateASync(1, dto, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
        visit.AppointmentId.Should().BeNull();
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }


    // ---------------------------------------------------------------
    // Inherited ServiceBase members (first Visit test class, so covered once here)
    // ---------------------------------------------------------------

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task GetByIdAsync_IdIsZeroOrNegative_ReturnsInvalidIdFailure(int id)
    {
        var result = await _sut.GetByIdAsync(id);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task GetByIdAsync_VisitNotFound_ReturnsNotFoundFailure()
    {
        _repositoryMock
            .Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Visit?)null);

        var result = await _sut.GetByIdAsync(1);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_VisitExists_ReturnsSuccessWithMappedDto()
    {
        var visit = ExistingVisit();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(visit);

        var result = await _sut.GetByIdAsync(1);

        result.IsSuccess.Should().BeTrue();
        result.Value.AppointmentId.Should().Be(visit.AppointmentId);
        result.Value.PaidAmount.Should().Be(visit.PaidAmount);
        result.Value.DiscountAmount.Should().Be(visit.DiscountAmount);
        result.Value.TotalAmount.Should().Be(visit.TotalAmount);
        result.Value.Notes.Should().Be(visit.Notes);
    }

    [Fact]
    public async Task GetAllAsync_RepositoryReturnsEmptyCollection_ReturnsEmptyDatasetFailure()
    {
        _repositoryMock
            .Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(Enumerable.Empty<Visit>());

        var result = await _sut.GetAllAsync();

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.EmptyDataset);
    }

    [Fact]
    public async Task GetAllAsync_RepositoryReturnsVisits_ReturnsSuccessWithMappedDtos()
    {
        var visits = new[] { ExistingVisit(), ExistingVisit() };

        _repositoryMock
            .Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(visits);

        var result = await _sut.GetAllAsync();

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        result.Value.First().PaidAmount.Should().Be(visits[0].PaidAmount);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task DeleteAsync_IdIsZeroOrNegative_ReturnsInvalidIdFailure(int id)
    {
        var result = await _sut.DeleteAsync(id);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);
        _repositoryMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task DeleteAsync_VisitNotFound_ReturnsNotFoundFailure()
    {
        _repositoryMock
            .Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Visit?)null);

        var result = await _sut.DeleteAsync(1);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.NotFound);
        _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task DeleteAsync_VisitExists_DeletesAndCommits()
    {
        var visit = ExistingVisit();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(visit);

        var result = await _sut.DeleteAsync(1);

        result.IsSuccess.Should().BeTrue();
        _repositoryMock.Verify(r => r.DeleteAsync(1, It.IsAny<CancellationToken>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}