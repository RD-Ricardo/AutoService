using AutoService.Infrastructure.Communication.DTOs;

namespace AutoService.Payment.Infrastructure.Communication.DTOs
{
    public class ResponsePaymentDTO
    {
        public string @object { get; set; }
        public string Id { get; set; }
        public string DateCreated { get; set; }
        public string Customer { get; set; }
        public object PaymentLink { get; set; }
        public double Value { get; set; }
        public double NetValue { get; set; }
        public object originalValue { get; set; }
        public object interestValue { get; set; }
        public string description { get; set; }
        public string billingType { get; set; }
        public object pixTransaction { get; set; }
        public string status { get; set; }
        public string dueDate { get; set; }
        public string OriginalDueDate { get; set; }
        public object PaymentDate { get; set; }
        public object ClientPaymentDate { get; set; }
        public object InstallmentNumber { get; set; }
        public string InvoiceUrl { get; set; }
        public string InvoiceNumber { get; set; }
        public string ExternalReference { get; set; }
        public bool Deleted { get; set; }
        public bool anticipated { get; set; }
        public bool anticipable { get; set; }
        public object creditDate { get; set; }
        public object estimatedCreditDate { get; set; }
        public object transactionReceiptUrl { get; set; }
        public object nossoNumero { get; set; }
        public object bankSlipUrl { get; set; }
        public object lastInvoiceViewedDate { get; set; }
        public object lastBankSlipViewedDate { get; set; }
        public DiscountDTO Discount { get; set; }
        public FineDTO Fine { get; set; }
        public InterestDTO Interest { get; set; }
        public bool postalService { get; set; }
        public object custody { get; set; }
        public object refunds { get; set; }
    }
}
