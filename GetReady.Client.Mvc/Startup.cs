using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GetReady.Client.Mvc.Startup))]
namespace GetReady.Client.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
