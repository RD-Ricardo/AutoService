namespace AutoService.Payment.Application.ViewModels
{
    public class PaymentViewModel
    {
        public string ProfessionalId { get; set; }
        public string  CustomerId { get; set; }
        public decimal Value { get; set; }
        public TransactionViewModel Transaction { get; set; }
    }
}
