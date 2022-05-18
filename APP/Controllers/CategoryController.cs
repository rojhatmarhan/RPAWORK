using Microsoft.AspNetCore.Mvc;

namespace APP.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
