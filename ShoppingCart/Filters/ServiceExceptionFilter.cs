using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShoppingCart.Exceptions;

namespace ShoppingCart.Filters
{
    public class ServiceExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch(context.Exception)
            {
                case EntityNotFoundException ex:
                    context.Result = new NotFoundObjectResult(ex.Message);
                    break;
                case CartProcessFailedException ex:
                    context.Result = new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status500InternalServerError };
                    break;
            }
        }
    }
}
