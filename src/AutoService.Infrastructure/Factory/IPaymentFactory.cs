using AutoService.Domain.Enums;
using AutoService.Infrastructure.Facade;

namespace AutoService.Infrastructure.Factory
{
    public interface IPaymentFactory
    {
        IPaymentFacade GetService(PaymentTypeEnum type);
    }
}
