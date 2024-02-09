using AutoService.Payment.Domain.Enums;
using AutoService.Payment.Infrastructure.Facade;

namespace AutoService.Payment.Infrastructure.Factory
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
