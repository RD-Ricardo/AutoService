using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.Core.Web.Api
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Erros = new List<string>();
        protected ActionResult CustomResponse<T>(RequestResult<T> request)
        {
            if (request.Success)
            {
               if(Request.Method == "GET" || Request.Method == "PUT")
                    return request.Data is Unit or null ? Ok() : Ok(request.Data);
               else if (Request.Method == "POST")
                    return Created(string.Empty, request);
            }

            return BadRequest(new { Sucesso = false, MensagensErros = request.ErrorsMessages.ToArray() });
        }
    }
}
