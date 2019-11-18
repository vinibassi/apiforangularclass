using Microsoft.AspNetCore.Mvc;

namespace Web.Photos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}