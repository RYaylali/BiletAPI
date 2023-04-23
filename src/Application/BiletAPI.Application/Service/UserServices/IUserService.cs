using BiletAPI.Application.Models.Dtos.LoginDtos;
using BiletAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Application.Service.UserServices
{
	public interface IUserService
	{
		Task<Customer> Login(LoginDto model);
		Task<string> Register(UserRegisterDto model);
	}
}
