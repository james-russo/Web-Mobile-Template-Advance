using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using Demo.Configuration;
using Demo.Data;
using FluentValidation;

namespace Demo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterAutoFac();
        }

        private void RegisterAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType(typeof (NHibernateRespository))
                .As(typeof (IRepository));
            
            //builder.RegisterAssemblyTypes(typeof(ValidatorFactory.Configuration.ValidatorFactory).Assembly)
            //   .AsClosedTypesOf(typeof(IValidator<>))
            //   .AsImplementedInterfaces();

            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
