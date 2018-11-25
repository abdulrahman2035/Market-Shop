using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Marketshop.Startup))]
namespace Marketshop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
