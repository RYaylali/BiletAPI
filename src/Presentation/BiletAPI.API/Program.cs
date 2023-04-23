using Autofac;
using Autofac.Extensions.DependencyInjection;
using BiletAPI.Application.Ioc;
using BiletAPI.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BiletAPI.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

			builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
			{
				builder.RegisterModule(new DependencyResolver());
			});
			
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddHttpContextAccessor();
			builder.Services.AddMvc();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<BiletApiContextDb>(option =>
			{
				option.UseSqlServer("server=DESKTOP-491CL38\\YAYLALISERVER22;database=BiletDB;Trusted_Connection=True;");
			});
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt=>
			{
				opt.RequireHttpsMetadata = false;
				opt.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidIssuer="http://localhost",
					ValidAudience="http://localhost",
					IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("salkdaskdsakldsladksladlksadkasdlkasdsakldklasaslk")),
					ValidateIssuerSigningKey=true,
					ValidateLifetime=true,
					ClockSkew=TimeSpan.Zero//geri sayým yapar. ve sýfýrda token kapanýr
					
				};
			});
			builder.Services.AddAuthorization(options =>
			{
				options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
					.RequireAuthenticatedUser()
					.Build();
			});
			
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthentication();//kayýtlý mýsýn
			app.UseAuthorization();//yetkin var mý?


			app.MapControllers();

			app.Run();
		}
	}
}