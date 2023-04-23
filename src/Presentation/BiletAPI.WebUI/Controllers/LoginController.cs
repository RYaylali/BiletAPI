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
using BiletAPI.Application.Models.Dtos.LoginDtos;
using System.Net.Http;

namespace BiletAPI.WebUI.Controllers
{

	public class LoginController : Controller
	{
		private readonly HttpClient _httpClient;
		private readonly string _baseUrl;

		public LoginController(HttpClient httpClient)
		{
			_httpClient = httpClient;     
			_baseUrl = "https://localhost:7270/api";
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginDto model)
		{

			if (ModelState.IsValid)
			{
				var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

				using var response = await _httpClient.PostAsync($"{_baseUrl}/User/Login/Login", content);

				if (response.IsSuccessStatusCode)
				{
					// Do something on success, e.g. redirect to home page
					return RedirectToAction("Index", "HomePage");
				}
				else
				{
					// Do something on failure, e.g. show error message
					ModelState.AddModelError("", "Invalid email or password");
				}
			}

			return View(model);
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(UserRegisterDto model)
		{
			if (ModelState.IsValid)
			{
				var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

				using var response = await _httpClient.PostAsync($"{_baseUrl}/User/Register/Register", content);

				if (response.IsSuccessStatusCode)
				{
					// Do something on success, e.g. redirect to login page
					return RedirectToAction("Login");
				}
				else
				{
					// Do something on failure, e.g. show error message
					ModelState.AddModelError("", "Registration failed");
				}
			}

			return View(model);
		}
	}
}
