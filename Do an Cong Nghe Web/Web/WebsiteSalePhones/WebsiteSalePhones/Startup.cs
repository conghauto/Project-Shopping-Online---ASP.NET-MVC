using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteSalePhones.Startup))]
namespace WebsiteSalePhones
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
