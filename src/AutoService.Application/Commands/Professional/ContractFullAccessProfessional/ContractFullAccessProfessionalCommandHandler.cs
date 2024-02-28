using AutoService.Core.Abstractions.CQRS.Handlers;
using AutoService.Core.Web;
using AutoService.Domain.Interfaces;
using MediatR;

namespace AutoService.Application.Commands.Professional.ContractFullAccessProfessional
{
    public class ContractFullAccessProfessionalCommandHandler : CommandHandler<ContractFullAccessProfessionalCommand, Unit>
    {
        private readonly IProfessionalRepository _professionalRepository;

        public ContractFullAccessProfessionalCommandHandler(IProfessionalRepository professionalRepository)
        {
            _professionalRepository = professionalRepository;
        }

        public override async Task<RequestResult<Unit>> Handle(ContractFullAccessProfessionalCommand request, CancellationToken cancellationToken)
        {
            var professional = await _professionalRepository.FindByIdAsync(request.ProfessionalId);

            if (professional.Permission == Domain.Enums.PermissionEnum.Admin)
                return Fail("Error professional have access full");

            //if (!success.ValidationResult)
            //    return new RequestResult<bool>(false, false, new List<string>() { "Error process payment" });

            professional.ChangeAcecssToFull();

            await _professionalRepository.UnitOfWork.Commit();

            return Success();
        }
    }
}
