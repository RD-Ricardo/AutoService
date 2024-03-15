using AutoService.Core.Web;
using AutoService.Payment.Infrastructure.Communication.DTOs;

namespace AutoService.Infrastructure.Communication
{
    public interface IPaymentCommunicationService
    {
        Task<RequestResult<ResponsePaymentDTO>> NewPayment(string customer, string professionalId, decimal value, string billingType);
    }
}
