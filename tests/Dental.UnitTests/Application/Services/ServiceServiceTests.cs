using Dental.Application.DTOs.Service;
using Dental.Application.Errors;
using Dental.Application.Services;
using Dental.Domain.Entities;
using Dental.Domain.Errors;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.ValueObjects;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Dental.UnitTests.Application.Services;

public class ServiceServiceTests
{
    private readonly Mock<IRepository<Service>> _repoMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<ILogger<ServiceService>> _loggerMock;
    private readonly ServiceService _sut;

    public ServiceServiceTests()
    {
        _repoMock = new Mock<IRepository<Service>>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _loggerMock = new Mock<ILogger<ServiceService>>();
        _sut = new ServiceService(_repoMock.Object, _unitOfWorkMock.Object, _loggerMock.Object);
    }

    // ------------------------------------------------------------------
    // Test data builders
    // ------------------------------------------------------------------

    private static CreateServiceDto ValidCreateDto(
        string name = "Root Canal",
        decimal price = 150.00m,
        string? description = "Standard root canal treatment") =>
        new()
        {
            Name = name,
            Price = price,
            Description = description
        };

    private static UpdateServiceDto ValidUpdateDto(
        string? name = "Teeth Whitening",
        decimal price = 200.00m,
        string? description = "In-office whitening session") =>
        new()
        {
            Name = name,
            Price = price,
            Description = description
        };

    private static Service ExistingService(int id = 1) =>
        Service.Create(
            ServiceName.Create("Old Service").Value,
            Money.Create(100m).Value,
            "Old description").Value;

    private void VerifyLogWarningCalled(Times times)
    {
        _loggerMock.Verify(
            l => l.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            times);
    }

    // ====================================================================
    // CreateServiceAsync
    // ====================================================================

    [Fact]
    public async Task CreateServiceAsync_WithNullDto_ReturnsFailureAndDoesNotPersist()
    {
        // Act
        var result = await _sut.CreateAsync(null);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.ParameterNullReference);

        _repoMock.Verify(r => r.AddAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        VerifyLogWarningCalled(Times.Once());
    }

    [Fact]
    public async Task CreateServiceAsync_WithValidData_AddsServiceSavesChangesAndReturnsSuccess()
    {
        // Arrange
        var dto = ValidCreateDto();
        Service? capturedService = null;

        _repoMock
            .Setup(r => r.AddAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()))
            .Callback<Service, CancellationToken>((s, _) => capturedService = s)
            .Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CreateAsync(dto);

        // Assert
        result.IsSuccess.Should().BeTrue();

        capturedService.Should().NotBeNull();
        capturedService!.Name.Value.Should().Be(dto.Name);
        capturedService.Price.Value.Should().Be(dto.Price);
        capturedService.Description.Should().Be(dto.Description);

