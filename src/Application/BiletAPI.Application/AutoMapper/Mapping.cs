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
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
        }
        public Mapping(string profileName) : base(profileName)
        {
        }
    }
}
