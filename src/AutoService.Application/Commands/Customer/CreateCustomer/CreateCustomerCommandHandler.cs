using AutoService.Application.Extensions;
using AutoService.Application.ViewModels;
using AutoService.Core.Abstractions.CQRS.Handlers;
using AutoService.Core.Web;
using AutoService.Domain.Interfaces;
using MediatR;

namespace AutoService.Application.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandHandler : CommandHandler<CreateCustomerCommand, CustomerCreateViewModel>
    {
        private readonly ICustomerRepository _customerRepository;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public override async Task<RequestResult<CustomerCreateViewModel>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.ValidationResult.IsValid)
                return Fail(request.ValidationResult.ReturnErros());

            var customerExist = await _customerRepository.FindByEmail(request.Email);

            if (customerExist is not null)
                return Fail("Customer exist in base of data");

            Domain.Entities.Customer customer  = new(request.Name, request.Email, request.Phone, request.ProfessionalId);

            await _customerRepository.Create(customer);

            await _customerRepository.UnitOfWork.Commit();

            var returnCustomer = new CustomerCreateViewModel(customer.Id.ToString(), customer.Name, customer.Email, customer.Phone);

            return Success(returnCustomer);
        }
    }
}
