using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorksBlogProjectClient.ApiServices.Interfaces;
using WorksBlogProjectClient.Models;

namespace WorksBlogProjectClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthApiService _authApiService;
        public AccountController(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
        }

        public IActionResult SignIn()
        {
            return View(new AppUserLoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginModel appUserLoginModel)
        {
            var signIn = await _authApiService.SignInAsync(appUserLoginModel);
            if (signIn)
            {
                return RedirectToAction("Index", "Home", new { @area = "Admin" });
            }
            return View(appUserLoginModel);
        }

    }
}