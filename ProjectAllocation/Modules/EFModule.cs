using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DataAccess;
using DataAccess.Abstraction;
using DataAccess.Implementation;
using ProjectAllocation.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectAllocation.Modules
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterType(typeof(ApplicationDbContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
            builder.RegisterApiControllers(typeof(LogInController).Assembly);
            builder.RegisterControllers(typeof(HomeController).Assembly);
        }
    }
}