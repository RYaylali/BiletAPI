using BiletAPI.Application.Models.Dtos.CityDto;
using BiletAPI.Application.Models.Dtos.LoginDtos;
using BiletAPI.Application.Service.CityServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiletAPI.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CityController : ControllerBase
	{
		private readonly ICityService _cityService;

		public CityController(ICityService cityService)
		{
			_cityService = cityService;
		}
		[HttpPost("AddCity")]
		public IActionResult AddCity(CityDto model)
		{
			if (ModelState.IsValid)
			{
				var city = _cityService.AddCity(model);
				return Ok(city);
			}
			return BadRequest(model);
		}
	}
}
