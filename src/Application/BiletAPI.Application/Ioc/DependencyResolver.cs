﻿using Autofac;
using AutoMapper;
using BiletAPI.Application.AutoMapper;
using BiletAPI.Application.IRepositories;
using BiletAPI.Application.Service.CityServices;
using BiletAPI.Application.Service.UserServices;
using BiletAPI.Infrastructure.IRepositories;
using BiletAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Application.Ioc
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Repository 
            builder.RegisterType<UserRepo>().As<IUserRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CityRepo>().As<ICityRepo>().InstancePerLifetimeScope();

            //Services
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CityService>().As<ICityService>().InstancePerLifetimeScope();

            //AUTOMAPPER
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapping>();
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //daha sonra kullanılabilecek yeni bağlamlar için
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();

                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
