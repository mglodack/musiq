using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Musiq.Startup))]
namespace Musiq
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
