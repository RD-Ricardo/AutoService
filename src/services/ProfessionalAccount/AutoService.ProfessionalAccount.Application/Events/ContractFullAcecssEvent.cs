using AutoService.Core.Messages.Integration;

namespace AutoService.ProfessionalAccount.Application.Events
{
    public class ContractFullAcecssEvent : IntegrationEvent
    {
        public string UserId { get; private set; }
        public string Email { get; private set; }
        public decimal ValueContractFull { get; private set; }
        public ContractFullAcecssEvent(string userId, string email, decimal valueContractFull)
        {
            UserId = userId;
            Email = email;
            ValueContractFull = valueContractFull;
        }

    }
}
