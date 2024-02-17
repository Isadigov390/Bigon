using Azure;
using Bigon.Infrastructure.Exceptions;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Bigon.Presentation.Pipeline
{
    public class ValidatorInterceptor : IValidatorInterceptor
    {
        public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
        {
            if (!result.IsValid)
            {

                var errors = result.Errors.GroupBy(m => m.PropertyName)
                    .ToDictionary(m => m.Key, v => v.Select(m => m.ErrorMessage));

                throw new BadRequestException("Gonderilen serti odemir", errors);   
            }
            return result;
        }

        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
        {
            return commonContext;   
        }
    }
}
