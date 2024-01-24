using MediatR;

namespace AutoService.Core.Abstractions.CQRS
{
    public abstract class Query<TResult> : IRequest<TResult>
    {
       public abstract bool Validate();
    }
}
