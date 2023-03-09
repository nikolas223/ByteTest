using AutoMapper;
using ByteTest.Application.Commands.Resume.Models;
using ByteTest.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace ByteTest.Application.Commands.Resume.Handlers;

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
        var resume = await _unitOfWork.ResumesRepository.GetByIdOrDefault(request.Id);
        if (resume is null)
        {
            return Result.Fail("Resume not found");
        }
        
        var resumeUpdated = _mapper.Map(request.Properties, resume);
        
        _unitOfWork.ResumesRepository.Update(resumeUpdated);
        
        await _unitOfWork.SaveChangesAsync();

        return Result.Ok();
    }
}