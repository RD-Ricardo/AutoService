using AutoService.Application.Extensions;
using AutoService.Core.Abstractions.CQRS.Handlers;
using AutoService.Core.Web;
using AutoService.Domain.Interfaces;
using MediatR;

namespace AutoService.Application.Commands.Service.CreateService
{
    public class CreateServiceCommandHandler : CommandHandler<CreateServiceCommand, Unit>
    {
        private readonly IServiceRepository _repository;
        public CreateServiceCommandHandler(IServiceRepository repository)
        {
            _repository = repository;
        }

        public override async Task<RequestResult<Unit>> Handle(CreateServiceCommand message, CancellationToken cancellationToken)
        {
            if (!message.Validate())
                return Fail(message.ValidationResult.ReturnErros());

            Domain.Entities.Service service = new (message.Name, 
                message.Description, 
                message.Value, 
                message.ProfessionalId);

            await _repository.CreateServiceAsync(service);

            await _repository.UnitOfWork.Commit();

            return Success();
        }
    }
}
