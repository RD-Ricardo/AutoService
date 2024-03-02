using Microsoft.AspNetCore.Mvc;

namespace AutoService.Api.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
