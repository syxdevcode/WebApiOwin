using Microsoft.Owin;
using Owin;
using System.Web.Http;
using WebApiOwin.App_Start;

[assembly: OwinStartup(typeof(WebApiOwin.Startup))]

namespace WebApiOwin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IocContainer.Register();

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);

            var configuration = new HttpConfiguration();

            WebApiConfig.Register(configuration);
            app.UseWebApi(configuration);
        }
    }
}