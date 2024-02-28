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

        public override async Task<RequestResult<Unit>> Handle(CreateProfessionalCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return Fail(request.ValidationResult.ReturnErros());

            var passwordHash = _authenticateService.ComputeSha256Hash(request.Password);

            Domain.Entities.Professional professional = new(request.Name, passwordHash, request.Email, request.CPF);

            await _professionalRepository.CreateAsync(professional);

            await _professionalRepository.UnitOfWork.Commit();

            return Success();
        }
    }

    public static class ValidationResultExtension
    {
        public static IEnumerable<string> ReturnErros(this FluentValidation.Results.ValidationResult validationResult) =>
            validationResult.Errors.Select(e => e.ErrorMessage);
    }
}
