using Microsoft.AspNetCore.Mvc;

namespace AutoService.Api.Controllers
{
    public class ProfessionalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
