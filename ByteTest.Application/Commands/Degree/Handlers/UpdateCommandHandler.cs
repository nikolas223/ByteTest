using AutoMapper;
using ByteTest.Application.Commands.Degree.Models;
using ByteTest.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace ByteTest.Application.Commands.Degree.Handlers;

public class UpdateCommandHandler: IRequestHandler<UpdateCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var degree = await _unitOfWork.DegreesRepository.GetByIdOrDefault(request.Id);
        if (degree is null)
        {
            return Result.Fail("Degree not found");
        }
        
        var degreeUpdated = _mapper.Map(request.Properties, degree);
        
        _unitOfWork.DegreesRepository.Update(degreeUpdated);
        
        await _unitOfWork.SaveChangesAsync();

        return Result.Ok();
    }
}