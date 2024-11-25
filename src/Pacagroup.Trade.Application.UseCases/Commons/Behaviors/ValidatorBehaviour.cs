

using FluentValidation;
using MediatR;
using Pacagroup.Trade.Application.UseCases.Commons.Exceptions;

namespace Pacagroup.Trade.Application.UseCases.Commons.Behaviors;

public class ValidatorBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidatorBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validatorResults = await Task.WhenAll(
                _validators.Select(v =>
                v.ValidateAsync(context, cancellationToken)));

            var failures = validatorResults.Where(r=>r.Errors.Any()).SelectMany(r=>r.Errors).ToList();

            if (failures.Any())
            {
                throw new ValidationExceptionCustom(failures);

                
            }
                
        }

        return await next();
    }
}

