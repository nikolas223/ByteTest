using ByteTest.Application.Commands.Resume.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ByteTest.Application.Validators.Resume;

public class CommandPropertiesValidator: AbstractValidator<CommandProperties>
{
    public CommandPropertiesValidator()
    {
        RuleFor(com => com.LastName).NotEmpty().MaximumLength(64);
            
        RuleFor(com => com.FirstName).NotEmpty().MaximumLength(64);
        
        RuleFor(com => com.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(64);
        
        RuleFor(com => com.Mobile).Length(10).Matches("^[0-9]+$").WithMessage("Mobile can have only digits.");
        
        RuleFor(x => x.Cv)
            .Must(ValidContentType)
            .WithMessage("File type is not allowed");
    }
    
    private static bool ValidContentType(IFormFile? file)
    {
        return file == null || file.ContentType.Equals("application/msword") || file.ContentType.Equals("application/vnd.openxmlformats-officedocument.wordprocessingml.document") || file.ContentType.Equals("application/pdf");
    }
}