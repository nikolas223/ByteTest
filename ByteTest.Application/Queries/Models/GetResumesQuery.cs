using ByteTest.Application.Dtos;
using MediatR;

namespace ByteTest.Application.Queries.Models;

public class GetResumesQuery: IRequest<List<ResumeDto>>
{
    
}