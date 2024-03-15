using AutoService.Core.Abstractions.CQRS;
using AutoService.Core.Messages;
using AutoService.Core.Web;

namespace AutoService.Core.Abstractions.Mediator
{
    public interface IMediatorHandler
    {
        Task<RequestResult<TResult>> SendCommand<TCommand, TResult>(TCommand command) where TCommand : Command<TResult>;
        Task<RequestResult<TResult>> SendQuery<TQuery, TResult>(TQuery query) where TQuery : Query<TResult>;
        //Task PublishNotification<TNotification>(TNotification notification) where TNotification : DomainNotification;
        Task PublishDomainEvent<TEvent>(TEvent evento) where TEvent : Event;
    }
}
