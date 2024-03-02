namespace AutoService.Core.Web
{
    public class RequestResult<TResult>
    {
        public bool Success { get; private set; }
        public TResult Data { get; private set; }
        public IEnumerable<string> ErrorsMessages { get; private set; }
        public RequestResult(bool success, 
            TResult data = default,
            IEnumerable<string> errorMessage = null)
        {
            Success = success;
            Data = data;
            ErrorsMessages = errorMessage;
        }
    }
}
