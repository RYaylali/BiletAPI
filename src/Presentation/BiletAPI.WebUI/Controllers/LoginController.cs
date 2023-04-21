using Microsoft.AspNetCore.Mvc;

namespace BiletAPI.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
