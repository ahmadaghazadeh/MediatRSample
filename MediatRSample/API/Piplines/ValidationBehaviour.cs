using FluentValidation;
using MediatR;

namespace API.Piplines
{
    public class ValidationBehaviour<TRequest, TResponsed> : IPipelineBehavior<TRequest, TResponsed> where TRequest : IRequest<TResponsed>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponsed> Handle(TRequest request, RequestHandlerDelegate<TResponsed> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }
            return await next();
        }
    }
}
