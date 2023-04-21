using Autofac;
using Autofac.Extensions.DependencyInjection;
using BiletAPI.Application.Ioc;
using BiletAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BiletAPI.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<BiletApiContextDb>(option =>
			{
				option.UseSqlServer("server=DESKTOP-491CL38\\YAYLALISERVER22;database=BiletDB;Trusted_Connection=True;");
			});
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new DependencyResolver());
            });

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}