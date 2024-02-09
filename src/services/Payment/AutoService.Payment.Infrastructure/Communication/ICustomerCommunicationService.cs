using AutoService.Payment.Infrastructure.Communication.DTOs;

namespace AutoService.Payment.Infrastructure.Communication
{
    public interface ICustomerCommunicationService
    {
        Task<CustomerDTO> GetCustomerByEmail(string email);
        Task<CustomerDTO> CreateCustomer(CreateCustomerRequest customer);
    }
}
