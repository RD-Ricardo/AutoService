using AutoService.Core.Web;
using FluentValidation.Results;
using MediatR;

namespace AutoService.Core.Abstractions.CQRS
{
    public abstract class Command<TResult> : IRequest<RequestResult<TResult>>
    {
        public ValidationResult ValidationResult { get; set; }
        public abstract bool Validate();
    }
}
