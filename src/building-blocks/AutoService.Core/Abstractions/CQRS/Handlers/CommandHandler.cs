using AutoService.Core.Web;
using MediatR;

namespace AutoService.Core.Abstractions.CQRS.Handlers
{
    public abstract class CommandHandler<TCommand, TResult> : IRequestHandler<TCommand, RequestResult<TResult>> where TCommand : Command<TResult>
    {
        public abstract Task<RequestResult<TResult>> Handle(TCommand request, CancellationToken cancellationToken);

        public RequestResult<TResult> Success()
        {
            return new RequestResult<TResult>(success: true);
        }

        public RequestResult<TResult> Success(TResult result)
        {
            return new RequestResult<TResult>(success: true, data: result, errorMessage: null);
        }

        public RequestResult<TResult> Fail(List<string> messages)
        {
            return new RequestResult<TResult>(success: false, errorMessage: messages);
        }

        public RequestResult<TResult> Fail(string error)
        {
            return new RequestResult<TResult>(success: false, errorMessage: new List<string>() { error });
        }
    }
}
