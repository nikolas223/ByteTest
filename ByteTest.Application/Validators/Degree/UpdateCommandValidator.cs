using ByteTest.Application.Commands.Degree.Models;
using FluentValidation;

namespace ByteTest.Application.Validators.Degree;

public class UpdateCommandValidator: AbstractValidator<UpdateCommand>
{
    public UpdateCommandValidator()
    {
        RuleFor(com => com.Properties).SetValidator(new CommandPropertiesValidator());
    }
}