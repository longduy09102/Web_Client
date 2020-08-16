using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebQLBHMA_Client.Startup))]
namespace WebQLBHMA_Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
