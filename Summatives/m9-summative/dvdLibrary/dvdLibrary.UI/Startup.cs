using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dvdLibrary.UI.Startup))]
namespace dvdLibrary.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
