using Dental.Application.Abstractions;
using Dental.Application.Errors;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.Primitives;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Dental.UnitTests.Application.Abstraction;

// ============================================================================
// TEST DOUBLES
//
// ServiceBase<TEntity, TResponseDto> is abstract and generic, so it needs a
// concrete entity, a concrete response DTO, and a thin concrete subclass to
// be testable in isolation.
//
// ASSUMPTIONS (adjust if your real types differ):
//   - Entity has a protected constructor: protected Entity(int id)
//   - Result / Result<T> expose IsSuccess, IsFailure, Error, Value
//   - ServiceErrors.InvalidId / NotFound / EmptyDataset are Error instances
//     with value-based (record) equality
// ============================================================================

public class TestEntity : Entity
{
    public TestEntity(int id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; set; } = string.Empty;
}

public class TestResponseDto : IResponseDto<TestEntity, TestResponseDto>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public static TestResponseDto ToResponseDto(TestEntity entity) =>
        new()
        {
            Id = entity.Id,
            Name = entity.Name
        };
}

public class TestService(
    IRepository<TestEntity> repo,
    IUnitOfWork unitOfWork,
    ILogger<TestService> logger)
    : ServiceBase<TestEntity, TestResponseDto>(repo, unitOfWork, logger);

// ============================================================================
// TESTS
// ============================================================================

public class ServiceBaseTests
{
    private readonly Mock<IRepository<TestEntity>> _repoMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<ILogger<TestService>> _loggerMock;
    private readonly TestService _sut;

    public ServiceBaseTests()
    {
        _repoMock = new Mock<IRepository<TestEntity>>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _loggerMock = new Mock<ILogger<TestService>>();
        _sut = new TestService(_repoMock.Object, _unitOfWorkMock.Object, _loggerMock.Object);
    }

    // ------------------------------------------------------------------
    // GetByIdAsync
    // ------------------------------------------------------------------

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public async Task GetByIdAsync_WithInvalidId_ReturnsFailureWithInvalidIdError(int invalidId)
    {
        // Act
        var result = await _sut.GetByIdAsync(invalidId);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);

