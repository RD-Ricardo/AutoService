using MediatR;

namespace AutoService.Core.Abstractions.CQRS
{
    public abstract class Command<TResult> : IRequest<TResult>
    {
        public abstract bool Validate();
    }
}
