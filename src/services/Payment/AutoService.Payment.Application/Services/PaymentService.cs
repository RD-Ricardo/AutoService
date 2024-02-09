
using AutoService.Payment.Application.InputModels;
using AutoService.Payment.Application.ViewModels;
using AutoService.Payment.Domain.Repositories;
using AutoService.Payment.Infrastructure.Communication;
using AutoService.Payment.Infrastructure.Factory;

namespace AutoService.Payment.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentFactory _paymentFactory;
        private readonly ICustomerCommunicationService _customerCommunicationService;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentFactory paymentFactory,
            ICustomerCommunicationService customerCommunicationService,
            IPaymentRepository paymentRepository)
        {
            _paymentFactory = paymentFactory;
            _customerCommunicationService = customerCommunicationService;
            _paymentRepository = paymentRepository;
        }

        public async Task<bool> ExecutePayment(PaymentInputModel paymentInputModel)
        {
            var customer = await _customerCommunicationService.GetCustomerByEmail(paymentInputModel.EmailCustomer);

            if (customer == null)
                return false;

            var paymentSeviceFacade = _paymentFactory.GetService(paymentInputModel.Method);

            var payment = new Domain.Entities.Payment(
                Guid.Parse(paymentInputModel.ProfessionalId), 
                paymentInputModel.Value, 
                paymentInputModel.Method,
                customer.id);
            
            var transaction = await paymentSeviceFacade.AuthorizeTransaction(payment);

            if (transaction == null) 
                return false;

            payment.AddTransaction(transaction);

            await _paymentRepository.CreatePayment(payment);
            
            return true;
        }

        public async Task<IEnumerable<PaymentViewModel>> GetPayments(Guid professionalId)
        {
            var payments = await _paymentRepository.GetPaymentsByProfessioalId(professionalId);
            
            return payments.Select(p => new PaymentViewModel
            { 
                ProfessionalId = p.ProfessionalId.ToString(),
                CustomerId = p.CustomerId,
                Value = p.Value,
                Transaction = new TransactionViewModel
                {
                    TID = p.Transactions.First().TID,
                    NSU = p.Transactions.First().NSU,
                    Status = p.Transactions.First().Status.ToString(),
                    DateCreated = p.Transactions.First().CreationDate.ToString("dd/MM/YY"),
                }
            });
        }

        public async Task<IEnumerable<TransactionViewModel>> GetTransactionsByProfessional(Guid professionalId)
        {
            var payments = await _paymentRepository.GetPaymentsByProfessioalId(professionalId);

            var transations = payments.SelectMany(p => p.Transactions).Select(t => new TransactionViewModel
            {
                DateCreated = t.CreationDate.ToString("dd/MM/yyyy"),
                NSU = t.NSU,
                TID = t.TID,
                Status = t.Status.ToString()
            });

            return transations;
        }
    }
}
