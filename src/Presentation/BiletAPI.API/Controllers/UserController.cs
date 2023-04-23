using BiletAPI.API.Model;
using BiletAPI.Application.IRepositories;
using BiletAPI.Application.Models.Dtos;
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
		[Authorize]
		[HttpPost("Login")]
		public IActionResult Login(LoginDto model)
		{
			if (ModelState.IsValid)
			{
				var userMessage = _userService.Login(model);
				new CreateToken().TokenCreate();
				return Ok(userMessage);
			}
			return BadRequest(model);
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
