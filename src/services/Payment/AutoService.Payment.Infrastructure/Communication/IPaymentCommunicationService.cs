using AutoService.Core.Web;
using AutoService.Payment.Infrastructure.Communication.DTOs;

namespace AutoService.Payment.Infrastructure.Communication
{
    public interface IPaymentCommunicationService
    {
        Task<RequestResult<ResponsePayment>> NewPayment(string customer, string professionalId, decimal value, string billingType);
    }
}
