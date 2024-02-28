using AutoService.Core.DomainObjects;
using AutoService.Domain.Enums;

namespace AutoService.Domain.Entities
{
    public sealed class Payment : AggregateRoot
    {
        public Guid ProfessionalId { get; private set; }
        public decimal Value { get; private set; }
        public PaymentTypeEnum PaymentType { get; private set; }
        public string? CustomerId { get; private set; }
        public Payment(Guid professionalId, decimal value, PaymentTypeEnum paymentType, string? customerId)
        {
            ProfessionalId = professionalId;
            Value = value;
            PaymentType = paymentType;
            Transactions = new List<Transaction>();
            CustomerId = customerId;
        }
        
        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        //EF
        public Professional Professional { get; set; }
        public ICollection<Transaction> Transactions { get; private set; }
        protected Payment() {}
    }
}
