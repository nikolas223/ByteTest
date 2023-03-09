using ByteTest.Application.Commands.Resume.Models;
using ByteTest.Application.Validators.Resume;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace ByteTest.Tests.CommandHandlers.Resume;

public class ValidatorCommandHandlerTests
{
    [Fact]
    public async Task ShouldFail_WhenFirstNameIsEmpty()
    {
        // Arrange
        var validator = new CommandPropertiesValidator();
        var cmd = new CommandProperties
        {
            FirstName = "",
            LastName = "Kanelopoulos",
            Email = "manolis@gmail.com",
            Mobile = "6973216547",
            DegreeId = 3
        };

        // Act
        var validationResult = await validator.ValidateAsync(cmd);

        // Assert
        validationResult.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public async Task ShouldFail_WhenLastNameIsEmpty()
    {
        // Arrange
        var validator = new CommandPropertiesValidator();
        var cmd = new CommandProperties
        {
            FirstName = "Manolis",
            LastName = "",
            Email = "manolis@gmail.com",
            Mobile = "6973216547",
            DegreeId = 3
        };

        // Act
        var validationResult = await validator.ValidateAsync(cmd);

        // Assert
        validationResult.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public async Task ShouldFail_WhenEmailIsEmpty()
    {
        // Arrange
        var validator = new CommandPropertiesValidator();
        var cmd = new CommandProperties
        {
            FirstName = "Manolis",
            LastName = "Kanelopoulos",
            Email = "",
            Mobile = "6973216547",
            DegreeId = 3
        };

        // Act
        var validationResult = await validator.ValidateAsync(cmd);

        // Assert
        validationResult.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public async Task ShouldFail_WhenEmailIsInvalid()
    {
        // Arrange
        var validator = new CommandPropertiesValidator();
        var cmd = new CommandProperties
        {
            FirstName = "Manolis",
            LastName = "Kanelopoulos",
            Email = "manolisgmail.com",
            Mobile = "6973216547",
            DegreeId = 3
        };

        // Act
        var validationResult = await validator.ValidateAsync(cmd);

        // Assert
        validationResult.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public async Task ShouldFail_WhenMobileIsMoreThan10Chars()
    {
        // Arrange
        var validator = new CommandPropertiesValidator();
        var cmd = new CommandProperties
        {
            FirstName = "Manolis",
            LastName = "Kanelopoulos",
            Email = "manolis@gmail.com",
            Mobile = "69732165473",
            DegreeId = 3
        };

        // Act
        var validationResult = await validator.ValidateAsync(cmd);

        // Assert
        validationResult.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public async Task ShouldFail_WhenMobileIsLessThan10Chars()
    {
        // Arrange
        var validator = new CommandPropertiesValidator();
        var cmd = new CommandProperties
        {
            FirstName = "Manolis",
            LastName = "Kanelopoulos",
            Email = "manolis@gmail.com",
            Mobile = "697321654",
            DegreeId = 3
        };

        // Act
        var validationResult = await validator.ValidateAsync(cmd);

        // Assert
        validationResult.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public async Task ShouldFail_WhenMobileIsNotNumeric()
    {
        // Arrange
        var validator = new CommandPropertiesValidator();
        var cmd = new CommandProperties
        {
            FirstName = "Manolis",
            LastName = "Kanelopoulos",
            Email = "manolis@gmail.com",
            Mobile = "697321654B",
            DegreeId = 3
        };

        // Act
        var validationResult = await validator.ValidateAsync(cmd);

        // Assert
        validationResult.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public async Task ShouldFail_WhenCvDoesHaveCorrectContentType()
    {
        // Arrange
        var validator = new CommandPropertiesValidator();
        
        //Setup mock file using a memory stream
        const string content = "Hello World from a Fake File";
        const string fileName = "test.pdf";
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        await writer.WriteAsync(content);
        await writer.FlushAsync();
        stream.Position = 0;
        
        var file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName)
        {
            Headers = new HeaderDictionary(),
            ContentType = "image/png"
        };

        var cmd = new CommandProperties
        {
            FirstName = "Manolis",
            LastName = "Kanelopoulos",
            Email = "manolis@gmail.com",
            Mobile = "6973216543",
            DegreeId = 3,
            Cv = file
        };

        // Act
        var validationResult = await validator.ValidateAsync(cmd);

        // Assert
        validationResult.IsValid.Should().BeFalse();
    }
}