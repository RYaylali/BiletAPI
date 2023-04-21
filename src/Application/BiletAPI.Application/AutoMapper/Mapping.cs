using AutoMapper;
using BiletAPI.Application.Models.Dtos;
using BiletAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Application.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
        }
        public Mapper(string profileName) : base(profileName)
        {
        }
    }
}
