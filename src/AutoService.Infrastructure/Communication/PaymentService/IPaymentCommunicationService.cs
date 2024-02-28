using AutoService.Core.Web;
using AutoService.Payment.Infrastructure.Communication.DTOs;

namespace AutoService.Infrastructure.Communication.DTOs
{
    public interface IPaymentCommunicationService
    {
        Task<RequestResult<ResponsePaymentDTO>> NewPayment(string customer, string professionalId, decimal value, string billingType);
    }
}
