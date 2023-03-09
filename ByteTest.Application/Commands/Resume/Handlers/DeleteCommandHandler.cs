using ByteTest.Application.Commands.Resume.Models;
using ByteTest.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace ByteTest.Application.Commands.Resume.Handlers;

public class DeleteCommandHandler: IRequestHandler<DeleteCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var resume = await _unitOfWork.ResumesRepository.GetByIdOrDefault(request.Id);
        if (resume is null)
        {
            return Result.Fail("Resume not found");
        }

        _unitOfWork.ResumesRepository.Delete(resume);
        
        await _unitOfWork.SaveChangesAsync();

        return Result.Ok();
    }
}