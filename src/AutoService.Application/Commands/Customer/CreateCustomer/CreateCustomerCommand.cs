using MediatR;
using AutoService.Core.Abstractions.CQRS;
using AutoService.Application.ViewModels;

namespace AutoService.Application.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommand : Command<CustomerCreateViewModel>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int? Phone { get; private set; }
        public Guid ProfessionalId { get; private set; }
        public CreateCustomerCommand(string name, string email, int? phone, Guid professionalId)
        {
            Name = name;
            Email = email;
            Phone = phone;
            ProfessionalId = professionalId;
        }

        public override bool Validate()
        {
            return false;
        }
    }
}
