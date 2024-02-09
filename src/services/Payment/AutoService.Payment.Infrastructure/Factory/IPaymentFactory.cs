using AutoService.Payment.Domain.Enums;
using AutoService.Payment.Infrastructure.Facade;

namespace AutoService.Payment.Infrastructure.Factory
{
    public interface IPaymentFactory
    {
        IPaymentFacade GetService(PaymentTypeEnum type);
    }
}
