using AutoMapper;
using ByteTest.Application.Dtos;
using ByteTest.Application.Queries.Models;
using ByteTest.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace ByteTest.Application.Queries.Handlers;

public class GetResumeQueryHandler: IRequestHandler<GetResumeQuery, Result<CreateUpdateResumeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetResumeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateUpdateResumeDto>> Handle(GetResumeQuery request, CancellationToken cancellationToken)
    {
        var resume = await _unitOfWork.ResumesRepository.GetByIdOrDefault(request.Id);
        if (resume is null)
        {
            return Result.Fail("Resume not found");
        }

        var updateResumeDto = _mapper.Map<CreateUpdateResumeDto>(resume);

        updateResumeDto.Degrees = await _unitOfWork.DegreesRepository.ListAsync();
        
        return Result.Ok(updateResumeDto);
    }
}