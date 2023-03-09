using ByteTest.Domain.Entities;
using ByteTest.Domain.Interfaces;

namespace ByteTest.Infrastructure.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private readonly ByteTestDbContext _context;
    public IGenericRepository<Resume> ResumesRepository { get; set; }
    public IGenericRepository<Degree> DegreesRepository { get; set; }

    public UnitOfWork(
        ByteTestDbContext context,
        IGenericRepository<Resume> resumesRepository,
        IGenericRepository<Degree> degreesRepository
        )
    {
        _context = context;
        ResumesRepository = resumesRepository;
        DegreesRepository = degreesRepository;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}