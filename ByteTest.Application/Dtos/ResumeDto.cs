namespace ByteTest.Application.Dtos;

public class ResumeDto
{
    public int Id { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
    public string? CvFileName { get; set; }
    public DateTime CreationTime { get; set; }
}