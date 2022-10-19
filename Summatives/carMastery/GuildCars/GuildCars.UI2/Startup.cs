using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuildCars.UI2.Startup))]
namespace GuildCars.UI2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
