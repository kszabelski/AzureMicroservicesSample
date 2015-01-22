using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureMicroservicesSample.Web.Startup))]
namespace AzureMicroservicesSample.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
