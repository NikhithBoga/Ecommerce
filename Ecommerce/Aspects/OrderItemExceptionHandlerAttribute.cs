using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Exceptions;

namespace Ecommerce.Aspects
{
    public class OrderItemExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            var message = context.Exception.Message;


            if (exceptionType == typeof(OrderItemNotFoundException))
            {
                var result = new NotFoundObjectResult(message);
                context.Result = result;
            }
            else if (exceptionType == typeof(OrderItemAlreadyExistsException))
            {
                var result = new ConflictObjectResult(message);
                context.Result = result;
            }
            else
            {
                var result = new StatusCodeResult(500);
                context.Result = result;
            }
        }

    }
}
