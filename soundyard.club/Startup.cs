using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(club.soundyard.web.Startup))]
namespace club.soundyard.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
