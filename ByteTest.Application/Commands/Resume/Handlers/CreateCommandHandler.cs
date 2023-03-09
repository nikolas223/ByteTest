using AutoMapper;
using ByteTest.Application.Commands.Resume.Models;
using ByteTest.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace ByteTest.Application.Commands.Resume.Handlers;

public class CreateCommandHandler: IRequestHandler<CreateCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        var resume = _mapper.Map<Domain.Entities.Resume>(request.Properties);
        
        _unitOfWork.ResumesRepository.Add(resume);
        
        await _unitOfWork.SaveChangesAsync();

        return Result.Ok();
    }
}