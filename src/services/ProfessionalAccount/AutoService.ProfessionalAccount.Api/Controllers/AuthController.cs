using AutoService.ProfessionalAccount.Application.InputModels;
using AutoService.ProfessionalAccount.Application.UseCases.LoginUser;
using AutoService.ProfessionalAccount.Application.UseCases.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.ProfessionalAccount.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(
            [FromBody] UserLoginInputModel userLoginInputModel, 
            [FromServices] UserLoginUseCase _userLoginUseCase)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _userLoginUseCase.Execute(userLoginInputModel);

            if (!result.Success)
                return BadRequest(result.ErrorsMessages);

            return Ok(result.Data);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(
            [FromBody] UserRegisterInputModel userRegisterInputModel,
            [FromServices] UserRegisterUseCase _userRegisterUseCase)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _userRegisterUseCase.Execute(userRegisterInputModel);

            if (!result.Success)
                return BadRequest(result.ErrorsMessages);

            return Ok(result);
        }
    }
}
