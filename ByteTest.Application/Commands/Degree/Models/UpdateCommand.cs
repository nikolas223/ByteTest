using FluentResults;
using MediatR;

namespace ByteTest.Application.Commands.Degree.Models;

public class UpdateCommand: IRequest<Result>
{
    public int Id { get; init; }
    public CommandProperties Properties { get; init; } = default!;
}