using Dental.Domain.Entities;
using Dental.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Dental.UnitTests.Domain.Entities;

public class ServiceTests
{
    private static ServiceName CreateValidName(string value = "Dental Cleaning")
    {
        var result = ServiceName.Create(value);

        result.IsSuccess.Should().BeTrue();

        return result.Value;
    }

    private static Money CreateValidPrice(decimal value = 150m)
    {
        var result = Money.Create(value);

        result.IsSuccess.Should().BeTrue();

        return result.Value;
    }

    private static Service CreateValidService(
        string name = "Dental Cleaning",
        decimal price = 150m,
        string? description = "Routine dental cleaning")
    {
        var result = Service.Create(
            CreateValidName(name),
            CreateValidPrice(price),
            description);

        result.IsSuccess.Should().BeTrue();

        return result.Value;
    }

    [Fact]
    public void Create_WhenDescriptionExceedsMaxLength_ReturnsFailure()
    {
        var description = new string('A', Service.DescriptionMaxLength + 1);

        var result = Service.Create(
            CreateValidName(),
            CreateValidPrice(),
            description);

        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public void Create_WhenDescriptionIsNull_ReturnsSuccess()
    {
        var result = Service.Create(
            CreateValidName(),
            CreateValidPrice(),
            null);

        result.IsSuccess.Should().BeTrue();

        result.Value.Description.Should().BeNull();
    }

    [Fact]
    public void Create_WhenDescriptionIsEmpty_ReturnsSuccess()
    {
        var result = Service.Create(
            CreateValidName(),
            CreateValidPrice(),
            string.Empty);

        result.IsSuccess.Should().BeTrue();

        result.Value.Description.Should().Be(string.Empty);
    }

    [Fact]
    public void Create_WhenDataIsValid_ReturnsSuccess()
    {
        var result = Service.Create(
            CreateValidName(),
            CreateValidPrice(),
            "Routine dental cleaning");

        result.IsSuccess.Should().BeTrue();

        result.Value.Name.Value.Should().Be("Dental Cleaning");
        result.Value.Price.Value.Should().Be(150m);
        result.Value.Description.Should().Be("Routine dental cleaning");
    }

    [Fact]
    public void Update_WhenDescriptionExceedsMaxLength_ReturnsFailure()
    {
        var service = CreateValidService();

        var description = new string('A', Service.DescriptionMaxLength + 1);

        var result = service.Update(
            CreateValidName("Updated Service"),
            CreateValidPrice(250m),
            description);

        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public void Update_WhenDescriptionIsNull_ReturnsSuccess_AndUpdatesProperties()
    {
        var service = CreateValidService();

        var result = service.Update(
            CreateValidName("Updated Service"),
            CreateValidPrice(250m),
            null);

        result.IsSuccess.Should().BeTrue();

        service.Name.Value.Should().Be("Updated Service");
        service.Price.Value.Should().Be(250m);
        service.Description.Should().BeNull();
    }

    [Fact]
    public void Update_WhenDescriptionIsEmpty_ReturnsSuccess_AndUpdatesProperties()
    {
        var service = CreateValidService();

        var result = service.Update(
            CreateValidName("Updated Service"),
            CreateValidPrice(250m),
            string.Empty);

        result.IsSuccess.Should().BeTrue();

        service.Name.Value.Should().Be("Updated Service");
        service.Price.Value.Should().Be(250m);
        service.Description.Should().Be(string.Empty);
    }

    [Fact]
    public void Update_WhenDataIsValid_ReturnsSuccess_AndUpdatesProperties()
    {
        var service = CreateValidService();

        var result = service.Update(
            CreateValidName("Root Canal"),
            CreateValidPrice(500m),
            "Updated description");

        result.IsSuccess.Should().BeTrue();

        service.Name.Value.Should().Be("Root Canal");
        service.Price.Value.Should().Be(500m);
        service.Description.Should().Be("Updated description");
    }
}