using AutoService.Core.Abstractions.CQRS.Handlers;
using AutoService.Core.Web;
using MediatR;

namespace AutoService.Application.Commands.Service.UpdateService
{
    public class UpdateServiceCommandHandler : CommandHandler<UpdateServiceCommand, Unit>
    {
        public override Task<RequestResult<Unit>> Handle(UpdateServiceCommand message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
