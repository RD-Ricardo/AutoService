using AutoService.Application.Commands.Professional.ContractFullAccessProfessional;
using AutoService.Application.Commands.Professional.CreateProfessional;
using AutoService.Application.Commands.Professional.LoginProfessional;
using AutoService.Application.InputModels;
using AutoService.Core.Abstractions.Mediator;
using AutoService.Core.Web;
using AutoService.Core.Web.Api;
using AutoService.Core.Web.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProfessionalController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ProfessionalController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginInputModel loginInputModel)
        {
            var command = new LoginProfessionalCommand(loginInputModel.Login, loginInputModel.Password);

            var result =  await _mediatorHandler.SendCommand<LoginProfessionalCommand, string>(command);

            return CustomResponse(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterInputModel registerInputModel)
        {
            var command = new CreateProfessionalCommand(registerInputModel.Email, registerInputModel.Password, registerInputModel.PasswordConfirmed, registerInputModel.CPF, registerInputModel.Name);

            var result = await _mediatorHandler.SendCommand<CreateProfessionalCommand, Unit>(command);

            return CustomResponse(result);
        }

        [HttpPut("ContractFullAccess")]
        public async Task<IActionResult> ContractFullAccess()
        {
            var command = new ContractFullAccessProfessionalCommand(Guid.Parse("2d76c8d8-3578-4951-8ce6-a66cd50ad236"));

            var result = await _mediatorHandler.SendCommand<ContractFullAccessProfessionalCommand, Unit>(command);

            return CustomResponse(result);
        }
    }
}
