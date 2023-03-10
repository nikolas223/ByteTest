using FluentResults;
using MediatR;

namespace ByteTest.Application.Commands.Resume.Models;

public class DeleteCommand: IRequest<Result>
{
    public int Id { get; set; }
}