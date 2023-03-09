using AutoMapper;
using ByteTest.Application.Dtos;
using ByteTest.Application.Queries.Models;
using ByteTest.Domain.Interfaces;
using MediatR;

namespace ByteTest.Application.Queries.Handlers;

public class GetDegreesQueryHandler: IRequestHandler<GetDegreesQuery, List<DegreeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetDegreesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<DegreeDto>> Handle(GetDegreesQuery request, CancellationToken cancellationToken)
    {
        var degrees = await _unitOfWork.DegreesRepository.ListAsync();
        
        return _mapper.Map<List<DegreeDto>>(degrees);
    }
}