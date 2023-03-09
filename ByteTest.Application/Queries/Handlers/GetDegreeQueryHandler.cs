using AutoMapper;
using ByteTest.Application.Dtos;
using ByteTest.Application.Queries.Models;
using ByteTest.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace ByteTest.Application.Queries.Handlers;

public class GetDegreeQueryHandler: IRequestHandler<GetDegreeQuery, Result<CreateUpdateDegreeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDegreeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateUpdateDegreeDto>> Handle(GetDegreeQuery request, CancellationToken cancellationToken)
    {
        var degree = await _unitOfWork.DegreesRepository.GetByIdOrDefault(request.Id);
        if (degree is null)
        {
            return Result.Fail("Degree not found");
        }

        var updateDegreeDto = _mapper.Map<CreateUpdateDegreeDto>(degree);

        return Result.Ok(updateDegreeDto);
    }
}