using AutoMapper;
using ByteTest.Application.Commands.Degree.Handlers;
using ByteTest.Application.Commands.Degree.Models;
using ByteTest.Domain.Interfaces;
using FluentAssertions;
using FluentResults;
using Moq;
using Xunit;

namespace ByteTest.Tests.CommandHandlers.Degree;

public class UpdateCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly UpdateCommandHandler _handler;
    
    public UpdateCommandHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        var mapperMock = new Mock<IMapper>();
        _handler = new UpdateCommandHandler(_unitOfWorkMock.Object, mapperMock.Object);
    }
    
    [Fact]
    public async Task ShouldFail_WhenIdNotFound()
    {
        // Arrange
        var command = new UpdateCommand();
        _unitOfWorkMock.Setup(x => x.DegreesRepository.GetByIdOrDefault(It.IsAny<int>())).ReturnsAsync((int _) => null);

        // Act 
        var response = await _handler.Handle(command, default);

        // Assert
        response.Should().Match<Result>(x => x.IsFailed);
    }
}