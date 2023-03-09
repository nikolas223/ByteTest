using ByteTest.Application.Dtos;
using FluentResults;
using MediatR;

namespace ByteTest.Application.Queries.Models;

public class GetResumeCvQuery: IRequest<Result<CvDto>>
{
    public int Id { get; set; }
}