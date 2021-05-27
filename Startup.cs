using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CurryLounge.Startup))]
namespace CurryLounge
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
