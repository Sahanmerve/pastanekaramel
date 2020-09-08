using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SweetShop.Startup))]
namespace SweetShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
