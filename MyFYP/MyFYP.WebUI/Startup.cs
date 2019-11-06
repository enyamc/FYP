using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFYP.WebUI.Startup))]
namespace MyFYP.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
