using CleanArchitecture.Application.Common.Models.Errors;
using CleanArchitecture.Application.Common.Models.General;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.WebApi.Filters
{
    public class GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger) : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger = logger;

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
            

            context.ExceptionHandled= true;

            if (context.Exception is ValidationException)
            {
                var exception = context.Exception as ValidationException;

                var responseMessage= "Validation Error..";

                var errors = new List<ErrorDto>();

                var propertyNames = exception.Errors.Select(x => x.PropertyName).Distinct();

                foreach (var propertyName in propertyNames)
                {
                   var messages = exception.Errors.Where(x => x.PropertyName == propertyName).Select(x => x.ErrorMessage).ToList();
                    errors.Add(new ErrorDto(propertyName, messages));
                }

                context.Result = new BadRequestObjectResult(new ResponseDto<string>(responseMessage, errors))
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            else
            {
                context.Result = new ObjectResult(new ResponseDto<string>("Internal Server Error..",false))
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
            
        }
    }
}
