using AutoService.Core.Web.Extensions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace AutoService.Core.Web.Middleware
{
    public class ExeptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExeptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";

                RequestResult<bool> responseModel = null;

                switch (ex)
                {
                    case CustomHttpRequestExeption e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel = new RequestResult<bool>(false, errorMessage: new List<string>() { $"Error - {e.Message}" });
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel = new RequestResult<bool>(false, errorMessage: new List<string>() { "Error - route not found" });
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
