using AutoService.Application.Extensions;
using AutoService.Core.Abstractions.CQRS.Handlers;
using AutoService.Core.Web;
using AutoService.Core.Web.Authentication;
using AutoService.Domain.Interfaces;
using MediatR;

namespace AutoService.Application.Commands.Professional.CreateProfessional
{
    public class CreateProfessionalCommandHandler : CommandHandler<CreateProfessionalCommand, Unit>
    {
        private readonly IAuthenticateService _authenticateService;

        private readonly IProfessionalRepository _professionalRepository;

        public CreateProfessionalCommandHandler(IAuthenticateService authenticateService, IProfessionalRepository professionalRepository)
        {
            _authenticateService = authenticateService;
            _professionalRepository = professionalRepository;
        }

        public override async Task<RequestResult<Unit>> Handle(CreateProfessionalCommand message, CancellationToken cancellationToken)
        {
            if (!message.Validate())
                return Fail(message.ValidationResult.ReturnErros());

            var passwordHash = _authenticateService.ComputeSha256Hash(message.Password);

            Domain.Entities.Professional professional = new(message.Name, passwordHash, message.Email, message.CPF);

            await _professionalRepository.CreateAsync(professional);

            await _professionalRepository.UnitOfWork.Commit();

            return Success();
        }
    }
}
