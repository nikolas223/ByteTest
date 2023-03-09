using ByteTest.Application.Dtos;
using FluentResults;
using MediatR;

namespace ByteTest.Application.Queries.Models;

public class GetResumeQuery: IRequest<Result<CreateUpdateResumeDto>>
{
    public int Id { get; set; }
}