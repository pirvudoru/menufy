using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MenufyServer.Startup))]
namespace MenufyServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
