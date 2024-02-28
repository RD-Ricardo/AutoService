using Microsoft.AspNetCore.Mvc;

namespace AutoService.Api.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
