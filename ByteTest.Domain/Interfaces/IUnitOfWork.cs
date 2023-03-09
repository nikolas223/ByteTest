using ByteTest.Domain.Entities;

namespace ByteTest.Domain.Interfaces;

public interface IUnitOfWork
{
    IGenericRepository<Resume> ResumesRepository { get; set; }
    IGenericRepository<Degree> DegreesRepository { get; set; }
    Task SaveChangesAsync();
}