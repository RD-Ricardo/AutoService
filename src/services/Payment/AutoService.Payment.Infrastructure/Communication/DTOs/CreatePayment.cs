using AutoService.Payment.Infrastructure.Communication.DTOs;

namespace AutoService.Payment.Infrastructure.Communication
{
    public class CreatePayment
    {
        public string billingType { get; set; }
        public Discount discount { get; set; }
        public Interest interest { get; set; }
        public Fine fine { get; set; }
        public string customer { get; set; }
        public string dueDate { get; set; }
        public decimal value { get; set; }
        public string description { get; set; }
        public int daysAfterDueDateToCancellationRegistration { get; set; }
        public string externalReference { get; set; }
        public bool postalService { get; set; }
    }
}
