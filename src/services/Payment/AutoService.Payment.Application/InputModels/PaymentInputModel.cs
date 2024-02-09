using AutoService.Payment.Domain.Enums;

namespace AutoService.Payment.Application.InputModels
{
    public class PaymentInputModel
    {
        public decimal Value { get; set; }
        public string ProfessionalId { get; set; }
        public PaymentTypeEnum Method { get; set; }
        public string EmailCustomer { get; set; }
    }
}
