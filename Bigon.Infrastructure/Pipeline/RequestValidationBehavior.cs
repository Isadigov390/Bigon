using FluentValidation;
using MediatR;

namespace Bigon.Infrastructure.Pipeline
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest> validator;

        public RequestValidationBehavior(IValidator<TRequest> validator)
        {
            this.validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            validator.Validate(request);
            return next();  
        }
    }
}
