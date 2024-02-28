using Microsoft.AspNetCore.Http;

namespace AutoService.Core.Web
{
    public class RequestResult<TResult>
    {
        public bool Success { get; private set; }
        public TResult Data { get; private set; }
        public List<string> ErrorsMessages { get; private set; }
        public RequestResult(bool success, 
            TResult data = default, 
            List<string> errorMessage = null)
        {
            Success = success;
            Data = data;
            ErrorsMessages = errorMessage;
        }
    }
}
