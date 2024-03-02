using Microsoft.AspNetCore.Mvc;

namespace AutoService.Api.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
