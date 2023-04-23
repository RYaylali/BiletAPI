using BiletAPI.Application.Models.Dtos.CityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Application.Service.CityServices
{
	public interface ICityService
	{
		Task<string> AddCity(CityDto model);
	}
}
