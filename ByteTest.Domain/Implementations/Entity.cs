using ByteTest.Domain.Interfaces;

namespace ByteTest.Domain.Implementations;

public class Entity : IEntity
{
    public int Id { get; set; } = default!;
    public DateTime CreationTime { get; set; }
    public DateTime? LastModificationTime { get; set; }
}