        _repoMock.Verify(
            r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()),
            Times.Never,
            "an invalid id should short-circuit before the repository is touched");

        VerifyLogWarningCalled(Times.Once());
    }

    [Fact]
    public async Task GetByIdAsync_WhenEntityDoesNotExist_ReturnsFailureWithNotFoundError()
    {
        // Arrange
        const int id = 1;
        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync((TestEntity?)null);

        // Act
        var result = await _sut.GetByIdAsync(id);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.NotFound);

        _repoMock.Verify(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_WhenEntityExists_ReturnsSuccessWithMappedDto()
    {
        // Arrange
        const int id = 1;
        var entity = new TestEntity(id, "Root Canal");

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(entity);

        // Act
        var result = await _sut.GetByIdAsync(id);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.Id.Should().Be(entity.Id);
        result.Value.Name.Should().Be(entity.Name);
    }

    [Fact]
    public async Task GetByIdAsync_PassesCancellationTokenThroughToRepository()
    {
        // Arrange
        const int id = 1;
        using var cts = new CancellationTokenSource();
        var entity = new TestEntity(id, "Cleaning");

        _repoMock
            .Setup(r => r.GetByIdAsync(id, cts.Token))
            .ReturnsAsync(entity);

        // Act
        await _sut.GetByIdAsync(id, cts.Token);

        // Assert
        _repoMock.Verify(r => r.GetByIdAsync(id, cts.Token), Times.Once);
    }

    // ------------------------------------------------------------------
    // GetAllAsync
    // ------------------------------------------------------------------

    [Fact]
    public async Task GetAllAsync_WhenRepositoryReturnsNoEntities_ReturnsFailureWithEmptyDatasetError()
    {
        // Arrange
        _repoMock
            .Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(Enumerable.Empty<TestEntity>());

        // Act
        var result = await _sut.GetAllAsync();

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.EmptyDataset);

        VerifyLogWarningCalled(Times.Once());
    }

    [Fact]
    public async Task GetAllAsync_WhenEntitiesExist_ReturnsSuccessWithAllMappedDtos()
    {
        // Arrange
        var entities = new[]
        {
            new TestEntity(1, "Cleaning"),
            new TestEntity(2, "Whitening"),
            new TestEntity(3, "Extraction")
        };

        _repoMock
            .Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(entities);

        // Act
        var result = await _sut.GetAllAsync();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(3);
        result.Value.Select(d => d.Id).Should().BeEquivalentTo(entities.Select(e => e.Id));
        result.Value.Select(d => d.Name).Should().BeEquivalentTo(entities.Select(e => e.Name));
    }

    [Fact]
    public async Task GetAllAsync_WhenRepositoryReturnsSingleEntity_ReturnsSuccessWithOneDto()
    {
        // Arrange
        var entity = new TestEntity(1, "Consultation");

        _repoMock
            .Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new[] { entity });

        // Act
        var result = await _sut.GetAllAsync();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().ContainSingle()
            .Which.Name.Should().Be(entity.Name);
    }

    // ------------------------------------------------------------------
    // DeleteAsync
    // ------------------------------------------------------------------

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public async Task DeleteAsync_WithInvalidId_ReturnsFailureAndNeverTouchesRepositoryOrUnitOfWork(int invalidId)
    {
        // Act
        var result = await _sut.DeleteAsync(invalidId);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.InvalidId);

        _repoMock.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        _repoMock.Verify(r => r.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);

        VerifyLogWarningCalled(Times.Once());
    }

    [Fact]
    public async Task DeleteAsync_WhenEntityDoesNotExist_ReturnsFailureAndDoesNotDeleteOrSave()
    {
        // Arrange
        const int id = 1;
        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync((TestEntity?)null);

        // Act
        var result = await _sut.DeleteAsync(id);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ServiceErrors.NotFound);

        _repoMock.Verify(r => r.DeleteAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task DeleteAsync_WhenEntityExists_DeletesEntitySavesChangesAndReturnsSuccess()
    {
        // Arrange
        const int id = 1;
        var entity = new TestEntity(id, "Filling");

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(entity);

        // Act
        var result = await _sut.DeleteAsync(id);

        // Assert
        result.IsSuccess.Should().BeTrue();

        _repoMock.Verify(r => r.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_CallsRepositoryDeleteBeforeUnitOfWorkSaveChanges()
    {
        // Arrange
        const int id = 1;
        var entity = new TestEntity(id, "X-Ray");
        var callOrder = new List<string>();

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(entity);

        _repoMock
            .Setup(r => r.DeleteAsync(id, It.IsAny<CancellationToken>()))
            .Callback(() => callOrder.Add(nameof(IRepository<TestEntity>.DeleteAsync)))
            .Returns(Task.CompletedTask);

        _unitOfWorkMock
            .Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .Callback(() => callOrder.Add(nameof(IUnitOfWork.SaveChangesAsync)))
            .Returns(Task.CompletedTask);

        // Act
        await _sut.DeleteAsync(id);

        // Assert
        callOrder.Should().ContainInOrder(
            nameof(IRepository<TestEntity>.DeleteAsync),
            nameof(IUnitOfWork.SaveChangesAsync));
    }

    [Fact]
    public async Task DeleteAsync_WhenEntityExists_DeletesUsingTheSameIdThatWasLookedUp()
    {
        // Arrange
        const int id = 42;
        var entity = new TestEntity(id, "Checkup");

        _repoMock
            .Setup(r => r.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(entity);

        // Act
        await _sut.DeleteAsync(id);

        // Assert - guards against a bug where a different id is passed to DeleteAsync
        _repoMock.Verify(r => r.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
        _repoMock.Verify(r => r.DeleteAsync(It.Is<int>(x => x != id), It.IsAny<CancellationToken>()), Times.Never);
    }

    // ------------------------------------------------------------------
    // Helpers
    // ------------------------------------------------------------------

    /// <summary>
    /// Verifies ILogger.LogWarning was invoked the given number of times,
    /// regardless of message content.
    /// </summary>
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
}