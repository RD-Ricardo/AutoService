using AutoService.Payment.Infrastructure.Communication.DTOs;

namespace AutoService.Infrastructure.Communication.DTOs
{
    public class CreatePaymentDTO
    {
        public string billingType { get; set; }
        public DiscountDTO discount { get; set; }
        public InterestDTO interest { get; set; }
        public FineDTO fine { get; set; }
        public string customer { get; set; }
        public string dueDate { get; set; }
        public decimal value { get; set; }
        public string description { get; set; }
        public int daysAfterDueDateToCancellationRegistration { get; set; }
        public string externalReference { get; set; }
        public bool postalService { get; set; }
    }
}
