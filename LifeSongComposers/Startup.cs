using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LifeSongComposers.Startup))]
namespace LifeSongComposers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
