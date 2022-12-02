using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MagneticMonitoringApp.Startup))]
namespace MagneticMonitoringApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
