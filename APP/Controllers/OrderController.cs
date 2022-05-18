using Microsoft.AspNetCore.Mvc;

namespace APP.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
