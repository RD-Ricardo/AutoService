using System.Net;

namespace AutoService.Core.Web.Extensions
{
    public class CustomHttpRequestExeption : Exception
    {
        public HttpStatusCode StatusCode;

        public CustomHttpRequestExeption()
        {
            
        }

        public CustomHttpRequestExeption(string message, Exception innerExeption): base (message, innerExeption) 
        {
        }

        public CustomHttpRequestExeption(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
