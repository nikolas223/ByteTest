using ByteTest.Application.Commands.Resume.Models;
using FluentValidation;

namespace ByteTest.Application.Validators.Resume;

public class UpdateCommandValidator: AbstractValidator<UpdateCommand>
{
    public UpdateCommandValidator()
    {
        RuleFor(com => com.Properties).SetValidator(new CommandPropertiesValidator());
    }
}