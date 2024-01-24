﻿using MediatR;

namespace AutoService.Core.Abstractions.CQRS.Handlers
{
    public abstract class CommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : Command<TResult>
    {
        public abstract Task<TResult> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
