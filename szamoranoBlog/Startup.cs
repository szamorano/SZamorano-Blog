using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(szamoranoBlog.Startup))]
namespace szamoranoBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
