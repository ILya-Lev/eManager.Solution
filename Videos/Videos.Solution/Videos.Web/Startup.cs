using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Videos.Web.Startup))]
namespace Videos.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
