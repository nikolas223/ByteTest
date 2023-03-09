using AutoMapper;
using ByteTest.Application.Dtos;
using ByteTest.Application.Queries.Models;
using ByteTest.Domain.Interfaces;
using MediatR;

namespace ByteTest.Application.Queries.Handlers;

public class GetResumesQueryHandler: IRequestHandler<GetResumesQuery, List<ResumeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetResumesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ResumeDto>> Handle(GetResumesQuery request, CancellationToken cancellationToken)
    {
        var resumes = await _unitOfWork.ResumesRepository.ListAsync("Degree");
        
        return _mapper.Map<List<ResumeDto>>(resumes);
    }
}