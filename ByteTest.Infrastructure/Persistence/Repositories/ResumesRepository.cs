using ByteTest.Domain.Entities;

namespace ByteTest.Infrastructure.Persistence.Repositories;

public class ResumesRepository : GenericRepository<Resume>
{
    public ResumesRepository(ByteTestDbContext db) : base(db)
    {
    }
}