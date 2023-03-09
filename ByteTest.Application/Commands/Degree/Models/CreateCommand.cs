using FluentResults;
using MediatR;

namespace ByteTest.Application.Commands.Degree.Models;

public class CreateCommand: IRequest<Result>
{
    public CommandProperties Properties { get; init; } = default!;
}