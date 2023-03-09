using ByteTest.Domain.Implementations;

namespace ByteTest.Domain.Entities;

public class Degree: Entity
{
    public string Name { get; set; } = string.Empty;
    
    public ICollection<Resume> Resumes { get; set; } = default!;
}