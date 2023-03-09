using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ByteTest.Application.Commands.Resume.Models;

public class CommandProperties: IRequest<Result>
{
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Mobile { get; set; } = string.Empty;
    public IFormFile? Cv { get; set; }
    public int? DegreeId { get; set; }
    
}