using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(stpwomenssoccer2.Startup))]
namespace stpwomenssoccer2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
