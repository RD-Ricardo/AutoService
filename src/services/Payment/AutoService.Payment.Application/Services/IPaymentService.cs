using AutoService.Payment.Application.InputModels;
using AutoService.Payment.Application.ViewModels;

namespace AutoService.Payment.Application.Services
{
    public interface IPaymentService
    {
        Task<bool> ExecutePayment(PaymentInputModel paymentInputModel);
        Task<IEnumerable<TransactionViewModel>> GetTransactionsByProfessional(Guid professionalId);
        Task<IEnumerable<PaymentViewModel>> GetPayments(Guid professionalId);
    }
}
