using BiletAPI.Application.IRepositories;
using BiletAPI.Application.Models.Dtos;
using BiletAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Application.Service.UserServices
{
    public class UserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<string> Register(UserRegisterDto model)
        {
            if (model is not null)
            {
                var user = new User
                {
                    ID = Guid.NewGuid(),
                    Name = model.Name,
                    Surname = model.Surname,
                    Age = model.Age,
                    Gender = model.Gender,
                    Mail = model.Mail,
                    PhoneNumber = model.PhoneNumber,
                    Password = model.Password
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
                var loggedUser = _userRepo.GetDefault(user => user.Mail == model.Mail && user.Password ==model.Password);
                return "Giriş Başarıyla Gerçekleştirildi.";
            }

            return "Giriş gerçekleştirilemedi";
        }
    }
}
