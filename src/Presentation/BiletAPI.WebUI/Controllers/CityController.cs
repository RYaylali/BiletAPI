using BiletAPI.Application.Models.Dtos.LoginDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System;
using BiletAPI.Application.Models.Dtos.CityDto;
using System.Net.Http;


namespace BiletAPI.WebUI.Controllers
{
	public class CityController : Controller
	{
		private readonly HttpClient _httpClient;
		private readonly string _baseUrl;

		public CityController(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_baseUrl = "https://localhost:7270/api";
		}
		[HttpGet]
		public IActionResult AddCity()
		{
			return View();
		}
		//[HttpPost]
		//public async Task<IActionResult> AddCity(CityDto model)
		//{
		//	using (var httpClient = new HttpClient())
		//	{
		//		StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"); //Türkçe karakterini destekleyen json oluşturduk.

		//		using (var cevap = await httpClient.PostAsync($"{_baseUrl}/City/AddCity", content))
		//		{
		//			string apiCevap = await cevap.Content.ReadAsStringAsync();
		//		}
		//	}
		//	return RedirectToAction("Index", "HomePage");
		//}
		[HttpPost]
		public async Task<IActionResult> AddCity(CityDto model)
		{
			if (ModelState.IsValid)
			{
				var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

				using var response = await _httpClient.PostAsync($"{_baseUrl}/City/AddCity/AddCity", content);

				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "HomePage");
				}
				else
				{
					ModelState.AddModelError("", "Registration failed");
				}
			}

			return View(model);
		}
	}
}
