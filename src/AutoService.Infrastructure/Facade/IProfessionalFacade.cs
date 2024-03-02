using AutoService.Domain.Entities;
using AutoService.Payment.Infrastructure.Communication.DTOs;

namespace AutoService.Infrastructure.Facade
{
    public interface IProfessionalFacade
    {
        Task<Professional> GetProfessionalServicePaymentByEmail(string emailProfessional);
        Task<Professional> CreateProfessionalServicePayment(CreateCustomerDTO customer);
    }
}
