using ByteTest.Application.Commands.Degree.Handlers;
using ByteTest.Application.Commands.Degree.Models;
using ByteTest.Domain.Interfaces;
using FluentAssertions;
using FluentResults;
using Moq;
using Xunit;

namespace ByteTest.Tests.CommandHandlers.Degree;

public class DeleteCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly DeleteCommandHandler _handler;
    
    public DeleteCommandHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _handler = new DeleteCommandHandler(_unitOfWorkMock.Object);
    }
    
    [Fact]
    public async Task ShouldFail_WhenIdNotFound()
    {
        // Arrange
        var command = new DeleteCommand();
        _unitOfWorkMock.Setup(x => x.DegreesRepository.GetByIdOrDefault(It.IsAny<int>())).ReturnsAsync((int _) => null);

        // Act 
        var response = await _handler.Handle(command, default);

        // Assert
        response.Should().Match<Result>(x => x.IsFailed);
    }
}