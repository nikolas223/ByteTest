using ByteTest.Application.Commands.Degree.Models;
using FluentValidation;

namespace ByteTest.Application.Validators.Degree;

public class CreateCommandValidator: AbstractValidator<CreateCommand>
{
    public CreateCommandValidator()
    {
        RuleFor(com => com.Properties).SetValidator(new CommandPropertiesValidator());
    }
}