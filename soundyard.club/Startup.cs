using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(soundyyard.club.web.Startup))]
namespace soundyyard.club.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
