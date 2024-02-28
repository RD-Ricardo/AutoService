using AutoService.Core.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoService.ProfessionalAccount.Application.UseCases.ContractFullAccess;

namespace AutoService.ProfessionalAccount.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessionalController : Controller
    {
        [HttpPut("ContractFullAccess")]
        public async Task<IActionResult> ContractFullAccess([FromServices] ContractFullAccessUseCase _contractFullAccessUseCase)
        {
            var result = await _contractFullAccessUseCase.Execute(this.ReturnUserId());

            if (!result.Success)
                return BadRequest(result.ErrorsMessages);

            return Ok(result);
        }
    }
}
