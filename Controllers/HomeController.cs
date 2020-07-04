using Microsoft.AspNetCore.Mvc;

namespace WorksBlogProjectClient.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}