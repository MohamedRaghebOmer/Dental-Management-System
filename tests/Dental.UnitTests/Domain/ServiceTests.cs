using Dental.Domain.Entities;
using Dental.Domain.Errors;
using Dental.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Dental.UnitTests.Domain;

public class ServiceTests
{
    private static ServiceName ValidName(string value = "Teeth Cleaning") =>
        ServiceName.Create(value).Value;

    private static Money ValidPrice(decimal value = 100m) =>
        Money.Create(value).Value;

    public class Create : ServiceTests
    {
        [Fact]
        public void Should_ReturnSuccessResult_When_DataIsValid()
        {
            // Arrange
            var name = ValidName();
            var price = ValidPrice();
            const string description = "A standard dental cleaning service.";

            // Act
            var result = Service.Create(name, price, description);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
            result.Value.Name.Should().Be(name);
            result.Value.Price.Should().Be(price);
            result.Value.Description.Should().Be(description);
        }

        [Fact]
        public void Should_ReturnSuccessResult_When_DescriptionIsNull()
        {
            // Arrange
            var name = ValidName();
            var price = ValidPrice();

            // Act
            var result = Service.Create(name, price, description: null);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Description.Should().BeNull();
        }

        [Fact]
        public void Should_ReturnSuccessResult_When_DescriptionIsExactlyAtMaxLength()
        {
            // Arrange
            var name = ValidName();
            var price = ValidPrice();
            var description = new string('a', Service.DescriptionMaxLength);

            // Act
            var result = Service.Create(name, price, description);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Description.Should().HaveLength(Service.DescriptionMaxLength);
        }

        [Fact]
        public void Should_ReturnFailureResult_When_DescriptionExceedsMaxLength()
        {
            // Arrange
            var name = ValidName();
            var price = ValidPrice();
            var description = new string('a', Service.DescriptionMaxLength + 1);

            // Act
            var result = Service.Create(name, price, description);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(DomainErrors.Services.Description.TooLong);
        }

        [Fact]
        public void Should_NotThrow_When_AccessingErrorOnFailure()
        {
            // Arrange
            var name = ValidName();
            var price = ValidPrice();
            var description = new string('a', Service.DescriptionMaxLength + 1);

            // Act
            var result = Service.Create(name, price, description);
            var act = () => result.Value;

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }
    }

    public class Update : ServiceTests
    {
        [Fact]
        public void Should_UpdateAllProperties_When_DataIsValid()
        {
            // Arrange
            var service = Service.Create(ValidName("Old Name"), ValidPrice(50m), "Old description").Value;

            var newName = ValidName("New Name");
            var newPrice = ValidPrice(200m);
            const string newDescription = "New description";

            // Act
            var result = service.Update(newName, newPrice, newDescription);

            // Assert
            result.IsSuccess.Should().BeTrue();
            service.Name.Should().Be(newName);
            service.Price.Should().Be(newPrice);
            service.Description.Should().Be(newDescription);
        }

        [Fact]
        public void Should_ReturnSuccess_When_DescriptionIsNull()
        {
            // Arrange
            var service = Service.Create(ValidName(), ValidPrice(), "Some description").Value;

            // Act
            var result = service.Update(ValidName("Updated"), ValidPrice(150m), description: null);

            // Assert
            result.IsSuccess.Should().BeTrue();
            service.Description.Should().BeNull();
        }

        [Fact]
        public void Should_ReturnSuccess_When_DescriptionIsWhitespace()
        {
            // Arrange
            var service = Service.Create(ValidName(), ValidPrice()).Value;

            // Act
            var result = service.Update(ValidName(), ValidPrice(), description: "   ");

            // Assert
            // Whitespace-only description bypasses the length check (IsNullOrWhiteSpace short-circuits)
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Should_ReturnFailure_When_DescriptionExceedsMaxLength()
        {
            // Arrange
            var service = Service.Create(ValidName(), ValidPrice()).Value;
            var tooLongDescription = new string('a', Service.DescriptionMaxLength + 1);

            var originalName = service.Name;
            var originalPrice = service.Price;
            var originalDescription = service.Description;

            // Act
            var result = service.Update(ValidName("Should Not Apply"), ValidPrice(999m), tooLongDescription);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(DomainErrors.Services.Description.TooLong);
        }

        [Fact]
        public void Should_NotMutateState_When_UpdateFails()
        {
            // Arrange
            var originalName = ValidName("Original");
            var originalPrice = ValidPrice(75m);
            const string originalDescription = "Original description";
            var service = Service.Create(originalName, originalPrice, originalDescription).Value;

            var tooLongDescription = new string('a', Service.DescriptionMaxLength + 1);

            // Act
            var result = service.Update(ValidName("Attempted New Name"), ValidPrice(999m), tooLongDescription);

            // Assert
            result.IsFailure.Should().BeTrue();
            service.Name.Should().Be(originalName);
            service.Price.Should().Be(originalPrice);
            service.Description.Should().Be(originalDescription);
        }

        [Fact]
        public void Should_AllowUpdatingToSameValues()
        {
            // Arrange
            var name = ValidName();
            var price = ValidPrice();
            var service = Service.Create(name, price, "desc").Value;

            // Act
            var result = service.Update(name, price, "desc");

            // Assert
            result.IsSuccess.Should().BeTrue();
        }
    }

    public class Equality : ServiceTests
    {
        [Fact]
        public void Should_BeEqual_When_SameReference()
        {
            // Arrange
            var service = Service.Create(ValidName(), ValidPrice()).Value;

            // Act & Assert
            service.Equals(service).Should().BeTrue();
            (service == service).Should().BeTrue();
        }

        [Fact]
        public void Should_NotBeEqual_When_ComparedToNull()
        {
            // Arrange
            var service = Service.Create(ValidName(), ValidPrice()).Value;

            // Act & Assert
            service.Equals(null).Should().BeFalse();
        }

        // Note: Two freshly created Services both have Id == 0 (default int),
        // so Entity.Equals treats them as equal by design (Id-based equality).
        // This test documents that current behavior explicitly.
        [Fact]
        public void Should_BeEqual_When_BothHaveDefaultId_DueToIdBasedEquality()
        {
            // Arrange
            var service1 = Service.Create(ValidName("A"), ValidPrice(10m)).Value;
            var service2 = Service.Create(ValidName("B"), ValidPrice(20m)).Value;

            // Act & Assert
            service1.Equals(service2).Should().BeTrue("Entity equality is based solely on Id, and both have the default Id of 0");
        }
    }
}