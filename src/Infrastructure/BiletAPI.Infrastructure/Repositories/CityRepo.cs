using BiletAPI.Domain.Entities;
using BiletAPI.Infrastructure.Context;
using BiletAPI.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Infrastructure.Repositories
{
	public class CityRepo : BaseRepo<City>, ICityRepo
	{
		public CityRepo(BiletApiContextDb context) : base(context)
		{
		}
	}
}
