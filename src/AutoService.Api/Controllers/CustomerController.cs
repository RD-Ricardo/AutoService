using AutoService.Application.Commands.Customer.CreateCustomer;
using AutoService.Application.InputModels;
using AutoService.Application.ViewModels;
using AutoService.Core.Abstractions.Mediator;
using AutoService.Core.Web.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        public CustomerController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerInputModel customerInputModel)
        {
            var command = new CreateCustomerCommand(customerInputModel.Name, customerInputModel.Email, customerInputModel.Phone, Guid.Parse("2d76c8d8-3578-4951-8ce6-a66cd50ad236"));

            var result = await _mediatorHandler.SendCommand<CreateCustomerCommand, CustomerCreateViewModel>(command);

            return CustomResponse(result);
        }
    }
}
