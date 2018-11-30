using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PizzariaUDS.DTO;
using System.Net;

namespace PizzariaUDS.Exceptions
{
    public class PizzriaUDSCustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            HttpResponse response = context.HttpContext.Response;

            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            response.ContentType = "application/json";
            context.Result = new JsonResult(new ApiExceptionDTO
            {
                ExceptionType = exception.GetType().Name,
                Message = exception.Message,
                StackTrace = exception.StackTrace
            });
        }
    }
}
