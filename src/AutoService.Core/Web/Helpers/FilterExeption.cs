using AutoService.Core.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text.Json;

namespace AutoService.Core.Web.Helpers
{
    public class FilterExeption : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            RequestResult<bool> responseModel = null;

            switch (context.Exception)
            {
                case CustomHttpRequestExeption e:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel = new RequestResult<bool>(false, errorMessage: new List<string>() { $"Error - {e.Message}" });
                    break;
                case KeyNotFoundException e:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseModel = new RequestResult<bool>(false, errorMessage: new List<string>() { "Error - route not found" });
                    break;
                default:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Result = new ObjectResult(JsonSerializer.Serialize(responseModel));
        }
    }
}
