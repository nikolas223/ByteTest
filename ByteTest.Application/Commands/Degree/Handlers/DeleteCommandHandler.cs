using ByteTest.Application.Commands.Degree.Models;
using ByteTest.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace ByteTest.Application.Commands.Degree.Handlers;

public class DeleteCommandHandler: IRequestHandler<DeleteCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var degree = await _unitOfWork.DegreesRepository.GetByIdOrDefault(request.Id);
        if (degree is null)
        {
            return Result.Fail("Degree not found");
        }

        // Normally i would catch the foreign key violation exception in save changes
        // but because i used an in memory database and does not throw these kind of exceptions, i perform the check this way.
        // I know it is not realistic  
        var resumes = await _unitOfWork.ResumesRepository.ListAsync();
        var degreesUsed = resumes.Where(x=> x.DegreeId != null).Select(x => x.DegreeId).OfType<int>();
        if (degreesUsed.Contains(degree.Id))
        {
            return Result.Fail("Degree is being used in resume");
        }
        
        _unitOfWork.DegreesRepository.Delete(degree);
        
        await _unitOfWork.SaveChangesAsync();

        return Result.Ok();
    }
}