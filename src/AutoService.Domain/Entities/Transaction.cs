using AutoService.Core.DomainObjects;
using AutoService.Domain.Enums;

namespace AutoService.Domain.Entities
{
    public sealed class Transaction : Entity
    {
        public string TransactionCode { get; private set; }
        public decimal TransactionCost { get; private set; }
        public TransactionStatus Status { get; private set; }
        public string TID { get; private set; }
        public string NSU { get; private set; }
        public Guid PaymentId { get; private set; }

        //EF
        public Payment Payment { get; set; }

        public Transaction(string transactionCode, decimal transactionCost, TransactionStatus status, string tID, string nSU, Guid paymentId)
        {
            TransactionCode = transactionCode;
            TransactionCost = transactionCost;
            Status = status;
            TID = tID;
            NSU = nSU;
            PaymentId = paymentId;
        }
    }
}
