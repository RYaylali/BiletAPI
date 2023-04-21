using BiletAPI.Application.IRepositories;
using BiletAPI.Domain.Entities;
using BiletAPI.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Infrastructure.Repositories
{
	public class UserRepo : BaseRepo<User>,IUserRepo
	{
		public UserRepo(BiletApiContextDb context) : base(context)
		{
		}
	}
}
