using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bi_WeeklyProject_6.Startup))]
namespace Bi_WeeklyProject_6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
