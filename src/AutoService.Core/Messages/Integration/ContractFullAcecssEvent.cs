using AutoService.Core.Messages.Integration;

namespace AutoService.Core.Messages.Integration
{
    public class ContractFullAcecssEvent : IntegrationEvent
    {
        public int PaymentType { get; private set; }
        public string UserId { get; private set; }
        public string Email { get; private set; }
        public decimal ValueContractFull { get; private set; }
        public string NameProfessional { get; private set; }
        public string Cpf { get; set; }
        public ContractFullAcecssEvent(string userId, string email, decimal valueContractFull, int paymentType, string nameProfessional, string cpf)
        {
            UserId = userId;
            Email = email;
            ValueContractFull = valueContractFull;
            PaymentType = paymentType;
            NameProfessional = nameProfessional;
            Cpf = cpf;
        }

    }
}
