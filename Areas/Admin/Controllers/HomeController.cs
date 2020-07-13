using Microsoft.AspNetCore.Mvc;
using WorksBlogProjectClient.Filters;

namespace WorksBlogProjectClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [JwtAuthorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}