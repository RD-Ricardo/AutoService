using AutoService.Core.Abstractions.UseCases;
using AutoService.Core.Messages.Integration;
using AutoService.Core.Web;
using AutoService.ProfessionalAccount.Domain.Interfaces;
using EasyNetQ;

namespace AutoService.ProfessionalAccount.Application.UseCases.ContractFullAccess
{
    public class ContractFullAccessUseCase : IUseCase<Guid, bool>
    {
        private IBus _bus;
        private readonly IProfessionalRepository _professionalRepository;
        
        //Test
        private const int METHOD_PAYMENT = 1;
        private const decimal VALUE_PAYMENT = 60.90m;
        private const string HOST_RABBITMQ = "host=localhost:5672";

        public ContractFullAccessUseCase(IProfessionalRepository professionalRepository)
        {
            _professionalRepository = professionalRepository;
        }

        public async Task<RequestResult<bool>> Execute(Guid parameter)
        {
            var professional = await _professionalRepository.FindByIdAsync(parameter);

            if(professional.Permission == Domain.Enums.PermissionEnum.Admin)
                return new RequestResult<bool>(false, false, "Error professional have access full");

            var request = new ContractFullAcecssEvent(professional.Id.ToString(), 
                professional.Email,
                VALUE_PAYMENT,
                METHOD_PAYMENT,
                professional.Name,
                professional.CPF);
            
            _bus = RabbitHutch.CreateBus(HOST_RABBITMQ);

            var success = await _bus.Rpc.RequestAsync<ContractFullAcecssEvent, ResponseMessage>(request);

            if (!success.ValidationResult)
                return new RequestResult<bool>(false, false, "Error process payment");

            professional.ChangeAcecssToFull();

            await _professionalRepository.UnitOfWork.Commit();

           return new RequestResult<bool>(true, true);
        }
    }
}
