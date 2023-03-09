using FluentResults;
using FluentValidation;
using MediatR;

namespace ByteTest.Application.Behaviors;

public class ValidatorBehavior<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidatorBehavior(
        IEnumerable<IValidator<TRequest>> validators
        )
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validationResult = await ValidateAsync(request);
        if (validationResult.IsFailed)
        {
            var result = new TResponse();

            foreach (var reason in validationResult.Reasons)
                result.Reasons.Add(reason);

            return result;
        }

        return await next();
    }
    
    private Task<Result> ValidateAsync(TRequest request)
    {
        var failures = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error is not null)
            .ToList();
        
        if (!failures.Any()) return Task.FromResult(Result.Ok());
        
        var errors = new List<Error>();
        
        foreach (var validationFailure in failures)
        {
            errors.Add(new Error(validationFailure.ErrorMessage));
        }

        return Task.FromResult(Result.Fail(errors));
    }
}