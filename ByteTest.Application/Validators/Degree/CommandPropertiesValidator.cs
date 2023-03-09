using ByteTest.Application.Commands.Degree.Models;
using FluentValidation;

namespace ByteTest.Application.Validators.Degree;

public class CommandPropertiesValidator: AbstractValidator<CommandProperties>
{
    public CommandPropertiesValidator()
    {
        RuleFor(com => com.Name).NotEmpty().MaximumLength(64);

    }
}