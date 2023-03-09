using ByteTest.Domain.Entities;

namespace ByteTest.Infrastructure.Persistence.Repositories;

public class DegreesRepository : GenericRepository<Degree>
{
    public DegreesRepository(ByteTestDbContext db) : base(db)
    {
    }
}