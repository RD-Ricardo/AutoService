using AutoService.Core.Abstractions.CQRS;
using AutoService.Core.Messages;
using AutoService.Core.Web;
using MediatR;

namespace AutoService.Core.Abstractions.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        
        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<RequestResult<TResult>> SendCommand<TCommand, TResult>(TCommand command) where TCommand : Command<TResult>
        {
            return _mediator.Send(command);
        }

        public Task PublishDomainEvent<TEvent>(TEvent evento) where TEvent : Event
        {
            return _mediator.Publish(evento);
        }

        public Task<RequestResult<TResult>> SendQuery<TQuery, TResult>(TQuery query) where TQuery : Query<TResult>
        {
            return _mediator.Send(query);
        }
    }
}
