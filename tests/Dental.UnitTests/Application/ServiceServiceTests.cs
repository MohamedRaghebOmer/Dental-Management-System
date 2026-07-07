using Dental.Application.DTOs.Service;
using Dental.Application.Services;
using Dental.Domain.Entities;
using Dental.Domain.Interfaces.Repositories;
using Dental.Domain.ValueObjects;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Dental.UnitTests.Application.Services;

public class ServiceServiceTests
{
    private readonly Mock<IServiceRepository> _repoMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<ILogger<ServiceService>> _loggerMock = new();

    private readonly ServiceService _sut;

    public ServiceServiceTests()
    {
        _sut = new ServiceService(
                _repoMock.Object,
                _unitOfWorkMock.Object,
                _loggerMock.Object);
    }

    private static CreateServiceDto CreateValidCreateDto()
        => new()
        {
            Name = "Dental Cleaning",
            Price = 150m,
            Description = "Routine dental cleaning"
        };

    private static UpdateServiceDto CreateValidUpdateDto(int id = 1)
        => new()
        {
            Id = id,
            Name = "Updated Service Name",
            Price = 200m,
            Description = "Updated description"
        };

    private static Service CreateValidDomainService(
        string name = "Dental Cleaning",
        decimal price = 150m,
        string? description = "Routine dental cleaning")
    {
        var nameResult = ServiceName.Create(name);
        nameResult.IsSuccess.Should().BeTrue();

        var priceResult = Money.Create(price);
        priceResult.IsSuccess.Should().BeTrue();

        var serviceResult = Service.Create(nameResult.Value, priceResult.Value, description);
        serviceResult.IsSuccess.Should().BeTrue();

        return serviceResult.Value;
    }

    [Fact]
    public async Task CreateServiceAsync_WhenDtoIsNull_ReturnsFailure_AndDoesNotCallRepository()
    {
        var result = await _sut.CreateServiceAsync(null, TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeFalse();

        _repoMock.Verify(
            r => r.AddServiceAsync(
                It.IsAny<Service>(), It.IsAny<CancellationToken>()), Times.Never);

        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateServiceAsync_WhenNameIsInvalid_ReturnsFailure()
    {
        var dto = CreateValidCreateDto() with { Name = "" };

        var result = await _sut.CreateServiceAsync(dto, TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeFalse();

        _repoMock.Verify(r => r.AddServiceAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()), Times.Never);

        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateServiceAsync_WhenPriceIsInvalid_ReturnsFailure()
    {
        var dto = CreateValidCreateDto() with { Price = 0m };

        var result = await _sut.CreateServiceAsync(dto, TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeFalse();

        _repoMock.Verify(r => r.AddServiceAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateServiceAsync_WhenDtoIsValid_CallsRepositoryAndUnitOfWork_AndReturnsSuccess()
    {
        var dto = CreateValidCreateDto();

        _repoMock
            .Setup(r => r.AddServiceAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        _unitOfWorkMock
            .Setup(
                u => u.SaveChangesAsync(
                    It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var result = await _sut.CreateServiceAsync(dto, TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeTrue();

        _repoMock.Verify(r => r.AddServiceAsync(It.IsAny<Service>(), It.IsAny<CancellationToken>()), Times.Once);

        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetServiceByIdAsync_WhenIdIsInvalid_ReturnsFailure()
    {
        var result = await _sut.GetServiceByIdAsync(0, TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeFalse();

        _repoMock.Verify(r => r.GetServiceByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task GetServiceByIdAsync_WhenServiceDoesNotExist_ReturnsFailure()
    {
        _repoMock
            .Setup(r => r.GetServiceByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Service?)null);

        var result = await _sut.GetServiceByIdAsync(1, TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeFalse();

        _repoMock.Verify(r => r.GetServiceByIdAsync(1, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetServiceByIdAsync_WhenServiceExists_ReturnsSuccess()
    {
        var service = CreateValidDomainService();

        _repoMock
            .Setup(r => r.GetServiceByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(service);

        var result = await _sut.GetServiceByIdAsync(1, TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task ListServicesAsync_WhenNoServicesExist_ReturnsFailure()
    {
        _repoMock
            .Setup(r => r.ListServicesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(Enumerable.Empty<Service>());

        var result = await _sut.ListServicesAsync(TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task ListServicesAsync_WhenServicesExist_ReturnsSuccess()
    {
        var services = new List<Service>
        {
            CreateValidDomainService("Service A", 100m, "Desc A"),
            CreateValidDomainService("Service B", 200m, "Desc B")
        };

        _repoMock
            .Setup(r => r.ListServicesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(services);

        var result = await _sut.ListServicesAsync(TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.Count().Should().Be(2);
    }

    [Fact]
    public async Task UpdateServiceAsync_WhenIdIsInvalid_ReturnsFailure()
    {
        var dto = CreateValidUpdateDto(0);

        var result = await _sut.UpdateServiceAsync(dto, TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeFalse();

        _repoMock.Verify(r => r.GetServiceByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);

        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateServiceAsync_WhenServiceDoesNotExist_ReturnsFailure()
    {
        var dto = CreateValidUpdateDto(1);

        _repoMock
            .Setup(r => r.GetServiceByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Service?)null);

        var result = await _sut.UpdateServiceAsync(dto, TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeFalse();
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateServiceAsync_WhenDtoIsValid_CallsUnitOfWork_AndReturnsSuccess()
    {
        var dto = CreateValidUpdateDto(1);
        var service = CreateValidDomainService("Old Name", 100m, "Old Description");

        _repoMock
            .Setup(r => r.GetServiceByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(service);

        _unitOfWorkMock
            .Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var result = await _sut.UpdateServiceAsync(dto, TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();

        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task DeleteServiceAsync_WhenIdIsInvalid_ReturnsFailure()
    {
        var result = await _sut.DeleteServiceAsync(0, TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeFalse();

        _repoMock.Verify(r => r.DeleteServiceAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);

        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task DeleteServiceAsync_WhenServiceDoesNotExist_ReturnsFailure()
    {
        _repoMock
            .Setup(r => r.GetServiceByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Service?)null);

        var result = await _sut.DeleteServiceAsync(1, TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeFalse();

        _repoMock.Verify(r => r.DeleteServiceAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);

        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task DeleteServiceAsync_WhenServiceExists_CallsDeleteAndSave_AndReturnsSuccess()
    {
        var service = CreateValidDomainService();

        _repoMock
            .Setup(r => r.GetServiceByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(service);

        _repoMock
            .Setup(r => r.DeleteServiceAsync(service.Id, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        _unitOfWorkMock
            .Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var result = await _sut.DeleteServiceAsync(1, TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeTrue();

        _repoMock.Verify(r => r.DeleteServiceAsync(service.Id, It.IsAny<CancellationToken>()), Times.Once);

        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
