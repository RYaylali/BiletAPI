using AutoMapper;
using BiletAPI.Application.IRepositories;
using BiletAPI.Application.Models.Dtos;
using BiletAPI.Domain.Entities;
using BiletAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Application.Service.UserServices
{
	public class UserService:IUserService
	{
		private readonly IUserRepo _userRepo;
		private readonly IMapper _mapper;
		public UserService(IUserRepo userRepo, IMapper mapper)
		{
			_userRepo = userRepo;
			_mapper = mapper;
		}
		public async Task<string> Register(UserRegisterDto model)
		{
			if (model is not null)
			{
				var userModel = _mapper.Map<UserRegisterDto, User>(model);
				var user = new User
				{
					ID = Guid.NewGuid(),
					Status = Status.Active,
					CreatedDate = DateTime.Now,
					Name = userModel.Name,
					Surname = userModel.Surname,
					Age = userModel.Age,
					Gender = userModel.Gender,
					Mail = userModel.Mail,
					PhoneNumber = userModel.PhoneNumber,
					Password = userModel.Password
				};

				_userRepo.Add(user);
				_userRepo.Save();
				return "Kullanıcı Başarıyla Eklendi";
			}
			return "Kullanıcı Eklenemedi";
		}
		public async Task<string> Login(LoginDto model)
		{
			if (model is not null)
			{
				var loginModel = _mapper.Map<LoginDto, User>(model);
				var loggedUser = _userRepo.GetDefault(user => user.Mail == loginModel.Mail && user.Password == loginModel.Password);
				return "Giriş İşlemi Başarıyla Gerçekleştirildi.";
			}

			return "Giriş İşlemi Gerçekleştirilemedi";
		}
	}
}
