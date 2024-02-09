using AutoService.Core.DomainObjects;
using AutoService.Payment.Domain.Enums;

namespace AutoService.Payment.Domain.Entities
{
    public class Payment : AggregateRoot
    {
        public Guid ProfessionalId { get; private set; }
        public decimal Value  { get; private set; }
        public PaymentTypeEnum  PaymentType { get; private set; }
        public string? CustomerId { get; private set; }
        public Payment(Guid professionalId, decimal value, PaymentTypeEnum paymentType, string? customerId)
        {
            ProfessionalId = professionalId;
            Value = value;
            PaymentType = paymentType;
            Transactions = new List<Transaction>();
            CustomerId = customerId;
        }

        //EF
        public ICollection<Transaction> Transactions { get;  private set; }
        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);  
        }
    }
}
