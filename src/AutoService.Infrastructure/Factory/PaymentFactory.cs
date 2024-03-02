using AutoService.Domain.Enums;
using AutoService.Infrastructure.Facade;
using AutoService.Infrastructure.Facade.MethodsPayments;

namespace AutoService.Infrastructure.Factory
{
    public class PaymentFactory : IPaymentFactory
    {
        PaymentPix _paymentPixSevice;
        public PaymentFactory(PaymentPix paymentPixSevice)
        {
            _paymentPixSevice = paymentPixSevice;
        }

        public IPaymentFacade GetService(PaymentTypeEnum type)
        {
            IPaymentFacade payment = null;

            switch (type)
            {
                case PaymentTypeEnum.Pix:
                    payment = _paymentPixSevice;
                    break;
                case PaymentTypeEnum.CardCredit:
                    payment = _paymentPixSevice;
                    break;
                default:
                    break;
            }

            return payment;
        }
    }
}