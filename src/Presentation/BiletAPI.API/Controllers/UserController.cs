using BiletAPI.API.Model;
using BiletAPI.Application.IRepositories;
using BiletAPI.Application.Models.Dtos.LoginDtos;
using BiletAPI.Application.Service.UserServices;
using BiletAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiletAPI.API.Controllers
{

    [Route("api/[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		
		public UserController(IUserService userService)
		{
			_userService = userService;
		}
		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginDto model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userService.Login(model);
				if (user != null)
				{
					var token = new CreateToken().TokenCreate();
					return Ok(new { Token = token });
				}
			}

			return BadRequest("Invalid email or password.");
		}
		[HttpPost("Register")]
		public IActionResult Register(UserRegisterDto model)
		{
			if (ModelState.IsValid)
			{
				var user = _userService.Register(model);
				return Ok(user);
			}
			return BadRequest(model);
		}
	}
}
