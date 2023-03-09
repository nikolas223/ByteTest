using AutoMapper;
using ByteTest.Application.Commands.Degree.Models;
using ByteTest.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace ByteTest.Application.Commands.Degree.Handlers;

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
        var degree = _mapper.Map<Domain.Entities.Degree>(request.Properties);
        
        _unitOfWork.DegreesRepository.Add(degree);
        
        await _unitOfWork.SaveChangesAsync();

        return Result.Ok();
    }
}