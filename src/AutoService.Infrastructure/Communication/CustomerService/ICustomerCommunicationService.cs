using AutoService.Infrastructure.Communication.DTOs;
using AutoService.Payment.Infrastructure.Communication.DTOs;

namespace AutoService.Infrastructure.Communication.CustomerService
{
    public interface ICustomerCommunicationService
    {
        Task<CustomerDTO> GetCustomerByEmail(string email);
        Task<CustomerDTO> CreateCustomer(CreateCustomerDTO customer);
    }
}
