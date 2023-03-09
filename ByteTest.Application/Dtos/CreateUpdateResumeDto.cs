using ByteTest.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ByteTest.Application.Dtos;

public class CreateUpdateResumeDto
{
    public int Id { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public int? DegreeId { get; set; }
    public string? CvFileName { get; set; }
    public IFormFile Cv { get; set; } = default!;
    public List<Degree> Degrees { get; set; } = default!;
}