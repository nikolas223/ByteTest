using ByteTest.Application.Commands.Resume.Models;
using FluentValidation;

namespace ByteTest.Application.Validators.Resume;

public class CreateCommandValidator: AbstractValidator<CreateCommand>
{
    public CreateCommandValidator()
    {
        RuleFor(com => com.Properties).SetValidator(new CommandPropertiesValidator());
    }
}