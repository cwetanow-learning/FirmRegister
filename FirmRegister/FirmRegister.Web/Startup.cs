using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirmRegister.Web.Startup))]
namespace FirmRegister.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
