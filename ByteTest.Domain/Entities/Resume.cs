using ByteTest.Domain.Implementations;

namespace ByteTest.Domain.Entities;

public class Resume: Entity
{
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Mobile { get; set; }
    public string? CvFileName { get; set; }
    public string? CvContentType { get; set; }
    public byte[]? Cv { get; set; }
    public int? DegreeId { get; set; }
    public Degree? Degree { get; set; } 
}