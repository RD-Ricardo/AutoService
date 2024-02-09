namespace AutoService.Core.Web
{
    public class RequestResult<TResult>
    {
        public bool Success { get; private set; }
        public TResult? Data { get; private set; }
        public string ErrorMessage { get; private set; }
        public RequestResult(bool success, TResult? data, string errorMessage = "")
        {
            Success = success;
            Data = data;
            ErrorMessage = errorMessage;
        }
    }
}
