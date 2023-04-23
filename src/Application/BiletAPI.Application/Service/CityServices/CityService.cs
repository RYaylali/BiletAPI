using AutoMapper;
using BiletAPI.Application.IRepositories;
using BiletAPI.Application.Models.Dtos.CityDto;
using BiletAPI.Application.Models.Dtos.LoginDtos;
using BiletAPI.Domain.Entities;
using BiletAPI.Domain.Enums;
using BiletAPI.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Application.Service.CityServices
{
	public class CityService : ICityService
	{
		private readonly ICityRepo _cityRepo;
		private readonly IMapper _mapper;
		public CityService(ICityRepo cityRepo, IMapper mapper)
		{
			_cityRepo = cityRepo;
			_mapper = mapper;
		}
		public async Task<string> AddCity(CityDto model)
		{
			if (model is not null)
			{
				var cityModel = _mapper.Map<CityDto, City>(model);
				var city = new City
				{
					ID = Guid.NewGuid(),
					Status = Status.Active,
					CreatedDate = DateTime.Now,
					CityName = cityModel.CityName
				};

				_cityRepo.Add(city);

				return "Şehir Başarıyla Eklendi";
			}
			return "Şehir Eklenemedi";
		}
	}
}
