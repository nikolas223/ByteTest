using AutoMapper;
using ByteTest.Application.Dtos;
using ByteTest.Application.Queries.Models;
using ByteTest.Domain.Interfaces;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ByteTest.Application.Queries.Handlers;

public class GetResumeCvQueryHandler: IRequestHandler<GetResumeCvQuery, Result<CvDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetResumeCvQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CvDto>> Handle(GetResumeCvQuery request, CancellationToken cancellationToken)
    {
        var resume = await _unitOfWork.ResumesRepository.GetByIdOrDefault(request.Id);
        if (resume is null)
        {
            return Result.Fail("Resume not found");
        }
        
        if (resume.Cv is null)
        {
            return Result.Fail("Resume does not have CV");
        }

        var dto = _mapper.Map<CvDto>(resume);

        return Result.Ok(dto);
    }
}