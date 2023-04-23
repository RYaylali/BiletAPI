using BiletAPI.Application.Models.Dtos;
using BiletAPI.Application.Service.UserServices;
using BiletAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System;
using Microsoft.AspNetCore.Authorization;
using BiletAPI.API.Model;
using System.Security.Claims;

namespace BiletAPI.WebUI.Controllers
{

	public class LoginController : Controller
	{
		string uri = "https://localhost:7270/api";
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginDto model)
		{
			using (var httpClient = new HttpClient())
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"); //Türkçe karakterini destekleyen json oluşturduk.

				using (var cevap = await httpClient.PostAsync($"{uri}/User/Login/Login", content))
				{
					string apiCevap = await cevap.Content.ReadAsStringAsync();
					var identity = HttpContext.User.Identity as ClaimsIdentity;
					var kullaniciAdi = identity.FindFirst(ClaimTypes.Name)?.Value;
					ViewBag.KullaniciAdi = kullaniciAdi;
				}
			}

			return RedirectToAction("Index", "HomePage");
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(UserRegisterDto model)
		{
			using (var httpClient = new HttpClient())
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"); //Türkçe karakterini destekleyen json oluşturduk.

				using (var cevap = await httpClient.PostAsync($"{uri}/User/Register/Register", content))
				{
					string apiCevap = await cevap.Content.ReadAsStringAsync();


				}
			}
			return RedirectToAction("Login");
		}


	}
}
