using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiOwin.Repository;
using WebApiOwin.Services;

namespace WebApiOwin.App_Start
{
    public class DependencyInjectionConfig
    {
        public static IContainer Register()
        {
            var builder = IocContainer.Instance;
            builder.RegisterType<RefreshTokenService>().As<IRefreshTokenService>();
            builder.RegisterType<RefreshTokenRepository>().As<IRefreshTokenRepository>();
            builder.RegisterType<ClientService>().As<IClientService>();

            return builder.Build();
        }
    }
}