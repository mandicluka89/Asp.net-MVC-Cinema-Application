using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BioskopP15.Startup))]
namespace BioskopP15
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
