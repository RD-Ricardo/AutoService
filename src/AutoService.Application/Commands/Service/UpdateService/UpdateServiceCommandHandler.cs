using AutoService.Application.Extensions;
using AutoService.Core.Abstractions.CQRS.Handlers;
using AutoService.Core.Data;
using AutoService.Core.Web;
using AutoService.Domain.Interfaces;
using MediatR;

namespace AutoService.Application.Commands.Service.UpdateService
{
    public class UpdateServiceCommandHandler : CommandHandler<UpdateServiceCommand, Unit>
    {
        private readonly IServiceRepository _repository;
        public UpdateServiceCommandHandler(IServiceRepository repository)
        {
            _repository = repository;
        }

        public override async Task<RequestResult<Unit>> Handle(UpdateServiceCommand message, CancellationToken cancellationToken)
        {
            if (!message.Validate())
                return Fail(message.ValidationResult.ReturnErros());

            Domain.Entities.Service service = new(message.Name,
                message.Description,
            message.Value,
                message.ProfessionalId);

            _repository.UpdateServiceAsync(service);

            await _repository.UnitOfWork.Commit();

            return Success();
        }
    }
}
