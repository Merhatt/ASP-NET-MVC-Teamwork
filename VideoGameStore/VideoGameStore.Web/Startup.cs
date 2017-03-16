using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoGameStore.Web.Startup))]
namespace VideoGameStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
