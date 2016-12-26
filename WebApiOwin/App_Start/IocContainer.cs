using Autofac;
using WebApiOwin.PersistenceProvider;
using WebApiOwin.Repository;
using WebApiOwin.Services;

namespace WebApiOwin.App_Start
{
    public class IocContainer
    {
        public static IContainer Default;

        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RefreshTokenService>().As<IRefreshTokenService>();
            builder.RegisterType<RefreshTokenRepository>().As<IRefreshTokenRepository>();
            builder.RegisterType<ClientService>().As<IClientService>();
            builder.RegisterType<AuthorizationServerProvider>();
            builder.RegisterType<RefreshTokenProvider>();
            Default = builder.Build();
        }
    }
}