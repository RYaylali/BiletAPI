using Microsoft.AspNetCore.Mvc;

namespace BiletAPI.WebUI.Controllers
{
	public class HomePageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
