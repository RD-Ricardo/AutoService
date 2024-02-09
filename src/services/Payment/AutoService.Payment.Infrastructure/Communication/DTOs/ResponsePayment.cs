namespace AutoService.Payment.Infrastructure.Communication.DTOs
{
    public class ResponsePayment
    {
        public string @object { get; set; }
        public string id { get; set; }
        public string dateCreated { get; set; }
        public string customer { get; set; }
        public object paymentLink { get; set; }
        public double value { get; set; }
        public double netValue { get; set; }
        public object originalValue { get; set; }
        public object interestValue { get; set; }
        public string description { get; set; }
        public string billingType { get; set; }
        public object pixTransaction { get; set; }
        public string status { get; set; }
        public string dueDate { get; set; }
        public string originalDueDate { get; set; }
        public object paymentDate { get; set; }
        public object clientPaymentDate { get; set; }
        public object installmentNumber { get; set; }
        public string invoiceUrl { get; set; }
        public string invoiceNumber { get; set; }
        public string externalReference { get; set; }
        public bool deleted { get; set; }
        public bool anticipated { get; set; }
        public bool anticipable { get; set; }
        public object creditDate { get; set; }
        public object estimatedCreditDate { get; set; }
        public object transactionReceiptUrl { get; set; }
        public object nossoNumero { get; set; }
        public object bankSlipUrl { get; set; }
        public object lastInvoiceViewedDate { get; set; }
        public object lastBankSlipViewedDate { get; set; }
        public Discount discount { get; set; }
        public Fine fine { get; set; }
        public Interest interest { get; set; }
        public bool postalService { get; set; }
        public object custody { get; set; }
        public object refunds { get; set; }
    }
}
