using BiletAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Infrastructure.Context
{
	public class BiletApiContextDb : DbContext
	{
        public BiletApiContextDb( DbContextOptions<BiletApiContextDb> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
