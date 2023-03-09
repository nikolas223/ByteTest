using FluentResults;
using MediatR;

namespace ByteTest.Application.Commands.Degree.Models;

public class CommandProperties: IRequest<Result>
{
    public string Name { get; set; } = string.Empty;
}