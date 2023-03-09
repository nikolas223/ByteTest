namespace ByteTest.Application.Dtos;

public class CvDto
{
    public string CvFileName { get; set; } = string.Empty;
    public string CvContentType { get; set; } = string.Empty;
    public byte[] Cv { get; set; } = default!;
}