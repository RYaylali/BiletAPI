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
		public BiletApiContextDb(DbContextOptions<BiletApiContextDb> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Ticket>()
				.HasOne(x => x.Expedition)
				.WithOne(x => x.Ticket)
				.HasForeignKey<Ticket>(x => x.ExpeditionId)
				.OnDelete(DeleteBehavior.Restrict);
		}
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Bus> Buses { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Expedition> Expeditions { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
	}
}
