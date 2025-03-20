using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(soundyard.club.Startup))]
namespace soundyard.club
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
