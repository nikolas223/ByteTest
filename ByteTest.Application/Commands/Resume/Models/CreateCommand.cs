using FluentResults;
using MediatR;

namespace ByteTest.Application.Commands.Resume.Models;

public class CreateCommand: IRequest<Result>
{
    public CommandProperties Properties { get; init; } = default!;
}