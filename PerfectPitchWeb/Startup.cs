using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PerfectPitchWeb.Startup))]
namespace PerfectPitchWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
