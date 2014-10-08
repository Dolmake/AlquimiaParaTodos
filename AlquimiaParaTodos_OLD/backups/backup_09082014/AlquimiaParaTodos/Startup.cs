using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlquimiaParaTodos.Startup))]
namespace AlquimiaParaTodos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
