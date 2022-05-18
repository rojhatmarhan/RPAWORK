using Microsoft.AspNetCore.Mvc;

namespace APP.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
