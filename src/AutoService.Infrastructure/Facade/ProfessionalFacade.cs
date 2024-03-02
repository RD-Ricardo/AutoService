using AutoService.Domain.Entities;
using AutoService.Infrastructure.Communication.DTOs;
using AutoService.Infrastructure.Communication.CustomerService;
using AutoService.Payment.Infrastructure.Communication.DTOs;

namespace AutoService.Infrastructure.Facade
{
    public class ProfessionalFacade : IProfessionalFacade
    {
        private readonly ICustomerCommunicationService _customerCommunicationService;
        public ProfessionalFacade(ICustomerCommunicationService customerCommunicationService)
        {
            _customerCommunicationService = customerCommunicationService;
        }

        public async Task<Professional> CreateProfessionalServicePayment(CreateCustomerDTO customer)
        {
            return ConvertCustomerForProfessional(await _customerCommunicationService.CreateCustomer(customer));
        }

        public async Task<Professional> GetProfessionalServicePaymentByEmail(string emailProfessional)
        {
            return ConvertCustomerForProfessional(await _customerCommunicationService.GetCustomerByEmail(emailProfessional));
        }

        private static Professional ConvertCustomerForProfessional(CustomerDTO customerDTO)
        {
            return new Professional(customerDTO.Name, string.Empty, customerDTO.Email, customerDTO.cpfCnpj);
        }
    }
}