using ByteTest.Application.Dtos;
using FluentResults;
using MediatR;

namespace ByteTest.Application.Queries.Models;

public class GetDegreeQuery: IRequest<Result<CreateUpdateDegreeDto>>
{
    public int Id { get; set; }
}