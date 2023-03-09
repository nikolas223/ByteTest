using ByteTest.Application.Commands.Degree.Models;
using ByteTest.Application.Validators.Degree;
using FluentAssertions;
using Xunit;

namespace ByteTest.Tests.CommandHandlers.Degree;

public class ValidatorCommandHandlerTests
{
    [Fact]
    public async Task ShouldFail_WhenNameIsEmpty()
    {
        // Arrange
        var validator = new CommandPropertiesValidator();
        var cmd = new CommandProperties
        {
            Name = "",
        };

        // Act
        var validationResult = await validator.ValidateAsync(cmd);

        // Assert
        validationResult.IsValid.Should().BeFalse();
    }
}