        _repoMock.Verify(r => r.AddAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CreateServiceAsync_WithValidData_ReturnsCreatedServiceId()
    {
        // Arrange
        var dto = ValidCreateDto();

        _repoMock
            .Setup(r => r.AddAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CreateAsync(dto);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(0); // new, untracked entity - Id assigned by EF on save in real usage
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public async Task CreateServiceAsync_WithEmptyName_ReturnsFailureAndDoesNotPersist(string? name)
    {
        // Arrange
        var dto = ValidCreateDto(name: name!);

        // Act
        var result = await _sut.CreateAsync(dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Services.ServiceName.Empty);

        _repoMock.Verify(r => r.AddAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateServiceAsync_WithNameTooLong_ReturnsFailureAndDoesNotPersist()
    {
        // Arrange
        var dto = ValidCreateDto(name: new string('a', ServiceName.MaxLength + 1));

        // Act
        var result = await _sut.CreateAsync(dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Services.ServiceName.TooLong);
        _repoMock.Verify(r => r.AddAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateServiceAsync_WithNameAtMaxLength_Succeeds()
    {
        // Arrange - boundary: exactly MaxLength should be valid
        var dto = ValidCreateDto(name: new string('a', ServiceName.MaxLength));

        _repoMock
            .Setup(r => r.AddAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CreateAsync(dto);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task CreateServiceAsync_WithNegativePrice_ReturnsFailureAndDoesNotPersist()
    {
        // Arrange
        var dto = ValidCreateDto(price: -0.01m);

        // Act
        var result = await _sut.CreateAsync(dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Services.Money.NonPositiveValue);
        _repoMock.Verify(r => r.AddAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateServiceAsync_WithZeroPrice_Succeeds()
    {
        // Arrange - boundary: zero is allowed (only negative values fail)
        var dto = ValidCreateDto(price: 0m);

        _repoMock
            .Setup(r => r.AddAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CreateAsync(dto);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task CreateServiceAsync_WithDescriptionTooLong_ReturnsFailureAndDoesNotPersist()
    {
        // Arrange
        var dto = ValidCreateDto(description: new string('d', Service.DescriptionMaxLength + 1));

        // Act
        var result = await _sut.CreateAsync(dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Services.Description.TooLong);
        _repoMock.Verify(r => r.AddAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateServiceAsync_WithNullDescription_Succeeds()
    {
        // Arrange
        var dto = ValidCreateDto(description: null);

        _repoMock
            .Setup(r => r.AddAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CreateAsync(dto);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task CreateServiceAsync_ValidatesInOrder_NameBeforePriceBeforeDescription()
    {
        // Arrange - everything is invalid; only the Name error should surface
        var dto = ValidCreateDto(
            name: "",
            price: -1m,
            description: new string('x', Service.DescriptionMaxLength + 1));

        // Act
        var result = await _sut.CreateAsync(dto);

        // Assert
        result.Error.Should().Be(DomainErrors.Services.ServiceName.Empty);
    }

    [Fact]
    public async Task CreateServiceAsync_PassesCancellationTokenThroughToRepositoryAndUnitOfWork()
    {
        // Arrange
        var dto = ValidCreateDto();
        using var cts = new CancellationTokenSource();

        _repoMock
            .Setup(r => r.AddAsync(It.IsAny<Service>(), cts.Token))
            .Returns(Task.CompletedTask);

        // Act
        await _sut.CreateAsync(dto, cts.Token);

        // Assert
        _repoMock.Verify(r => r.AddAsync(It.IsAny<Service>(), cts.Token), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(cts.Token), Times.Once);
    }

    // ====================================================================
    // UpdateServiceAsync
    // ====================================================================

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public async Task UpdateServiceAsync_WithInvalidId_ReturnsFailureAndNeverQueriesRepository(int invalidId)
    {
        // Act
        var result = await _sut.UpdateAsync(invalidId, ValidUpdateDto());

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);

        _repoMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        VerifyLogWarningCalled(Times.Once());
    }

    [Fact]
    public async Task UpdateServiceAsync_WhenServiceDoesNotExist_ReturnsFailureWithNotFound()
    {
        // Arrange
        const int id = 1;
        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Service?)null);

        // Act
        var result = await _sut.UpdateAsync(id, ValidUpdateDto());

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.NotFound);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        VerifyLogWarningCalled(Times.Once());
    }

    [Fact]
    public async Task UpdateServiceAsync_WithValidData_UpdatesServiceSavesChangesAndReturnsMappedDto()
    {
        // Arrange
        const int id = 1;
        var existingService = ExistingService(id);
        var dto = ValidUpdateDto();

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingService);

        // Act
        var result = await _sut.UpdateAsync(id, dto);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Name.Should().Be(dto.Name);
        result.Value.Price.Should().Be(dto.Price);
        result.Value.Description.Should().Be(dto.Description);

        existingService.Name.Value.Should().Be(dto.Name);
        existingService.Price.Value.Should().Be(dto.Price);
        existingService.Description.Should().Be(dto.Description);

        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task UpdateServiceAsync_WithEmptyName_ReturnsFailureAndDoesNotMutateOrSave(string? name)
    {
        // Arrange
        const int id = 1;
        var existingService = ExistingService(id);
        var originalName = existingService.Name.Value;
        var dto = ValidUpdateDto(name: name);

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingService);

        // Act
        var result = await _sut.UpdateAsync(id, dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Services.ServiceName.Empty);
        existingService.Name.Value.Should().Be(originalName);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateServiceAsync_WithNameTooLong_ReturnsFailureAndDoesNotMutateOrSave()
    {
        // Arrange
        const int id = 1;
        var existingService = ExistingService(id);
        var originalName = existingService.Name.Value;
        var dto = ValidUpdateDto(name: new string('z', ServiceName.MaxLength + 1));

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingService);

        // Act
        var result = await _sut.UpdateAsync(id, dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Services.ServiceName.TooLong);
        existingService.Name.Value.Should().Be(originalName);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateServiceAsync_WithNegativePrice_ReturnsFailureAndDoesNotMutateOrSave()
    {
        // Arrange
        const int id = 1;
        var existingService = ExistingService(id);
        var originalPrice = existingService.Price.Value;
        var dto = ValidUpdateDto(price: -50m);

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingService);

        // Act
        var result = await _sut.UpdateAsync(id, dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Services.Money.NonPositiveValue);
        existingService.Price.Value.Should().Be(originalPrice);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateServiceAsync_WithDescriptionTooLong_ReturnsFailureAndDoesNotMutateOrSave()
    {
        // Arrange
        const int id = 1;
        var existingService = ExistingService(id);
        var originalDescription = existingService.Description;
        var dto = ValidUpdateDto(description: new string('d', Service.DescriptionMaxLength + 1));

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingService);

        // Act
        var result = await _sut.UpdateAsync(id, dto);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(DomainErrors.Services.Description.TooLong);
        existingService.Description.Should().Be(originalDescription);
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateServiceAsync_WithNullDescription_SucceedsAndClearsDescription()
    {
        // Arrange
        const int id = 1;
        var existingService = ExistingService(id);
        var dto = ValidUpdateDto(description: null);

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingService);

        // Act
        var result = await _sut.UpdateAsync(id, dto);

        // Assert
        result.IsSuccess.Should().BeTrue();
        existingService.Description.Should().BeNull();
        result.Value.Description.Should().BeNull();
    }

    [Fact]
    public async Task UpdateServiceAsync_CallsServiceUpdateBeforeSaveChangesAsync()
    {
        // Arrange - guards ordering: the entity must be mutated before changes are flushed
        const int id = 1;
        var existingService = ExistingService(id);
        var dto = ValidUpdateDto();

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingService);

        _unitOfWorkMock
            .Setup(u => u.CommitAsync(It.IsAny<CancellationToken>()))
            .Callback(() => existingService.Name.Value.Should().Be(dto.Name))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _sut.UpdateAsync(id, dto);

        // Assert
        result.IsSuccess.Should().BeTrue();
        _unitOfWorkMock.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdateServiceAsync_PassesCancellationTokenThroughToRepositoryAndUnitOfWork()
    {
        // Arrange
        const int id = 1;
        using var cts = new CancellationTokenSource();
        var existingService = ExistingService(id);

        _repoMock
            .Setup(r => r.GetByIdAsync(id, cts.Token))
            .ReturnsAsync(existingService);

        // Act
        await _sut.UpdateAsync(id, ValidUpdateDto(), cts.Token);

        // Assert
        _repoMock.Verify(r => r.GetByIdAsync(id, cts.Token), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(cts.Token), Times.Once);
    }
}