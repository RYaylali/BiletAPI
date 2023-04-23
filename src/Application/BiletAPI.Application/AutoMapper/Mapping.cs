using AutoMapper;
using BiletAPI.Application.Models.Dtos.CityDto;
using BiletAPI.Application.Models.Dtos.LoginDtos;
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
            CreateMap<Customer, UserRegisterDto>().ReverseMap();
            CreateMap<Customer, LoginDto>().ReverseMap();

            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
