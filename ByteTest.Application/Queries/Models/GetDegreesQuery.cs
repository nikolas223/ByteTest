using ByteTest.Application.Dtos;
using MediatR;

namespace ByteTest.Application.Queries.Models;

public class GetDegreesQuery: IRequest<List<DegreeDto>>
{
    
}