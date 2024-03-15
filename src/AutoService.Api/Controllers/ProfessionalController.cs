using AutoService.Application.Commands.Professional.LoginProfessional;
using AutoService.Application.InputModels;
using AutoService.Core.Abstractions.Mediator;
using AutoService.Core.Web;
using AutoService.Core.Web.Api;
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

        [HttpPost]
        public async Task<IActionResult> Login(LoginInputModel loginInputModel)
        {
            var command = new LoginProfessionalCommand(loginInputModel.Login, loginInputModel.Password);

            var result =  await _mediatorHandler.SendCommand<LoginProfessionalCommand, string>(command);

            return CustomResponse(result);
        }
    }
}
